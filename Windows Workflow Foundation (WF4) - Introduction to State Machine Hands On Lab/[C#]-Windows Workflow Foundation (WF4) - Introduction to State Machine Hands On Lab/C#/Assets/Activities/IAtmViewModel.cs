// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAtmViewModel.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Activities.Tracking;
    using System.Diagnostics;

    /// <summary>
    /// The ATM view model interface
    /// </summary>
    /// <remarks>
    /// Implement this interface to provide a UI for the ATM Machine
    /// </remarks>
    public interface IAtmViewModel
    {
        #region Public Properties

        /// <summary>
        ///   Gets TrackingParticipant.
        /// </summary>
        TrackingParticipant TrackingParticipant { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Clear the view
        /// </summary>
        void Clear();

        /// <summary>
        /// The control camera.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        void ControlCamera(bool record);

        /// <summary>
        /// Enable the transition
        /// </summary>
        /// <param name="transition">
        /// The transition.
        /// </param>
        void EnableTransition(AtmTransition transition);

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="transition">
        /// The atm Transition.
        /// </param>
        /// <param name="payload">
        /// The payload of the notification
        /// </param>
        void Notify(AtmTransition transition, object payload);

        /// <summary>
        /// Notifies the view model about Card Reader events
        /// </summary>
        /// <param name="readerResult">
        /// The reader result.
        /// </param>
        void Notify(CardReaderResult readerResult);

        /// <summary>
        /// The display prompt.
        /// </summary>
        /// <param name="prompt">
        /// The prompt.
        /// </param>
        void Prompt(AtmPrompt prompt);

        /// <summary>
        /// The state changed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        void StateChanged(string state);

        /// <summary>
        /// Writes a trace message
        /// </summary>
        /// <param name="level">
        ///   The level.
        /// </param>
        /// <param name="format">
        ///   The enable transition.
        /// </param>
        /// <param name="args"></param>
        void Write(TraceLevel level, string format, params object[] args);

        #endregion
    }
}