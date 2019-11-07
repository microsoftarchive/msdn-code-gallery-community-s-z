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
    /// This example demonstrates caching of callback delegates
    /// </summary>
    //[DesignerAttribute(typeof(WizardContainerDesigner))]
    public sealed class WizardContainer : NativeActivity
    {

        [Browsable(false)]
        [DefaultValue(null)]
        public Wizard Body { get; set; }

        public InArgument<Command?> Action { get; set; }
        public InArgument<CustomBookmark> Bookmark { get; set; }

        public InOutArgument<List<CustomBookmark>> BookmarkHistory { get; set; }
        
  

        public WizardContainer()
            : base()
        {
           
        }

        
        protected override bool CanInduceIdle
        {

            get { return true; }

        }



        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {



            metadata.AddChild(Body);

            // add arguments
            metadata.AddArgument(new RuntimeArgument("Action", typeof(Command?), ArgumentDirection.In, true));
            metadata.AddArgument(new RuntimeArgument("Bookmark", typeof(CustomBookmark), ArgumentDirection.In, false));
            metadata.AddArgument(new RuntimeArgument("BookmarkHistory", typeof(List<CustomBookmark>), ArgumentDirection.InOut, false));
        }

        protected override void Execute(NativeActivityContext context)
        {
            if (this.Body!=null)
            {

                Initialize(context);

                context.ScheduleActivity(Body, BodyCompletion);


            }
        }

        private void BodyCompletion(NativeActivityContext context, ActivityInstance completedInstance)
        {
            if (completedInstance.State == ActivityInstanceState.Closed)
            {
                Stack<CustomBookmark> bmlist = context.Properties.Find(Constants._BookmarkHistory) as Stack<CustomBookmark>;
                List<CustomBookmark> c = bmlist.Reverse().ToList();
                this.BookmarkHistory.Set(context, c);

            }

        }

        private void Initialize(NativeActivityContext context)
        {
           


                
                Command cmd = this.Action.Get(context) as Command? ?? Command.Start;


                Stack<CustomBookmark> history = (this.BookmarkHistory.Get(context) as List<CustomBookmark>).ToStack();
                history = history ?? new Stack<CustomBookmark>();
                CustomBookmark lastbookmark = null;

                switch (cmd)
                {
                    case Command.Start:
                        //clear the old history
                        history = new Stack<CustomBookmark>();
                        lastbookmark = null;
                        break;
                    case Command.Next:
                        lastbookmark = history.Count > 0 ? history.Peek() : null;
                        break;
                    case Command.Back:
                        if (history.Count > 0) history.Pop();
                        lastbookmark = (history.Count > 0) ? history.Pop() : null;
                        break;
                    case Command.GoTo:
                        CustomBookmark inputbm = this.Bookmark.Get(context) as CustomBookmark ?? new CustomBookmark();
                        bool Notfound = true;

                        while (Notfound && history.Count > 0)
                        {
                            CustomBookmark temp = history.Pop();
                            if (temp.StepID.Equals(inputbm.StepID))
                            {
                                lastbookmark = inputbm;
                                Notfound = false;
                            }


                        }
                        
                        break;

                }


                string laststepid = lastbookmark != null ? lastbookmark.StepID : string.Empty;
                context.Properties.Add(Constants._LastPosition, laststepid.ToQueue());
                //if lastbook mark is null , set the commad to start
                if (lastbookmark == null) cmd = Command.Start;

                context.Properties.Add(Constants._Command, cmd);
                context.Properties.Add(Constants._CurrentPosition, new Queue<int>());
                context.Properties.Add(Constants._BookmarkHistory, history);
                context.Properties.Add(Constants._HasNext, false);
                context.Properties.Add(Constants._HasBack, false);
            

        }
          
      
    



    }
}