// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmMachineTests.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Tests
{
    using System;

    using AtmStateMachine.Activities;

    using Microsoft.Activities.UnitTesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// This is a test class for ProgramTest and is intended
    ///   to contain all ProgramTest Unit Tests
    /// </summary>
    [TestClass]
    public class AtmMachineTests
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets the test context which provides
        ///   information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Given
        ///   * The ATM Machine
        ///   * In the Enter Pin state
        ///   When
        ///   * An Keypad Cancel is pressed
        ///   Then        
        ///   * The StateMachine enters the Remove Card state
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 3
        /// </remarks>
        [TestMethod]
        public void EnterPinTriggerKeypadCancelToRemoveCard()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* The ATM Machine");
            this.TestContext.WriteLine("* In the Enter Pin state");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Keypad Cancel is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The StateMachine enters the Remove Card state");
            this.TestContext.WriteLine("Test scenario completed in Exercise 3");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.Cancel().WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the first three states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.RemoveCard);

                // Verify that you added an InitializeAtm activity to the Entry actions of the Initialize State
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadCancel, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", 
                    testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), 
                    Prompts.PleaseWait, 
                    Prompts.InsertCard, 
                    Prompts.EnterYourPin, 
                    Prompts.RemoveCard);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 2, "Verify that you added a ClearView activity to the Exit Action of the Initialize State");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * The ATM Machine
        ///   * In the Enter Pin state
        ///   When
        ///   * An Keypad Enter is pressed
        ///   Then        
        ///   * The StateMachine enters the Main Menu state
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 3
        /// </remarks>
        [TestMethod]
        public void EnterPinTriggerKeypadEnterToMainMenu()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* The ATM Machine");
            this.TestContext.WriteLine("* In the Enter Pin state");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Keypad Enter is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The StateMachine enters the Main Menu state");
            this.TestContext.WriteLine("Test scenario completed in Exercise 3");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the first three states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.MainMenu);

                // Verify that you added an InitializeAtm activity to the Entry actions of the Initialize State
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 3, "Verify that you added the ClearView activity to the Exit Action of states that require it");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * The ATM Machine
        ///   * In the Enter Pin state
        ///   When
        ///   * An Keypad Cancel is pressed
        ///   Then        
        ///   * The StateMachine enters the Remove Card state
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 3
        /// </remarks>
        [TestMethod]
        public void EnterPinTriggerTimeoutToRemoveCard()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* The ATM Machine");
            this.TestContext.WriteLine("* In the Enter Pin state");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Keypad Cancel is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The StateMachine enters the Remove Card state");
            this.TestContext.WriteLine("Test scenario completed in Exercise 3");

            var testViewModel = new TestAtmViewModel();

            // Create with a very short timeout
            var atmMachine = new AtmMachine(testViewModel) { AtmTimeout = TimeSpan.FromMilliseconds(100) };

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Wait for the workflow to get to the Remove Card state
                atmMachine.WaitForState(AtmState.RemoveCard);

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the first three states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.RemoveCard);

                // Verify that you added an InitializeAtm activity to the Entry actions of the Initialize State
                AssertHelper.OccursInOrder("Transitions", testViewModel.Transitions, AtmTransition.PowerOn, AtmTransition.CardInserted, AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 2, "Verify that you added a ClearView activity to the Exit Action of the Initialize State");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * The ATM Machine
        ///   * In the Insert Card state
        ///   When
        ///   * An invalid card is inserted
        ///   Then
        ///   * the camera is turned on
        ///   * The StateMachine enters the RemoveCard state 
        ///   * and displays prompt "Error reading card, Please remove your card"
        ///   * and waits for the user to remove their card
        ///   * and then turns off the camera
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 2
        /// </remarks>
        [TestMethod]
        public void InsertInvalidCard()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* The ATM Machine");
            this.TestContext.WriteLine("* In the Insert Card state");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An invalid card is inserted");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* the camera is turned on");
            this.TestContext.WriteLine("* The StateMachine enters the RemoveCard state ");
            this.TestContext.WriteLine("* and displays prompt Error reading card, Please remove your card");
            this.TestContext.WriteLine("* and waits for the user to remove their card");
            this.TestContext.WriteLine("* and then turns off the camera");
            this.TestContext.WriteLine("Test scenario completed in Exercise 2");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Run the insert card scenario
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an invalid card
                atmMachine.InsertCard(false).WaitForWorkflow();

                // Remove the card
                atmMachine.RemoveCard().WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.RemoveCard, AtmState.InsertCard);

                // Verify that you added an InitializeAtm activity to the Entry actions of the Initialize State
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.CardRemoved, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", 
                    testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), 
                    Prompts.PleaseWait, 
                    Prompts.InsertCard, 
                    Prompts.ErrRemoveCard, 
                    Prompts.InsertCard);

                // Verify the invalid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Invalid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 2, "Verify that you added a ClearView activity to the Exit Action of the Initialize State");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true, false);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * The ATM Machine
        ///   * In the Insert Card state
        ///   When
        ///   * An valid card is inserted
        ///   Then
        ///   * the camera is turned on
        ///   * The StateMachine enters the Enter Pin state 
        ///   * and displays prompt "Enter your pin"
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 2
        /// </remarks>
        [TestMethod]
        public void InsertValidCard()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* The ATM Machine");
            this.TestContext.WriteLine("* In the Insert Card state");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An valid card is inserted");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* the camera is turned on");
            this.TestContext.WriteLine("* The StateMachine enters the Enter Pin state ");
            this.TestContext.WriteLine("* and displays prompt Enter your pin");
            this.TestContext.WriteLine("Test scenario completed in Exercise 2");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on an wait for the CardInserted transition to enable
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert a valid card and wait for the KeypadEnter transition
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the first three states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder("ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin);

                // Verify that you added an InitializeAtm activity to the Entry actions of the Initialize State
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 2, "Verify that you added a ClearView activity to the Exit Action of the Initialize State");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * A Powered Off ATM
        ///   When
        ///   * The Power Is Turned On
        ///   Then
        ///   * The ATM displays a please wait message.
        ///   * and initializes the hardware 
        ///   * After initialization it prompts the user to insert a card
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 1
        /// </remarks>
        [TestMethod]
        public void PowerOnAtmScenario()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* A Powered Off ATM");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* The Power Is Turned On");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The ATM displays a please wait message.");
            this.TestContext.WriteLine("* and initializes the hardware ");
            this.TestContext.WriteLine("* After initialization it prompts the user to insert a card");
            this.TestContext.WriteLine("Test scenario completed in Exercise 1");

            var testViewModel = new TestAtmViewModel();
            var target = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on an wait for the CardInserted transition to enable
                target.TurnPowerOn().WaitForWorkflow();

                // Turn it off and wait for the power off to complete
                target.TurnPowerOff().Wait();

                // Verify the first three states occurred in the correct order.
                // Make sure you set the state name correctly
                AssertState.OccursInOrder("ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard);

                // Verify the prompts
                AssertHelper.OccursInOrder("Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 2, "Verify that you added a ClearView activity to the Exit Action of the Initialize State");
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * A user is viewing the transaction menu
        ///   When
        ///   * An Keypad Cancel is pressed
        ///   Then        
        ///   * The transaction menu should exit
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 4
        /// </remarks>
        [TestMethod]
        public void TransactionMenuKeypadCancel()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* A user is viewing the transaction menu");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Keypad Cancel is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The transaction menu should exit");
            this.TestContext.WriteLine("Test scenario completed in Exercise 4");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Cancel at the transaction menu
                atmMachine.Cancel().WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the states
                AssertState.OccursInOrder(
                    "Transaction Menu StateMachine", testViewModel.Records, TransactionMenuState.TransactionMenu, TransactionMenuState.Exit);

                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.MainMenu);

                // Verify the transitions
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.KeypadCancel, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 4, "Verify that you added the ClearView activity to the Exit Action of states that require it");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * A user is at the transaction menu
        ///   When
        ///   * the Keypad Cancel button is pressed
        ///   Then        
        ///   * The transaction menu should enter the exit state
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 4
        /// </remarks>
        [TestMethod]
        public void TransactionMenuTimeout()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* A user is at the transaction menu");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* the Keypad Cancel button is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The transaction menu should enter the exit state");
            this.TestContext.WriteLine("Test scenario completed in Exercise 4");

            var testViewModel = new TestAtmViewModel();

            // Create with a very short timeout
            var atmMachine = new AtmMachine(testViewModel) { AtmTimeout = TimeSpan.FromMilliseconds(100) };

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Wait for the workflow to get to the Remove Card state
                atmMachine.WaitForState(AtmState.RemoveCard);

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the states
                AssertState.OccursInOrder(
                    "Transaction Menu StateMachine", testViewModel.Records, TransactionMenuState.TransactionMenu, TransactionMenuState.Exit);

                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.MainMenu);

                // Verify the transitions
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 4, "Verify that you added the ClearView activity to the Exit Action of states that require it");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * A user is at the transaction menu
        ///   When
        ///   * An Button1 is pressed
        ///   Then        
        ///   * The transaction menu should enter the Deposit state and immediately  
        ///   * transition to the exit state via a null transition
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 4
        /// </remarks>
        [TestMethod]
        public void TransactionMenuToDeposit()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* A user is at the transaction menu");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Button1 is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The transaction menu should enter the Deposit state and immediately");
            this.TestContext.WriteLine("* transition to the exit state via a null transition");
            this.TestContext.WriteLine("Test scenario completed in Exercise 4");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Press button 3
                atmMachine.Deposit().WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the states
                AssertState.OccursInOrder(
                    "Transaction Menu StateMachine", 
                    testViewModel.Records, 
                    TransactionMenuState.TransactionMenu, 
                    TransactionMenuState.Deposit, 
                    TransactionMenuState.Exit);

                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.MainMenu);

                // Verify the transitions
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.Deposit, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 4, "Verify that you added the ClearView activity to the Exit Action of states that require it");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        /// <summary>
        /// Given
        ///   * A user is at the transaction menu
        ///   When
        ///   * An Button1 is pressed
        ///   Then        
        ///   * The transaction menu should enter the Withdraw state and immediately  
        ///   * transition to the exit state via a null transition
        /// </summary>
        /// <remarks>
        /// Test scenario completed in Exercise 4
        /// </remarks>
        [TestMethod]
        public void TransactionMenuToWithdraw()
        {
            this.TestContext.WriteLine("Given");
            this.TestContext.WriteLine("* A user is at the transaction menu");
            this.TestContext.WriteLine("When");
            this.TestContext.WriteLine("* An Button1 is pressed");
            this.TestContext.WriteLine("Then");
            this.TestContext.WriteLine("* The transaction menu should enter the Withdraw state and immediately");
            this.TestContext.WriteLine("* transition to the exit state via a null transition");
            this.TestContext.WriteLine("Test scenario completed in Exercise 4");

            var testViewModel = new TestAtmViewModel();
            var atmMachine = new AtmMachine(testViewModel);

            try
            {
                // Turn the power on
                atmMachine.TurnPowerOn().WaitForWorkflow();

                // Insert an valid card
                atmMachine.InsertCard(true).WaitForWorkflow();

                // Enter a pin ends with Keypad Enter
                atmMachine.AcceptPin("1234").WaitForWorkflow();

                // Press button 1
                atmMachine.Withdraw().WaitForWorkflow();

                // Turn off the ATM
                atmMachine.TurnPowerOff().Wait();

                // Verify the states
                AssertState.OccursInOrder(
                    "Transaction Menu StateMachine", 
                    testViewModel.Records, 
                    TransactionMenuState.TransactionMenu, 
                    TransactionMenuState.Withdraw, 
                    TransactionMenuState.Exit);

                AssertState.OccursInOrder(
                    "ATM StateMachine", testViewModel.Records, AtmState.Initialize, AtmState.InsertCard, AtmState.EnterPin, AtmState.MainMenu);

                // Verify the transitions
                AssertHelper.OccursInOrder(
                    "Transitions", 
                    testViewModel.Transitions, 
                    AtmTransition.PowerOn, 
                    AtmTransition.CardInserted, 
                    AtmTransition.KeypadEnter, 
                    AtmTransition.Withdraw, 
                    AtmTransition.PowerOff);

                // Verify the prompts
                AssertHelper.OccursInOrder(
                    "Prompts", testViewModel.Prompts.ConvertAll((prompt) => prompt.Text), Prompts.PleaseWait, Prompts.InsertCard, Prompts.EnterYourPin);

                // Verify the valid card
                Assert.AreEqual(1, testViewModel.CardReaderResults.Count);
                Assert.AreEqual(CardStatus.Valid, testViewModel.CardReaderResults[0].CardStatus);

                // Verify the exit action cleared the screen at least twice
                Assert.IsTrue(testViewModel.ClearCount >= 4, "Verify that you added the ClearView activity to the Exit Action of states that require it");

                // Verify the camera control
                AssertHelper.OccursInOrder("CameraControl", testViewModel.CameraControl, true);
            }
            finally
            {
                testViewModel.Trace(this.TestContext);
            }
        }

        #endregion
    }
}