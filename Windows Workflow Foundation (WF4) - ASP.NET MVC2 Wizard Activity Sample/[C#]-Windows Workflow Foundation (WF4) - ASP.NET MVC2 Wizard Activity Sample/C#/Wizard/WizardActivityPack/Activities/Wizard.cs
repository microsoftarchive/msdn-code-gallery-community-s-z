//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System.Activities;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

using System;
using System.Linq;
using System.Text;
namespace WizardActivityPack.Activities
{
    /// <summary>
    /// Sample sequence that accepts the index of the first element 
    /// in its activities collection to be executed.
    
    /// </summary>
    //[DesignerAttribute(typeof(WizardDesigner))]
    public sealed class Wizard : NativeActivity
    {

        Collection<Step> activities;



        Variable<int> LastIndex;

        Variable<Bookmark> ResumeParent;
        

        public Wizard()
            : base()
        {
            this.LastIndex = new Variable<int>() { Name = "LastIndexHint", Default = 0 };
            
            this.ResumeParent = new Variable<Bookmark>() { Name = "ResumeParent", Default = null };
        }

        [Browsable(false)]
        public Collection<Step> Activities
        {
            get
            {
                if (this.activities == null)
                {
                    this.activities = new Collection<Step>();
                }
                return this.activities;
            }
        }
        protected override bool CanInduceIdle
        {

            get { return true; }

        }



        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            // activities
            foreach (Activity activity in this.Activities)
            {
                metadata.AddChild(activity);
            }


            metadata.AddImplementationVariable(this.LastIndex);
            
            metadata.AddImplementationVariable(this.ResumeParent);


        }

        protected override void Execute(NativeActivityContext context)
        {
            if (this.Activities.Count > 0)
            {

                Bookmark bm = context.Properties.Find(Constants._ContainsChildWizard) as Bookmark;

                if (bm != null)
                {
                    context.ResumeBookmark(bm, true);

                }

                Bookmark parentbm = context.Properties.Find(Constants._ResumeParent) as Bookmark;
                if (parentbm != null)
                {
                    this.ResumeParent.Set(context, parentbm);
                }
                Bookmark ResumeParent = context.CreateBookmark(ResumeParentCallBack, BookmarkOptions.NonBlocking | BookmarkOptions.MultipleResume);
                context.Properties.Update(Constants._ResumeParent, ResumeParent);


                FindStepAndSchedule(context);



            }
        }

        

      
        private void FindStepAndSchedule(NativeActivityContext context)
        {
            Queue<int> lastposition = (Queue<int>)context.Properties.Find(Constants._LastPosition);
            Queue<int> currentposition = (Queue<int>)context.Properties.Find(Constants._CurrentPosition);
            Command cmd = (Command)context.Properties.Find(Constants._Command);
            int current = lastposition.Count > 0 ? lastposition.Dequeue() : -1;
            if (lastposition.Count == 0 && cmd == Command.Next)
            {
                current++;
            }
            if (current < 0) current = 0;
            if (current >= 0 && current < this.activities.Count)
            {
                bool HasBack = (bool)context.Properties.Find(Constants._HasBack);
                if (!HasBack && current > 0) context.Properties.Update(Constants._HasBack,true);
                bool HasNext = (bool)context.Properties.Find(Constants._HasNext);
                if (!HasNext && current < this.activities.Count-1) context.Properties.Update(Constants._HasNext, true);

                context.Properties.Update(Constants._LastPosition, lastposition);
                currentposition.Enqueue(current);
                context.Properties.Update(Constants._CurrentPosition, currentposition);
                ScheduleStep(context, current);
            }
            else
            {
                Bookmark bm = this.ResumeParent.Get(context);
                if (bm != null) context.ResumeBookmark(bm, cmd);
            }

        }


        private void ScheduleStep(NativeActivityContext context, int current)
        {
            

            // set the value of the last executed element


            // get the element to execute
            Activity nextChild = this.Activities[current];

            this.LastIndex.Set(context, current);

            // execute it!
            context.ScheduleActivity(nextChild, new CompletionCallback(OnStepCompleted));
        }



        private void OnStepCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {

            int completedInstanceIndex = this.LastIndex.Get(context);
            Step completedstep = completedInstance.Activity as Step;

            if (completedstep.Skipped)
            {
                int current = completedInstanceIndex + 1;
                Queue<int> currentposition = (Queue<int>)context.Properties.Find(Constants._CurrentPosition);
                if (currentposition.Count > 0) currentposition.Dequeue();
                currentposition.Enqueue(current);
                context.Properties.Update(Constants._CurrentPosition, currentposition);
                ScheduleStep(context, current);
            }
            else
            {
                if (!completedstep.ContainsChildWizard)
                {

                    Stack<CustomBookmark> bmlist = context.Properties.Find(Constants._BookmarkHistory) as Stack<CustomBookmark>;
                    Queue<int> currentPosition = context.Properties.Find(Constants._CurrentPosition) as Queue<int>;
                    CustomBookmark currentbookmark = new CustomBookmark();
                    currentbookmark.StepID = currentPosition.ToPlainString();
                    currentbookmark.StepName = completedInstance.Activity.DisplayName;
                    currentbookmark.HasBack = (bool)context.Properties.Find(Constants._HasBack);
                    currentbookmark.HasNext = (bool)context.Properties.Find(Constants._HasNext);
                    bmlist.Push(currentbookmark);
                    context.Properties.Update(Constants._BookmarkHistory, bmlist);
                  
                }
            }

        }
        void ResumeParentCallBack(NativeActivityContext context, Bookmark bookmark, object input)
        {
            int current = this.LastIndex.Get(context);
            Command cmd = (Command)input;
            current++;
            Queue<int> currentposition = new Queue<int>();

            if (current >= 0 && current < this.Activities.Count)
            {
                bool HasBack = (bool)context.Properties.Find(Constants._HasBack);
                if (!HasBack && current > 0) context.Properties.Update(Constants._HasBack, true);
                bool HasNext = (bool)context.Properties.Find(Constants._HasNext);
                if (!HasNext && current < this.activities.Count - 1) context.Properties.Update(Constants._HasNext, true);

               

                currentposition.Enqueue(current);
                context.Properties.Update(Constants._CurrentPosition, currentposition);
                ScheduleStep(context, current);
            }
            else
            {
                Bookmark bm = this.ResumeParent.Get(context);
                if (bm != null) context.ResumeBookmark(bm, cmd);
            }
        }

        



    }
}