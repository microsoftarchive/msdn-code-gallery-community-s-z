// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmState.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{

    /// <summary>
    /// The Transaction Menu States
    /// </summary>
    /// <remarks>
    /// The AtmMachine class uses these strings to map to state names. The names must match exactly.
    /// </remarks>
    public static class TransactionMenuState
    {
        public const string TransactionMenu = "Transaction Menu";
        public const string Exit = "Exit";
        public const string Withdraw = "Withdraw";
        public const string Deposit = "Deposit";
    }

    /// <summary>
    /// The StateMachine States.
    /// </summary>
    /// <remarks>
    /// The AtmMachine class uses these strings to map to state names. The names must match exactly.
    /// </remarks>
    public static class AtmState
    {
        #region Constants and Fields

        /// <summary>
        ///   The ATM is waiting for the customer to enter a PIN.
        /// </summary>
        public const string EnterPin = "Enter PIN";

        /// <summary>
        ///   The ATM is off.
        /// </summary>
        public const string FinalState = "Final State";

        /// <summary>
        ///   The ATM is initializing.
        /// </summary>
        public const string Initialize = "Initialize";

        /// <summary>
        ///   The ATM is prompting to insert card.
        /// </summary>
        public const string InsertCard = "Insert Card";

        /// <summary>
        ///   The ATM is prompting to remove card.
        /// </summary>
        public const string RemoveCard = "Remove Card";

        /// <summary>
        /// The main menu.
        /// </summary>
        public const string MainMenu = "Main Menu";

        #endregion
    }
}