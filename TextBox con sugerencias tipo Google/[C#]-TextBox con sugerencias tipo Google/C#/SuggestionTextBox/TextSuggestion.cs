using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuggestionTextBox
{
    public class TextSuggestion: TextBox
    {

        #region Variables privadas

        private ListBox _listBox;
        private bool _listBoxAddedToForm = false;

        private Func<object, string, bool> _matchElement;
        private Func<object, string> _textFromElement;

        #endregion

        #region Constructor

        public TextSuggestion(): base() 
        {
            MaxNumOfSuggestions = 10;
            _listBox = new ListBox();
            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;
            LostFocus += this_LostFocus;
            _listBox.Click += listBox_Click;
        }

        #endregion

        #region Propiedades públicas

        [DefaultValue(10)]
        public int MaxNumOfSuggestions { get; set; }

        public IEnumerable<object> SuggestDataSource { get; set; }

        public Func<object, string ,bool> MatchElement
        {
            get
            {
                if (_matchElement == null)
                {
                    if (SuggestDataSource.GetType().GetGenericArguments()[0].IsAssignableFrom(typeof(string)))
                        return delegate(object element, string text) { 
                            return ((string)element).StartsWith(text, StringComparison.OrdinalIgnoreCase); 
                        };
                    else
                        return delegate(object element, string text) { 
                            return element.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase); 
                        };
                }
                else
                    return _matchElement;
            }
            set
            {
                _matchElement = value;
            }
        }

        public Func<object, string> TextFromElement
        {
            get
            {
                if (_textFromElement == null)
                {
                    if (SuggestDataSource.GetType().GetGenericArguments()[0].IsAssignableFrom(typeof(string)))
                        return delegate(object element) { return (string)element; };
                    else
                        return delegate(object element) { return element.ToString(); };
                }
                else
                    return _textFromElement;
            }
            set
            {
                _textFromElement = value;
            }
        }

        #endregion

        #region ListBox

        private void ShowListBox()
        {
            if (!_listBoxAddedToForm)
            {
                this.TopLevelControl.Controls.Add(_listBox);
                Point controlLocation = this.TopLevelControl.PointToClient(this.Parent.PointToScreen(this.Location));
                _listBox.Left = controlLocation.X;
                _listBox.Top = controlLocation.Y + this.Height;
                _listBox.Font = this.Font;
                _listBox.Width = this.Width;
                _listBox.MinimumSize = new Size(this.Width, _listBox.MinimumSize.Height);
                _listBox.Height = _listBox.ItemHeight * (MaxNumOfSuggestions + 1);
                _listBoxAddedToForm = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
        }

        private void HideListBox() { _listBox.Visible = false; }

        private void UpdateListBox() 
        {
            if (SuggestDataSource != null && !string.IsNullOrEmpty(this.Text))
            {
                IEnumerable<string> result = SuggestDataSource
                    .Where(item => MatchElement(item, this.Text)
                        && !TextFromElement(item).Equals(this.Text, StringComparison.OrdinalIgnoreCase))
                    .Select(item => TextFromElement(item))
                    .OrderBy(s => s)
                    .Take(MaxNumOfSuggestions);
                if (result.Count() > 0)
                {
                    _listBox.DataSource = result.ToList();
                    ShowListBox();
                }
                else
                    HideListBox();
            }
            else
                HideListBox();
        }

        private void listBox_Click(object sender, EventArgs e)
        {
            if (_listBox.SelectedIndex >= 0)
                Text = _listBox.SelectedItem.ToString();
            HideListBox();
        }

        #endregion

        #region LostFocus

        protected override void OnLostFocus(EventArgs e)
        {
            if (!_listBox.ContainsFocus)
                base.OnLostFocus(e);
        }

        private void this_LostFocus(object sender, EventArgs e)
        {
            HideListBox();
        }

        #endregion

        #region Entrada de teclado

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (_listBox.Visible && _listBox.SelectedIndex >= 0)
                            _listBox.SelectedIndex--;
                        e.SuppressKeyPress = true;
                        break;
                    }
                case Keys.Enter:
                    {
                        if (_listBox.Visible)
                        {
                            if (_listBox.SelectedIndex >= 0)
                            {
                                Text = _listBox.SelectedItem.ToString();
                                SelectAll();
                            }
                            HideListBox();
                            e.SuppressKeyPress = true;
                        }
                        break;
                    }
            }
        }

        string _lastText;
        private void this_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Text != _lastText)
            {
                UpdateListBox();
                _lastText = this.Text;
            }
        }

        #endregion

        #region Ocultar propiedades de autocompletar

        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }

        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteMode AutoCompleteMode { get; set; }

        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AutoCompleteSource AutoCompleteSource { get; set; }

        #endregion

    }
}
