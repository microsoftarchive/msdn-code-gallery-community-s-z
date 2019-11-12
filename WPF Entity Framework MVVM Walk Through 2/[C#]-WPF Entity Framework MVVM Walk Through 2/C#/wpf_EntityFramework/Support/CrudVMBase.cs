using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using GalaSoft.MvvmLight.Messaging;
using wpf_EntityFramework.EntityData;
using System.Windows.Media;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections;
using Support;

namespace wpf_EntityFramework
{
    public class CrudVMBase : NotifyUIBase
    {
        protected SalesContext db = new SalesContext();
        protected object selectedEntity;
        protected object editEntity;
        public CommandVM SaveCmd { get; set; }
        public CommandVM QuitCmd { get; set; }
        protected void HandleCommand(CommandMessage action)
        {
            if (isCurrentView)
            {
                switch (action.Command)
                {
                    case CommandType.Insert:
                        InsertNew();
                        break;
                    case CommandType.Edit:
                        if (GotSomethingSelected())
                        {
                            EditCurrent();
                        }
                        break;
                    case CommandType.Delete:
                        if (GotSomethingSelected())
                        {
                            DeleteCurrent();
                        }
                        break;
                    case CommandType.Commit:
                        CommitUpdates();
                        break;
                    case CommandType.Refresh:
                        RefreshData();
                        editEntity = null;
                        selectedEntity = null;
                        break;
                    case CommandType.Quit:
                        Quit();
                        break;
                    case CommandType.None:
                        break;
                    default:
                        break;
                }
            }
        }
        private bool GotSomethingSelected()
        {
            bool OK = true;
            if (selectedEntity == null)
            {
                OK = false;
                ShowUserMessage("You must choose a record to work on");
            }
            return OK;
        }
        private Visibility throbberVisible = Visibility.Visible;
        public Visibility ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                RaisePropertyChanged();
            }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set 
            { 
                errorMessage = value;
                RaisePropertyChanged();
            }
        }
        protected void ShowUserMessage(string message)
        {
            UserMessage msg = new UserMessage { Message = message };
            Messenger.Default.Send<UserMessage>(msg);
        }
        protected virtual void Quit()
        {

        }
        protected virtual void InsertNew()
        {

        }
        protected virtual void EditCurrent()
        {

        }
        protected virtual void CommitUpdates()
        {
        }
        protected virtual void DeleteCurrent()
        {
        }

        protected virtual void RefreshData()
        {
            GetData();
            Messenger.Default.Send<UserMessage>(new UserMessage {Message="Data Refreshed" });
        }
        protected virtual void GetData()
        {
        }
        protected CrudVMBase()
        {
            GetData();
            Messenger.Default.Register<CommandMessage>(this, (action) => HandleCommand(action));
            Messenger.Default.Register<NavigateMessage>(this, (action) => CurrentUserControl(action));
            SaveCmd = new CommandVM
            {
                CommandDisplay = "Commit",
                IconGeometry = Application.Current.Resources["SaveIcon"] as Geometry,
                Message = new CommandMessage { Command = CommandType.Commit }
            };
            QuitCmd = new CommandVM
            {
                CommandDisplay = "Quit",
                IconGeometry = Application.Current.Resources["QuitIcon"] as Geometry,
                Message = new CommandMessage { Command = CommandType.Quit }
            };
        }
        protected bool isCurrentView = false;
        private void CurrentUserControl(NavigateMessage nm)
        {
            if (this.GetType() == nm.ViewModelType)
            {
                isCurrentView = true;
            }
            else
            {
                isCurrentView = false;
            }
        }
        // Used to control showing a pop up to edit an entity in
        private bool isInEditMode = false;
        public bool IsInEditMode
        {
            get
            {
                return isInEditMode;
            }
            set
            {
                isInEditMode = value;
                InEdit inEdit = new InEdit { Mode = value };
                Messenger.Default.Send<InEdit>(inEdit);
                RaisePropertyChanged();
            }
        }

    }
}
