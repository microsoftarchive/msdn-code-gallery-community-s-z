// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestAtmViewModel.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Tests
{
    using System;
    using System.Activities.Tracking;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    using AtmStateMachine.Activities;

    using Microsoft.Activities.UnitTesting.Tracking;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The test atm view model.
    /// </summary>
    internal class TestAtmViewModel : IAtmViewModel
    {
        #region Constants and Fields

        /// <summary>
        ///   The default timeout.
        /// </summary>
        public readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(2);

        /// <summary>
        ///   Camera control operations
        /// </summary>
        private readonly List<bool> cameraControl = new List<bool>();

        /// <summary>
        ///   The prompts.
        /// </summary>
        private readonly List<AtmPrompt> prompts = new List<AtmPrompt>();

        /// <summary>
        ///   The states.
        /// </summary>
        private readonly List<string> states = new List<string>();

        /// <summary>
        ///   The tracking participant.
        /// </summary>
        private readonly MemoryTrackingParticipant trackingParticipant = new MemoryTrackingParticipant();

        /// <summary>
        ///   The notifications.
        /// </summary>
        private readonly List<AtmTransition> transitions = new List<AtmTransition>();

        /// <summary>
        ///   The wait for transition.
        /// </summary>
        private readonly ManualResetEvent waitHandle = new ManualResetEvent(false);

        /// <summary>
        ///   The card reader results.
        /// </summary>
        private List<CardReaderResult> cardReaderResults = new List<CardReaderResult>();

        /// <summary>
        ///   The target state.
        /// </summary>
        private string targetState;

        /// <summary>
        ///   The target transition.
        /// </summary>
        private AtmTransition targetTransition;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets CameraControl.
        /// </summary>
        public List<bool> CameraControl
        {
            get
            {
                return this.cameraControl;
            }
        }

        /// <summary>
        ///   Gets or sets CardReaderResults.
        /// </summary>
        public List<CardReaderResult> CardReaderResults
        {
            get
            {
                return this.cardReaderResults;
            }

            set
            {
                this.cardReaderResults = value;
            }
        }

        /// <summary>
        ///   Gets Prompts.
        /// </summary>
        public List<AtmPrompt> Prompts
        {
            get
            {
                return this.prompts;
            }
        }

        /// <summary>
        ///   Gets Records.
        /// </summary>
        public TrackingRecordsList Records
        {
            get
            {
                return this.trackingParticipant.Records;
            }
        }

        /// <summary>
        ///   Gets or sets TargetState.
        /// </summary>
        public string TargetState
        {
            get
            {
                return this.targetState;
            }

            set
            {
                this.waitHandle.Reset();
                this.targetState = value;
            }
        }

        /// <summary>
        ///   Gets or sets targetTransition.
        /// </summary>
        public AtmTransition TargetTransition
        {
            get
            {
                return this.targetTransition;
            }

            set
            {
                this.waitHandle.Reset();
                this.targetTransition = value;
            }
        }

        /// <summary>
        ///   Gets TrackingParticipant.
        /// </summary>
        public TrackingParticipant TrackingParticipant
        {
            get
            {
                return this.trackingParticipant;
            }
        }

        /// <summary>
        ///   Gets Transitions.
        /// </summary>
        public List<AtmTransition> Transitions
        {
            get
            {
                return this.transitions;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Gets ClearCount.
        /// </summary>
        internal int ClearCount { get; private set; }

        /// <summary>
        ///   Gets States.
        /// </summary>
        internal List<string> States
        {
            get
            {
                return this.states;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.ClearCount++;
        }

        /// <summary>
        /// The control camera.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void ControlCamera(bool record)
        {
            this.CameraControl.Add(record);
        }

        /// <summary>
        /// The enable transition.
        /// </summary>
        /// <param name="transition">
        /// The transition.
        /// </param>
        public void EnableTransition(AtmTransition transition)
        {
            if (transition == this.TargetTransition)
            {
                this.waitHandle.Set();
            }
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="transition">
        /// The notification.
        /// </param>
        /// <param name="payload">
        /// The payload
        /// </param>
        public void Notify(AtmTransition transition, object payload)
        {
            this.transitions.Add(transition);
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="readerResult">
        /// The reader result.
        /// </param>
        public void Notify(CardReaderResult readerResult)
        {
            this.CardReaderResults.Add(readerResult);
        }

        /// <summary>
        /// The display prompt.
        /// </summary>
        /// <param name="prompt">
        /// The prompt.
        /// </param>
        public void Prompt(AtmPrompt prompt)
        {
            this.prompts.Add(prompt);
        }

        /// <summary>
        /// Runs an action and waits for the target state
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="state">
        /// The target state.
        /// </param>
        public void RunUntilTargetState(Action action, string state)
        {
            this.RunUntilTargetState(action, state, this.DefaultTimeout);
        }

        /// <summary>
        /// Runs an action and waits for the target state
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="state">
        /// The target state.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        public void RunUntilTargetState(Action action, string state, TimeSpan timeout)
        {
            this.TargetState = state;
            action();
            this.WaitForTargetState(timeout);
        }

        /// <summary>
        /// Runs an action and waits for the target transition to become enabled
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="atmTransition">
        /// The atm transition.
        /// </param>
        public void RunUntilTargetTransition(Action action, AtmTransition atmTransition)
        {
            this.RunUntilTargetTransition(action, atmTransition, this.DefaultTimeout);
        }

        /// <summary>
        /// Runs an action and waits for the target transition to become enabled
        /// </summary>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="atmTransition">
        /// The atm transition.
        /// </param>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        public void RunUntilTargetTransition(Action action, AtmTransition atmTransition, TimeSpan timeout)
        {
            this.TargetTransition = atmTransition;
            action();
            this.WaitForTargetTransitionEnabled(timeout);
        }

        /// <summary>
        /// The state changed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        public void StateChanged(string state)
        {
            this.states.Add(state);
            if (state == this.TargetState)
            {
                this.waitHandle.Set();
            }
        }

        /// <summary>
        /// The trace.
        /// </summary>
        /// <param name="testContext">
        /// The test Context.
        /// </param>
        public void Trace(TestContext testContext)
        {
            testContext.WriteLine("States count: {0}", this.States.Count);
            foreach (var state in this.States)
            {
                testContext.WriteLine("State: {0}", state);
            }

            testContext.WriteLine("Clear count: {0}", this.ClearCount);

            testContext.WriteLine("Prompts count: {0}", this.Prompts.Count);
            foreach (var prompt in this.Prompts)
            {
                testContext.WriteLine("Prompt: {0}", prompt.Text);
            }

            testContext.WriteLine("Transitions count: {0}", this.Transitions.Count);
            foreach (var transition in this.Transitions)
            {
                testContext.WriteLine("Transition: {0}", transition);
            }

            testContext.WriteLine("CameraControl count: {0}", this.CameraControl.Count);
            foreach (var record in this.CameraControl)
            {
                testContext.WriteLine("CameraControl record: {0}", record);
            }

            this.trackingParticipant.Trace();
        }

        /// <summary>
        /// The wait until target state.
        /// </summary>
        public void WaitForTargetState()
        {
            this.WaitForTargetState(this.DefaultTimeout);
        }

        /// <summary>
        /// The wait until target state.
        /// </summary>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <exception cref="TimeoutException">
        /// </exception>
        public void WaitForTargetState(TimeSpan timeout)
        {
            if (!this.waitHandle.WaitOne(timeout))
            {
                throw new TimeoutException(string.Format("Timeout while waiting for target state {0}", this.TargetState));
            }
        }

        /// <summary>
        /// The wait for transition enabled.
        /// </summary>
        /// <exception cref="TimeoutException">
        /// The transition did not enable before the timeout
        /// </exception>
        public void WaitForTargetTransitionEnabled()
        {
            this.WaitForTargetTransitionEnabled(this.DefaultTimeout);
        }

        /// <summary>
        /// The wait for transition enabled.
        /// </summary>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <exception cref="TimeoutException">
        /// The transition did not enable before the timeout
        /// </exception>
        public void WaitForTargetTransitionEnabled(TimeSpan timeout)
        {
            if (!this.waitHandle.WaitOne(timeout))
            {
                throw new TimeoutException(string.Format("Timeout while waiting for target transition {0}", this.TargetTransition));
            }
        }

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public void Write(TraceLevel level, string format, params object[] args)
        {
            Debug.WriteLine(string.Format("{0,3:0} {1}", Thread.CurrentThread.ManagedThreadId, string.Format(format, args)));
        }

        #endregion
    }
}