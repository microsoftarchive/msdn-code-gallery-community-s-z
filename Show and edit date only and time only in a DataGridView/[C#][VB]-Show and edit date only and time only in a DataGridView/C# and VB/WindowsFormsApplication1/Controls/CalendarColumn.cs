using System;
using System.Windows.Forms;

/// <summary>
/// Originally done by Microsoft, Kevin Gallagher added code so we can handle NULL values
/// </summary>
/// <remarks></remarks>
public class CalendarColumn : DataGridViewColumn
{
    public CalendarColumn() : base(new CalendarCell())
    {
    }
    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
            // Ensure that the cell used for the template is a CalendarCell.
            if (value != null && !(value.GetType().IsAssignableFrom(typeof(CalendarCell))))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        }
    }
}
public class CalendarCell : DataGridViewTextBoxCell
{
    public CalendarCell()
    {
        this.Style.Format = "d"; // Use the short date format.
        this.EmptyDate = DateTime.Now;
    }

    public DateTime EmptyDate { get; set; }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        CalendarEditingControl TheControl = (CalendarEditingControl)DataGridView.EditingControl;

        if (Convert.IsDBNull(this.Value) || (this.Value == null))
        {
            TheControl.Value = DateTime.Now;
        }
        else
        {
            TheControl.Value = Convert.ToDateTime(this.Value);
        }

    }
    public override Type EditType
    {
        get
        {
            // Return the type of the editing contol that CalendarCell uses.
            return typeof(CalendarEditingControl);
        }
    }
    public override Type ValueType
    {
        get
        {
            // Return the type of the value that CalendarCell contains.
            return typeof(DateTime);
        }
    }
    public override object DefaultNewRowValue
    {
        get
        {
            // Use the current date and time as the default value.
            return DateTime.Now;
        }
    }
}
/// <summary>
/// Provides Calendar popup within the GridView.
/// </summary>
/// <remarks></remarks>
internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
{
    private DataGridView dataGridViewControl;
    private bool valueIsChanged = false;
    private int rowIndexNumber;

    public CalendarEditingControl()
    {
        this.Format = DateTimePickerFormat.Short;
    }

    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortDateString();
        }

        set
        {
            if (value is string)
            {
                this.Value = DateTime.Parse(Convert.ToString(value));
            }
        }
    }
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return this.Value.ToString();
    }
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }
    public int EditingControlRowIndex
    {
        get
        {
            return rowIndexNumber;
        }
        set
        {
            rowIndexNumber = value;
        }
    }
    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    {
        // Let the DateTimePicker handle the keys listed.
        //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
        //		Select Case key And Keys.KeyCode
        //ORIGINAL LINE: Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
        if (((key & Keys.KeyCode) == Keys.Left) || ((key & Keys.KeyCode) == Keys.Up) || ((key & Keys.KeyCode) == Keys.Down) || ((key & Keys.KeyCode) == Keys.Right) || ((key & Keys.KeyCode) == Keys.Home) || ((key & Keys.KeyCode) == Keys.End) || ((key & Keys.KeyCode) == Keys.PageDown) || ((key & Keys.KeyCode) == Keys.PageUp))
        {
            return true;
        }
        //ORIGINAL LINE: Case Else
        else
        {
            return false;
        }
    }
    public void PrepareEditingControlForEdit(bool selectAll)
    {
        // No preparation needs to be done.
    }
    public bool RepositionEditingControlOnValueChange
    {
        get
        {
            return false;
        }
    }
    public DataGridView EditingControlDataGridView
    {
        get
        {
            return dataGridViewControl;
        }
        set
        {
            dataGridViewControl = value;
        }
    }
    public bool EditingControlValueChanged
    {
        get
        {
            return valueIsChanged;
        }
        set
        {
            valueIsChanged = value;
        }
    }
    Cursor IDataGridViewEditingControl.EditingPanelCursor
    {
        get
        {
            return this.EditingControlCursor;
        }
    }
    public Cursor EditingControlCursor
    {
        get
        {
            return base.Cursor;
        }
    }
    protected override void OnValueChanged(EventArgs eventargs)
    {
        // Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
}