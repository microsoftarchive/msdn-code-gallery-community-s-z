//-------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved
//-------------------------------------------------------------------

using System.Activities;
using System.Activities.Presentation;
using System.ComponentModel;
using System.Windows.Markup;
namespace WizardActivityPack.Activities
{
    //[DesignerAttribute(typeof(StepDesigner))]
    public sealed class Step : NativeActivity
    {
      
        /// <summary>
        /// It represents the Condition to decide whether the .
        /// It's optional. 
        /// If the Condition is null, 
        /// </summary>

        [Browsable(false)]
        [DefaultValue(null)]
        public Activity<bool> SkipCondition{ get;set;}
        [Browsable(false)]
        [DefaultValue(null)]
        public Activity Body { get; set; }
        
        public bool Skipped = false;
        public bool ContainsChildWizard =  false;
        protected override bool CanInduceIdle
        {

            get { return true; }

        }
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddChild(SkipCondition);
            metadata.AddChild(Body);
            
            base.CacheMetadata(metadata);

        }

        protected override void Execute(NativeActivityContext context)
        {

            //Schedule the Skip Condition test
            Command cmd = (Command)context.Properties.Find(Constants._Command);
            
            if (SkipCondition != null && (cmd== Command.Next || cmd== Command.Start))
                context.ScheduleActivity<bool>(SkipCondition, ConditionCompletion);
            else
                ScheduleBody(context);

        }
        private void ConditionCompletion(NativeActivityContext context, ActivityInstance completedInstance, bool result)
        {
            if (completedInstance.State == ActivityInstanceState.Closed && result)
            {
                // Mark the  the current step as skipped
                Skipped = true;
            }
            else
            {
                //Condition returned false: start executing body
                Skipped = false;

                ScheduleBody(context);

            }
        }
        private void ScheduleBody(NativeActivityContext context)
        {
            Bookmark containchildbm = context.CreateBookmark(ResumeContainsChild, BookmarkOptions.NonBlocking);
            context.Properties.Update(Constants._ContainsChildWizard,containchildbm);
            
            //Condition returned true: start executing body
            context.ScheduleActivity(Body, BodyCompletion);
        }


        private void BodyCompletion(NativeActivityContext context, ActivityInstance completedInstance)
        {
            if (completedInstance.State == ActivityInstanceState.Closed)
            {
                //Body completed successfully without cancellation

            }

        }

        void ResumeContainsChild(NativeActivityContext context, Bookmark bookmark, object input)
        {

            this.ContainsChildWizard=(bool)input;
        }
    }
}
