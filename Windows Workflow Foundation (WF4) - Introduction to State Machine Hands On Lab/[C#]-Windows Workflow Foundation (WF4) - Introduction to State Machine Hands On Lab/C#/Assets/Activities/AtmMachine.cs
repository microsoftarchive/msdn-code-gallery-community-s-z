// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmMachine.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System;
    using System.Activities;
    using System.Activities.Statements.Tracking;
    using System.Activities.Tracking;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.Activities.Extensions.Tracking;

    /// <summary>
    /// The AtmMachine Model
    /// </summary>
    /// <remarks>
    /// Encapsulates the AtmActivity state machine
    /// </remarks>
    public class AtmMachine : TrackingParticipant
    {
        #region Constants and Fields

        /// <summary>
        ///   The default timeout.
        /// </summary>
        public readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        /// <summary>
        ///   The atm activity definition.
        /// </summary>
        private static readonly AtmActivity AtmActivityDefinition = new AtmActivity();

        /// <summary>
        ///   The atm view model.
        /// </summary>
        private readonly IAtmViewModel atmViewModel;

        /// <summary>
        ///   The transition enabled.
        /// </summary>
        private readonly Dictionary<AtmTransition, bool> transitionEnabled = new Dictionary<AtmTransition, bool>();

        /// <summary>
        ///   The idle event.
        /// </summary>
        private readonly ManualResetEvent workflowBusy = new ManualResetEvent(false);

        /// <summary>
        ///   The time that the ATM User has to enter a command
        /// </summary>
        private TimeSpan atmTimeout = TimeSpan.FromSeconds(30);

        /// <summary>
        ///   The camera on.
        /// </summary>
        private bool cameraOn;

        /// <summary>
        ///   The hardware initialized.
        /// </summary>
        private bool hardwareInitialized;

        /// <summary>
        ///   The timeout.
        /// </summary>
        private TimeSpan timeout;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AtmMachine"/> class.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The ViewModel is null
        /// </exception>
        public AtmMachine(IAtmViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }

            this.atmViewModel = viewModel;
            this.InitializeCommands();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets AtmTimeout.
        /// </summary>
        public TimeSpan AtmTimeout
        {
            get
            {
                return this.atmTimeout;
            }

            set
            {
                this.atmTimeout = value;
            }
        }

        /// <summary>
        ///   Gets WorkflowApplication.
        /// </summary>
        public WorkflowApplication AtmWorkflowHost { get; private set; }

        /// <summary>
        ///   Gets a value indicating whether PowerOn.
        /// </summary>
        public bool PowerOn { get; private set; }

        /// <summary>
        ///   Gets or sets Timeout.
        /// </summary>
        public TimeSpan Timeout
        {
            get
            {
                if (this.timeout == TimeSpan.Zero)
                {
                    this.timeout = this.DefaultTimeout;
                }

                return this.timeout;
            }

            set
            {
                this.timeout = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets CurrentState.
        /// </summary>
        protected string CurrentState { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// The accept pin.
        /// </summary>
        /// <param name="pin">
        /// The pin number.
        /// </param>
        /// <returns>
        /// The AtmMachine
        /// </returns>
        public AtmMachine AcceptPin(string pin)
        {
            this.ResumeCommand(AtmTransition.KeypadEnter, pin);
            return this;
        }

        /// <summary>
        /// Cancels the current transaction
        /// </summary>
        /// <returns>
        /// The AtmMachine
        /// </returns>
        public AtmMachine Cancel()
        {
            this.ResumeCommand(AtmTransition.KeypadCancel, null);
            return this;
        }

        /// <summary>
        /// The control camera.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        public void ControlCamera(bool record)
        {
            this.cameraOn = record;
        }

        /// <summary>
        /// The deposit.
        /// </summary>
        /// <returns>
        /// The ATM Machine
        /// </returns>
        public AtmMachine Deposit()
        {
            this.ResumeCommand(AtmTransition.Deposit, null);
            return this;
        }

        /// <summary>
        /// The initialize hardware.
        /// </summary>
        public void InitializeHardware()
        {
            // Simulate initialization
            Thread.Sleep(1000);
            this.hardwareInitialized = true;
        }

        /// <summary>
        /// The insert card.
        /// </summary>
        /// <param name="validCard">
        /// The valid card.
        /// </param>
        /// <returns>
        /// The AtmMachine
        /// </returns>
        public AtmMachine InsertCard(bool validCard)
        {
            if (this.AtmWorkflowHost == null)
            {
                throw new InvalidOperationException("The ATM StateMachine is null, the workflow may have completed or aborted");
            }

            var readerResult = new CardReaderResult { CardStatus = validCard ? CardStatus.Valid : CardStatus.Invalid, Event = CardReaderEvent.CardInserted };

            this.atmViewModel.Notify(readerResult);

            this.workflowBusy.Reset();

            var result = this.AtmWorkflowHost.ResumeBookmark(CardReaderEvent.CardInserted.ToString(), readerResult);

            switch (result)
            {
                case BookmarkResumptionResult.NotFound:
                    throw new InvalidOperationException(SR.The_StateMachine_is_not_waiting_for_the_card_reader_CardInserted_event_right_now_);
                case BookmarkResumptionResult.NotReady:
                    throw new InvalidOperationException(SR.The_StateMachine_is_not_ready_for_the_card_reader_CardInserted_event_right_now_);
            }

            return this;
        }

        /// <summary>
        /// The is camera on.
        /// </summary>
        /// <returns>
        /// true if the camera is on
        /// </returns>
        public bool IsCameraOn()
        {
            return this.cameraOn;
        }

        /// <summary>
        /// Determines if the state machine is currently in this state
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// true if it is in the state, false if not
        /// </returns>
        public bool IsCurrentState(string state)
        {
            return this.CurrentState == state;
        }

        /// <summary>
        /// Determines if the keypad is enabled
        /// </summary>
        /// <returns>
        /// true if the is keypad enabled.
        /// </returns>
        public bool IsKeypadEnabled()
        {
            return this.hardwareInitialized;
        }

        /// <summary>
        /// Determines if a transition is enabled
        /// </summary>
        /// <param name="transition">
        /// The AtmTransition value.
        /// </param>
        /// <returns>
        /// true if the transition is enabled, false if not
        /// </returns>
        public bool IsTransitionEnabled(AtmTransition transition)
        {
            return this.transitionEnabled[transition];
        }

        /// <summary>
        /// Determines if a transition is enabled
        /// </summary>
        /// <param name="commandString">
        /// The transition string.
        /// </param>
        /// <returns>
        /// true if the transition is enabled, false if not
        /// </returns>
        public bool IsTransitionEnabled(string commandString)
        {
            return this.IsTransitionEnabled(ConvertToAtmTransition(commandString));
        }

        /// <summary>
        /// The remove card.
        /// </summary>
        /// <returns>
        /// The AtmMachine
        /// </returns>
        public AtmMachine RemoveCard()
        {
            this.ResumeCommand(AtmTransition.CardRemoved, null);
            return this;
        }

        /// <summary>
        /// The power off.
        /// </summary>
        /// <returns>
        /// A task that will power off the ATM async
        /// </returns>
        public Task TurnPowerOff()
        {
            this.atmViewModel.ControlCamera(false);
            this.DisableAllCommands();

            if (this.PowerOn && this.AtmWorkflowHost != null)
            {
                this.workflowBusy.Reset();
                return Task.Factory.FromAsync(this.AtmWorkflowHost.BeginCancel, this.AtmWorkflowHost.EndCancel, null).ContinueWith(t => this.WaitForWorkflow());
            }

            // Return a null task if there is nothing to do
            return Task.Factory.StartNew(() => { });
        }

        /// <summary>
        /// The power on.
        /// </summary>
        /// <returns>
        /// The AtmMachine
        /// </returns>
        public AtmMachine TurnPowerOn()
        {
            var settings = new AtmSettings { Timeout = this.AtmTimeout };
            var input = new Dictionary<string, object> { { "Settings", settings } };

            this.AtmWorkflowHost = new WorkflowApplication(AtmActivityDefinition, input) { Idle = this.OnWorkflowIdle, Completed = this.OnWorkflowCompleted };

            this.AtmWorkflowHost.Extensions.Add(this);
            this.AtmWorkflowHost.Extensions.Add(this.atmViewModel);

            // Allow the view model to add a tracking participant);
            if (this.atmViewModel.TrackingParticipant != null)
            {
                this.AtmWorkflowHost.Extensions.Add(this.atmViewModel.TrackingParticipant);
            }

            this.PowerOn = true;
            this.workflowBusy.Reset();

            this.AtmWorkflowHost.Run();

            return this;
        }

        /// <summary>
        /// The wait for state.
        /// </summary>
        /// <param name="targetState">
        /// The target state.
        /// </param>
        /// <exception cref="TimeoutException">
        /// </exception>
        public void WaitForState(string targetState)
        {
            var start = DateTime.Now;
            while (this.CurrentState != targetState)
            {
                this.WaitForWorkflow();
                if (DateTime.Now.Subtract(start) > this.Timeout)
                {
                    throw new TimeoutException(string.Format("Timeout waiting for state {0}", targetState));
                }
            }
        }

        /// <summary>
        /// The wait for idle.
        /// </summary>
        /// <exception cref="TimeoutException">
        /// </exception>
        public void WaitForWorkflow()
        {
            if (!this.workflowBusy.WaitOne(this.Timeout))
            {
                throw new TimeoutException(string.Format("ATM Timeout waiting for the workflow to idle or complete"));
            }
        }

        /// <summary>
        /// The withdraw.
        /// </summary>
        /// <returns>
        /// The ATM Machine
        /// </returns>
        public AtmMachine Withdraw()
        {
            this.ResumeCommand(AtmTransition.Withdraw, null);
            return this;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get argument.
        /// </summary>
        /// <param name="record">
        /// The activity record.
        /// </param>
        /// <param name="name">
        /// The argument name.
        /// </param>
        /// <typeparam name="T">
        /// The data type of the argument
        /// </typeparam>
        /// <returns>
        /// The argument value
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The activity record is null
        /// </exception>
        internal static T GetArgument<T>(ActivityStateRecord record, string name)
        {
            if (record == null)
            {
                throw new ArgumentNullException("record");
            }

            object value;

            if (record.Arguments.TryGetValue(name, out value))
            {
                return (T)value;
            }

            return default(T);
        }

        /// <summary>
        /// Processes Workflow Tracking Records
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        /// <param name="timeoutValue">
        /// The timeout Value.
        /// </param>
        /// <remarks>
        /// The AtmMachine uses workflow tracking records to detect states, transitions and Power events
        /// </remarks>
        protected override void Track(TrackingRecord record, TimeSpan timeoutValue)
        {
            if (record is ActivityStateRecord)
            {
                ProcessActivityStateRecord(record as ActivityStateRecord);
            }
            else if (record is StateMachineStateRecord)
            {
                this.ProcessStateMachineTrackingRecord(record as StateMachineStateRecord);
            }
            else if (record is BookmarkResumptionRecord)
            {
                this.ProcessBookmarkResumptionRecord(record as BookmarkResumptionRecord);
            }
            else if (record is WorkflowInstanceRecord)
            {
                this.ProcessWorkflowInstanceRecord(record as WorkflowInstanceRecord);
            }

#if DEBUG

            // Using Microsoft.Activities.Extensions
            record.Trace();
#endif
        }

        /// <summary>
        /// Converts a string into an AtmTransition
        /// </summary>
        /// <param name="commandString">
        /// The transition string.
        /// </param>
        /// <returns>
        /// The AtmTransition
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The string cannot be converted to an AtmTransition value
        /// </exception>
        private static AtmTransition ConvertToAtmTransition(string commandString)
        {
            AtmTransition cmd;

            if (!Enum.TryParse(commandString, out cmd))
            {
                throw new ArgumentException(string.Format("Invalid transition \"{0}\" - must be an AtmTransition value", commandString), "commandString");
            }

            return cmd;
        }

        /// <summary>
        /// The process activity state record.
        /// </summary>
        /// <param name="activityStateRecord">
        /// The activity state record.
        /// </param>
        private void ProcessActivityStateRecord(ActivityStateRecord activityStateRecord)
        {
            if (activityStateRecord == null)
            {
                return;
            }

            if (activityStateRecord.Activity.Name.ToLower() == "wait for timeout")
            {
                this.WriteTrace(
                    TraceLevel.Info, "You have {0} seconds to enter a command", GetArgument<TimeSpan>(activityStateRecord, "Duration").TotalSeconds);
            }
        }

        /// <summary>
        /// Disables all commands
        /// </summary>
        private void DisableAllCommands()
        {
            foreach (var cmd in Enum.GetValues(typeof(AtmTransition)).Cast<AtmTransition>())
            {
                this.transitionEnabled[cmd] = false;
            }
        }

        /// <summary>
        /// The enable transition.
        /// </summary>
        /// <param name="transition">
        /// The AtmTransition value
        /// </param>
        private void EnableTransition(AtmTransition transition)
        {
            this.WriteTrace(TraceLevel.Info, "Enable transition {0}", transition);
            this.transitionEnabled[transition] = true;
            this.atmViewModel.EnableTransition(transition);
        }

        /// <summary>
        /// The initialize commands.
        /// </summary>
        private void InitializeCommands()
        {
            foreach (var cmd in Enum.GetValues(typeof(AtmTransition)).Cast<AtmTransition>())
            {
                this.transitionEnabled.Add(cmd, false);
            }
        }

        /// <summary>
        /// The on workflow completed event handler.
        /// </summary>
        /// <param name="obj">
        /// The event args.
        /// </param>
        private void OnWorkflowCompleted(WorkflowApplicationCompletedEventArgs obj)
        {
            this.AtmWorkflowHost = null;
            this.PowerOn = false;
            this.CurrentState = null;
            this.atmViewModel.Clear();
            this.workflowBusy.Set();
        }

        /// <summary>
        /// Handles the workflow idle event
        /// </summary>
        /// <param name="args">
        /// The workflow idle event args.
        /// </param>
        private void OnWorkflowIdle(WorkflowApplicationIdleEventArgs args)
        {
            // Enable all commands with matching bookmarks
            foreach (var cmd in args.Bookmarks.Select(bookmarkInfo => ConvertToAtmTransition(bookmarkInfo.BookmarkName)))
            {
                this.EnableTransition(cmd);
            }

            this.workflowBusy.Set();
        }

        /// <summary>
        /// Processes the bookmark resumption record to notify the view model of a transition.
        /// </summary>
        /// <param name="bookmarkResumptionRecord">
        /// The bookmark resumption record.
        /// </param>
        private void ProcessBookmarkResumptionRecord(BookmarkResumptionRecord bookmarkResumptionRecord)
        {
            if (bookmarkResumptionRecord != null && !string.IsNullOrWhiteSpace(bookmarkResumptionRecord.BookmarkName))
            {
                this.atmViewModel.Notify(ConvertToAtmTransition(bookmarkResumptionRecord.BookmarkName), bookmarkResumptionRecord.Payload);
            }
        }

        /// <summary>
        /// Processes State Machine Tracking records to notify the view model of a state change
        /// </summary>
        /// <param name="stateRecord">
        /// The state Record.
        /// </param>
        private void ProcessStateMachineTrackingRecord(StateMachineStateRecord stateRecord)
        {
            if (stateRecord == null)
            {
                return;
            }

            // All commands are disabled when the state changes
            // They will be enabled when the state machine schedules them
            this.DisableAllCommands();

            this.CurrentState = stateRecord.StateName;
            this.atmViewModel.StateChanged(stateRecord.StateName);
        }

        /// <summary>
        /// Processes WorkflowInstanceRecords to notify the view model of PowerOn/Off events
        /// </summary>
        /// <param name="workflowInstanceRecord">
        /// The workflow instance record.
        /// </param>
        private void ProcessWorkflowInstanceRecord(WorkflowInstanceRecord workflowInstanceRecord)
        {
            switch (workflowInstanceRecord.State)
            {
                case "Started":
                    this.atmViewModel.Notify(AtmTransition.PowerOn, null);
                    break;
                case "Completed":
                    this.atmViewModel.Notify(AtmTransition.PowerOff, null);
                    break;
                case "Canceled":
                    this.atmViewModel.Notify(AtmTransition.PowerOff, null);
                    break;
            }
        }

        /// <summary>
        /// The resume transition.
        /// </summary>
        /// <param name="cmd">
        /// The transition.
        /// </param>
        /// <param name="data">
        /// The data to resume with.
        /// </param>
        private void ResumeCommand(AtmTransition cmd, object data)
        {
            this.workflowBusy.Reset();

            var result = this.AtmWorkflowHost.ResumeBookmark(cmd.ToString(), new AtmTransitionResult { Data = data });
            switch (result)
            {
                case BookmarkResumptionResult.NotFound:
                    throw new InvalidOperationException(
                        string.Format(
                            "The StateMachine is not waiting for the transition {0} right now.  Make sure you added a transition with the correct WaitForTransition value", 
                            cmd));
                case BookmarkResumptionResult.NotReady:
                    throw new InvalidOperationException(string.Format("The StateMachine is not ready to handle the transition {0}", cmd));
            }
        }

        /// <summary>
        /// The trace helper write.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private void WriteTrace(TraceLevel info, string format, params object[] args)
        {
            this.atmViewModel.Write(info, format, args);
        }

        #endregion
    }
}