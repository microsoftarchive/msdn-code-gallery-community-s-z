// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmTransition.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    /// <summary>
    /// The atm transition.
    /// </summary>
    public enum AtmTransition
    {
        /// <summary>
        ///   No transition
        /// </summary>
        None, 

        /// <summary>
        ///   The enter pin.
        /// </summary>
        KeypadEnter, 

        /// <summary>
        ///   The withdraw.
        /// </summary>
        Withdraw, 

        /// <summary>
        ///   The deposit.
        /// </summary>
        Deposit, 

        /// <summary>
        ///   The cancel.
        /// </summary>
        KeypadCancel, 

        /// <summary>
        ///   A valid card was detected in the card reader.
        /// </summary>
        CardInserted, 

        /// <summary>
        ///   The card reader reports the card was removed.
        /// </summary>
        CardRemoved, 

        /// <summary>
        /// The ATM has powered off.
        /// </summary>
        PowerOff, 

        /// <summary>
        /// The ATM has powered on.
        /// </summary>
        PowerOn
    }   
}