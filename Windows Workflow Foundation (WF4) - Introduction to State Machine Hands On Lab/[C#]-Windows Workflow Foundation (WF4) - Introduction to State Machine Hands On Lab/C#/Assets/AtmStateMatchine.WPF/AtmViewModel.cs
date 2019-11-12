// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmViewModel.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMatchine.WPF
{
    using System;
    using System.Activities.Tracking;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using AtmStateMachine.Activities;

    /// <summary>
    /// The atm wpf view model.
    /// </summary>
    public class AtmViewModel : IAtmViewModel, INotifyPropertyChanged
    {
        #region Constants and Fields

        /// <summary>
        ///   The atm machine.
        /// </summary>
        private readonly AtmMachine atmMachine;

        /// <summary>
        ///   The display rows
        /// </summary>
        private readonly string[] displayRow = new string[4];

        /// <summary>
        ///   The input buffer.
        /// </summary>
        private readonly StringBuilder inputBuffer = new StringBuilder();

        /// <summary>
        ///   The side button commands.
        /// </summary>
        private readonly AtmTransition[] sideButtonCommands = new AtmTransition[4];

        /// <summary>
        ///   Task for closing the workflow when the UI shuts down
        /// </summary>
        private Task closingTask;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "AtmViewModel" /> class.
        /// </summary>
        public AtmViewModel()
        {
            this.atmMachine = new AtmMachine(this);
            this.DisplayRow1 = "ATM Machine Simulator";
            this.Level = TraceLevel.Info;

            this.DebugEvents = new ObservableCollection<Tuple<string, string>>();

            // TODO remove this
            // Debug.Listeners.Add(this);
            this.ClearDebugEvents = new RelayCommand(this.ExecuteClearDebugEvents);
            this.PowerOnCommand = new RelayCommand(this.ExecutePowerOn, this.CanExecutePowerOn);
            this.PowerOffCommand = new RelayCommand(this.ExecutePowerOff, this.CanExecutePowerOff);
            this.InsertCardCommand = new RelayCommand(this.ExecuteInsertCard, this.CanExecuteInsertCard);
            this.RemoveCardCommand = new RelayCommand(this.ExecuteRemoveCard, this.CanExecuteRemoveCard);
            this.KeyPadCommand = new RelayCommand(this.ExecuteKeyPad, this.CanExecuteKeyPad);
            this.SideButtonCommand = new RelayCommand(this.ExecuteSideButton, this.CanExecuteSideButton);

            this.Write(TraceLevel.Info, "Click PowerOn to turn on the ATM machine");
        }

        #endregion

        #region Public Events

        /// <summary>
        ///   The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets CameraBrush.
        /// </summary>
        public Brush CameraBrush
        {
            get
            {
                return this.atmMachine.IsCameraOn() ? Brushes.Red : Brushes.Black;
            }
        }

        /// <summary>
        ///   Gets the ClearDebugEvents Command.
        /// </summary>
        public ICommand ClearDebugEvents { get; private set; }

        /// <summary>
        ///   Gets or sets DebugEvents.
        /// </summary>
        public ObservableCollection<Tuple<string, string>> DebugEvents { get; set; }

        /// <summary>
        ///   Gets or sets DisplayRow1.
        /// </summary>
        public string DisplayRow1
        {
            get
            {
                return this.displayRow[0];
            }

            set
            {
                this.displayRow[0] = value;
                this.NotifyChanged("DisplayRow1");
            }
        }

        /// <summary>
        ///   Gets or sets DisplayRow2.
        /// </summary>
        public string DisplayRow2
        {
            get
            {
                return this.displayRow[1];
            }

            set
            {
                this.displayRow[1] = value;
                this.NotifyChanged("DisplayRow2");
            }
        }

        /// <summary>
        ///   Gets or sets DisplayRow3.
        /// </summary>
        public string DisplayRow3
        {
            get
            {
                return this.displayRow[2];
            }

            set
            {
                this.displayRow[2] = value;
                this.NotifyChanged("DisplayRow3");
            }
        }

        /// <summary>
        ///   Gets or sets DisplayRow4.
        /// </summary>
        public string DisplayRow4
        {
            get
            {
                return this.displayRow[3];
            }

            set
            {
                this.displayRow[3] = value;
                this.NotifyChanged("DisplayRow4");
            }
        }

        /// <summary>
        ///   Gets InsertCardCommand.
        /// </summary>
        public ICommand InsertCardCommand { get; private set; }

        /// <summary>
        ///   Gets or sets KeyPadCommand.
        /// </summary>
        public ICommand KeyPadCommand { get; set; }

        /// <summary>
        ///   Gets or sets Level.
        /// </summary>
        public TraceLevel Level { get; set; }

        /// <summary>
        ///   Gets the PowerOff command
        /// </summary>
        public ICommand PowerOffCommand { get; private set; }

        /// <summary>
        ///   Gets the PowerOn command
        /// </summary>
        public ICommand PowerOnCommand { get; private set; }

        /// <summary>
        ///   Gets RemoveCardCommand.
        /// </summary>
        public ICommand RemoveCardCommand { get; private set; }

        /// <summary>
        ///   Gets or sets SideButtonCommand.
        /// </summary>
        public ICommand SideButtonCommand { get; set; }

        /// <summary>
        ///   Gets TrackingParticipant.
        /// </summary>
        public TrackingParticipant TrackingParticipant
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.DisplayRow1 = null;
            this.DisplayRow2 = null;
            this.DisplayRow3 = null;
            this.DisplayRow4 = null;
            this.Write(TraceLevel.Info, "View Clear");
        }

        /// <summary>
        /// The control camera.
        /// </summary>
        /// <param name="record">
        /// The record.
        /// </param>
        public void ControlCamera(bool record)
        {
            this.atmMachine.ControlCamera(record);
            this.NotifyChanged("CameraBrush");
        }

        /// <summary>
        /// The model has notified that a command should be enabled
        /// </summary>
        /// <param name="transition">
        /// The command.
        /// </param>
        public void EnableTransition(AtmTransition transition)
        {
            RequeryCommands();
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="transition">
        /// The atm notification.
        /// </param>
        /// <param name="payload">
        /// The transition payload
        /// </param>
        public void Notify(AtmTransition transition, object payload)
        {
            this.Write(TraceLevel.Info, "Transition Event {0}", transition);
        }

        /// <summary>
        /// The notify.
        /// </summary>
        /// <param name="readerResult">
        /// The reader result.
        /// </param>
        public void Notify(CardReaderResult readerResult)
        {
            this.Write(TraceLevel.Info, "Card Reader reports {0} with CardStatus {1}", readerResult.Event, readerResult.CardStatus);
        }

        /// <summary>
        /// The display DisplayRow1.
        /// </summary>
        /// <param name="prompt">
        /// The prompt.
        /// </param>
        public void Prompt(AtmPrompt prompt)
        {
            this.Write(TraceLevel.Info, "Prompt[{0}] {1}", prompt.Line, prompt.Text);

            var index = prompt.Line - 1;

            this.sideButtonCommands[index] = prompt.Transition;
            this.displayRow[index] = prompt.Text;

            this.NotifyChanged("DisplayRow" + prompt.Line);
            RequeryCommands();
        }

        /// <summary>
        /// The state changed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        public void StateChanged(string state)
        {
            this.Write(TraceLevel.Info, "State {0}", state);
            RequeryCommands();
        }

        /// <summary>
        /// The view closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args.
        /// </param>
        public void ViewClosed(object sender, EventArgs e)
        {
            // TODO
            if (this.closingTask != null)
            {
                this.closingTask.Wait();
            }
        }

        /// <summary>
        /// The view closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args.
        /// </param>
        public void ViewClosing(object sender, CancelEventArgs e)
        {
            // TODO
            if (this.atmMachine != null)
            {
                this.closingTask = this.atmMachine.TurnPowerOff();
            }
        }

        ///// <summary>
        ///// Adds a debug event to the list
        ///// </summary>
        ///// <param name="message">
        ///// The message.
        ///// </param>
        //public void Write(string message)
        //{
        //    this.WriteLine(message);
        //}

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
            if (level <= this.Level)
            {
                this.WriteLine(string.Format("{0,3:0} {1}", Thread.CurrentThread.ManagedThreadId, string.Format(format, args)));
            }
        }

        /// <summary>
        /// Adds a debug event to the list
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteLine(string message)
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke(
                    (Action)(() =>
                        {
                            message = message.TrimStart();
                            var firstSpace = message.IndexOf(' ');
                            var thread = message.Substring(0, firstSpace);
                            var text = message.Substring(firstSpace + 1);
                            this.DebugEvents.Add(new Tuple<string, string>(thread, text));
                            this.NotifyChanged("DebugEvents");
                        }));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The requery commands.
        /// </summary>
        private static void RequeryCommands()
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)CommandManager.InvalidateRequerySuggested);
            }
        }

        /// <summary>
        /// The append key pad.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void AppendKeyPad(object commandData)
        {
            this.inputBuffer.Append(commandData);
            this.DisplayRow3 = new string('*', this.inputBuffer.Length);
        }

        /// <summary>
        /// Determines if the InsertCard command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecuteInsertCard(object commandData)
        {
            return this.atmMachine.IsCurrentState(AtmState.InsertCard);
        }

        /// <summary>
        /// Determines if the KeyPad command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecuteKeyPad(object commandData)
        {
            if (!this.atmMachine.IsKeypadEnabled())
            {
                return false;
            }

            switch (commandData.ToString())
            {
                case "KeypadCancel":
                    return this.atmMachine.IsTransitionEnabled(commandData.ToString());
                case "KeypadEnter":
                    return this.inputBuffer.Length >= 4 && this.atmMachine.IsTransitionEnabled(commandData.ToString());
                default:
                    return this.atmMachine.IsCurrentState(AtmState.EnterPin);
            }
        }

        /// <summary>
        /// Determines if the PowerOff command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecutePowerOff(object commandData)
        {
            return this.atmMachine.PowerOn;
        }

        /// <summary>
        /// Determines if the PowerOn command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecutePowerOn(object commandData)
        {
            return !this.atmMachine.PowerOn;
        }

        /// <summary>
        /// Determines if the RemoveCard command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecuteRemoveCard(object commandData)
        {
            return this.atmMachine.IsCurrentState(AtmState.RemoveCard);
        }

        /// <summary>
        /// Determines if the SideButton command is enabled
        /// </summary>
        /// <param name="commandData">
        /// The command Data.
        /// </param>
        /// <returns>
        /// true if the command is enabled, false if not
        /// </returns>
        private bool CanExecuteSideButton(object commandData)
        {
            var cmd = this.GetSideButtonCommand(commandData).ToString();
            return this.atmMachine.IsTransitionEnabled(cmd);
        }

        /// <summary>
        /// The clear buffer.
        /// </summary>
        private void ClearBuffer()
        {
            this.inputBuffer.Clear();
            this.DisplayRow3 = null;
            this.NotifyChanged("DisplayRow3");
        }

        /// <summary>
        /// The execute clear debug events.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecuteClearDebugEvents(object commandData)
        {
            this.DebugEvents.Clear();
            this.NotifyChanged("DebugEvents");
        }

        /// <summary>
        /// The InsertCard.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecuteInsertCard(object commandData)
        {
            this.atmMachine.InsertCard(Convert.ToBoolean(commandData));
        }

        /// <summary>
        /// The KeyPad.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecuteKeyPad(object commandData)
        {
            switch (commandData.ToString())
            {
                case "KeypadEnter":
                    this.Write(TraceLevel.Info, "{0}", commandData);
                    this.ClearBuffer();
                    this.atmMachine.AcceptPin(this.inputBuffer.ToString());
                    break;
                case "KeypadClear":
                    this.Write(TraceLevel.Info, "{0}", commandData);
                    this.ClearBuffer();
                    break;
                case "KeypadCancel":
                    this.Write(TraceLevel.Info, "{0}", commandData);
                    this.ClearBuffer();
                    this.atmMachine.Cancel();
                    break;
                default:
                    this.Write(TraceLevel.Info, "KeyPad {0}", commandData);
                    this.AppendKeyPad(commandData);
                    break;
            }
        }

        /// <summary>
        /// The PowerOff.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecutePowerOff(object commandData)
        {
            this.atmMachine.TurnPowerOff();
        }

        /// <summary>
        /// The PowerOn.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecutePowerOn(object commandData)
        {
            this.atmMachine.TurnPowerOn();
        }

        /// <summary>
        /// The RemoveCard.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecuteRemoveCard(object commandData)
        {
            this.atmMachine.RemoveCard();
        }

        /// <summary>
        /// The ExecuteSideButton.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        private void ExecuteSideButton(object commandData)
        {
            switch (this.GetSideButtonCommand(commandData))
            {
                case AtmTransition.Withdraw:
                    this.atmMachine.Withdraw();
                    break;
                case AtmTransition.Deposit:
                    this.atmMachine.Deposit();
                    break;
                case AtmTransition.KeypadCancel:
                    break;
            }
        }

        /// <summary>
        /// The get side button command.
        /// </summary>
        /// <param name="commandData">
        /// The command data.
        /// </param>
        /// <returns>
        /// Returns the command associated with the side button
        /// </returns>
        private AtmTransition GetSideButtonCommand(object commandData)
        {
            var index = int.Parse(commandData.ToString()) - 1;
            return this.sideButtonCommands[index];
        }

        /// <summary>
        /// Notify that a property has changed
        /// </summary>
        /// <param name="property">
        /// The property that changed
        /// </param>
        private void NotifyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}