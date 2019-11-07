/**
    Copyright(c) Microsoft Open Technologies, Inc.All rights reserved.
    Modified by Michael Osthege (2016)
   The MIT License(MIT)
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files(the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions :
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
**/

using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace TCD.Controls.Keyboard
{
    public class KeyboardViewModel : ViewModel
    {
        #region Properties
        private Control _TargetBox;
        public Control TargetBox
        {
            get { return _TargetBox; }
            set
            {
                _TargetBox = value;
                Notify(nameof(IsEnabled));
                Notify(nameof(TargetBox));
            }
        }


        #region Keyboard States
        public bool IsEnabled { get { return TargetBox != null; } }

        private bool _IsCapsLock;
        /// <summary>
        /// Get/set whether the VirtualKeyboard is currently is Caps-Lock mode.
        /// </summary>
        public bool IsCapsLock
        {
            get
            {
                return _IsCapsLock;
            }
            set
            {
                if (value != _IsCapsLock)
                {
                    _IsCapsLock = value;
                    if (IsShiftLock)
                    {
                        IsShiftLock = false;
                    }
                    else
                    {
                        NotifyTheIndividualKeys(nameof(KeyModel.Text));
                    }
                    Notify(nameof(IsCapsLock));
                }
            }
        }

        /// <summary>
        /// Get/set whether the VirtualKeyboard is currently is Shift-Lock mode.
        /// </summary>
        public bool IsShiftLock
        {
            get
            {
                return KB.ShiftKey.IsInShiftState;
            }
            set
            {
                if (value != KB.ShiftKey.IsInShiftState)
                {
                    KB.ShiftKey.IsInShiftState = value;
                    NotifyTheIndividualKeys(nameof(KeyModel.Text));
                    Notify(nameof(IsShiftLock));
                }
            }
        }

        #endregion

        #region Layout and Key Assignments
        private KeyboardLayouts _Layout = KeyboardLayouts.English;
        public KeyboardLayouts Layout
        {
            get { return _Layout; }
            set
            {
                _Layout = value;
                KB = new KeyAssignmentSet(value);
                this.Notify(nameof(Layout));
            }
        }
        
        private KeyAssignmentSet _KeyAssignmentSet;
        public KeyAssignmentSet KB
        {
            get
            {
                if (_KeyAssignmentSet == null)
                    _KeyAssignmentSet = new KeyAssignmentSet(_Layout);
                return _KeyAssignmentSet;
            }
            private set
            {
                _KeyAssignmentSet = value;
                Notify(nameof(KB));
                IsCapsLock = false;
                Notify(nameof(IsShiftLock));
            }
        }

        #endregion

        
        
        

        


        /// <summary>
        /// Get the array of KeyModels from the KB that comprise the view-models for the keyboard key-buttons
        /// </summary>
        public KeyModel[] TheKeyModels
        {
            get
            {
                if (KB != null)
                    return KB.KeyAssignments;
                return null;
            }
        }

        #endregion

        #region Commands

        private RelayCommand backspaceCommand;
        public RelayCommand BackspaceCommand
        {
            get
            {
                if (backspaceCommand == null)
                {
                    backspaceCommand = new RelayCommand(delegate
                    {
                        if (TargetBox is TextBox)
                        {
                            TextBox box = (TargetBox as TextBox);
                            //the TextBox.SelectionStart property counts \r\n as one character, but indexing at the string level as two..
                            //therefore we will remove all \n occurences
                            string text = box.Text.Replace("\r", "");
                            if (text == null)
                                text = string.Empty;
                            //the following indices are with respect to the text variable, but NOT the TextBox.Text property!
                            int currentSelectionStart = box.SelectionStart;
                            int currentSelectionLength = box.SelectionLength;

                            //if text is selected, delete it
                            if (currentSelectionLength != 0)
                                box.Text = text.Remove(currentSelectionStart, currentSelectionLength);
                            //no text is selected -> remove the character left of the cursor
                            else if (currentSelectionStart > 0)
                            {
                                box.Text = text.Remove(currentSelectionStart - 1, 1);
                                box.SelectionStart = currentSelectionStart - 1;//move the cursor one position left
                            }
                        }
                        else if (TargetBox is PasswordBox)
                        {
                            PasswordBox box = (TargetBox as PasswordBox);
                            if (box.Password.Length > 0)
                                box.Password = box.Password.Remove(box.Password.Length - 1);
                        }
                    });
                }
                return backspaceCommand;
            }
        }

        private RelayCommand capsLockCommand;
        public RelayCommand CapsLockCommand
        {
            get
            {
                if (capsLockCommand == null)
                {
                    capsLockCommand = new RelayCommand(delegate
                    {
                        IsCapsLock = !IsCapsLock;
                    });
                }
                return capsLockCommand;
            }
        }

        private RelayCommand keyPressedCommand;
        public RelayCommand KeyPressedCommand
        {
            get
            {
                if (keyPressedCommand == null)
                {
                    keyPressedCommand = new RelayCommand(delegate (object arg)
                    {
                        if (TargetBox is TextBox)
                        {
                            TextBox box = (TargetBox as TextBox);
                            //the TextBox.SelectionStart property counts \r\n as one character, but indexing at the string level as two..
                            //therefore we will remove all \n occurences
                            string text = box.Text.Replace("\r", "");
                            if (text == null)
                                text = string.Empty;
                            //the following indices are with respect to the text variable, but NOT the TextBox.Text property!
                            int currentSelectionStart = box.SelectionStart;
                            int currentSelectionLength = box.SelectionLength;

                            //if text is selected, delete it
                            if (currentSelectionLength != 0)
                                text = text.Remove(currentSelectionStart, currentSelectionLength);

                            //insert the new character
                            box.Text = text.Insert(currentSelectionStart, (string)arg);
                            box.SelectionLength = 0;
                            box.SelectionStart = currentSelectionStart + 1;//move the cursor to behind the new character(s in case of return)
                        }
                        else if (TargetBox is PasswordBox)
                        {
                            PasswordBox box = (TargetBox as PasswordBox);
                            box.Password = box.Password += (string)arg;
                        }

                        //Return to un-shift mode if currently in shift mode
                        if (IsShiftLock)
                            IsShiftLock = false;
                    });
                }
                return keyPressedCommand;
            }
        }
        
        private RelayCommand shiftCommand;
        public RelayCommand ShiftCommand
        {
            get
            {
                if (shiftCommand == null)
                    shiftCommand = new RelayCommand((x) => ToggleShiftState());
                return shiftCommand;
            }
        }

        private RelayCommand _InvertLayoutCommand;
        public RelayCommand InvertLayoutCommand
        {
            get
            {
                if (_InvertLayoutCommand == null)
                    _InvertLayoutCommand = new RelayCommand(delegate
                    {
                        switch (_Layout)
                        {
                            case KeyboardLayouts.English: Layout = KeyboardLayouts.German; break;
                            case KeyboardLayouts.German: Layout = KeyboardLayouts.English; break;
                        }
                    });
                return _InvertLayoutCommand;
            }
        }

        #endregion Commands


        private OnScreenKeyBoard container = null;

        public KeyboardViewModel(OnScreenKeyBoard container)
        {
            this.container = container;
            KeyModel.theKeyboardViewModel = this;
        }

        /// <summary>
        /// Make the individual key-button view models notify their views that their properties have changed.
        /// </summary>
        public void NotifyTheIndividualKeys(string notificationText)
        {
            if (KB != null && KB.KeyAssignments != null)
            {
                if (notificationText != null)
                {
                    foreach (var keyModel in KB.KeyAssignments)
                    {
                        if (keyModel != null)
                        {
                            keyModel.Notify(notificationText);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Turn the shift-lock mode off if it's on, and on if it's off.
        /// </summary>
        public void ToggleShiftState()
        {
            if (IsShiftLock)
            {
                IsShiftLock = false;
            }
            else
            {
                IsShiftLock = true;
            }
        }

    }
}
