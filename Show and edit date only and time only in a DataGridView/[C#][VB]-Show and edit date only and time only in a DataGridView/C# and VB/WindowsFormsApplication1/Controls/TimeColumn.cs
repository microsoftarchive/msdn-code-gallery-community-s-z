using System;
using System.Windows.Forms;

public class TimeColumn : DataGridViewColumn
{
    public TimeColumn() : base()
    {
        base.CellTemplate = new CalendarCell1();
    }

    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
            if (!((value == null)) && !(value.GetType().IsAssignableFrom(typeof(CalendarCell1))))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        }
    }
}
public class CalendarCell1 : DataGridViewTextBoxCell
{
    public CalendarCell1()
    {
        this.Style.Format = "hh:mm tt";
    }
    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        CalendarEditingControl1 ctl = (CalendarEditingControl1)DataGridView.EditingControl;
        if (this.RowIndex >= 0)
        {
            if (!(object.ReferenceEquals(this.Value, DBNull.Value)))
            {
                if (this.Value != null)
                {
                    if (this.Value != "")
                    {
                        try
                        {
                            ctl.Value = DateTime.Parse(this.Value.ToString());
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }
    }
    public override System.Type EditType
    {
        get
        {
            return typeof(CalendarEditingControl1);
        }
    }
    public override System.Type ValueType
    {
        get
        {
            return typeof(DateTime);
        }
    }
    public override object DefaultNewRowValue
    {
        get
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
}
internal class CalendarEditingControl1 : DateTimePicker, IDataGridViewEditingControl
{
    private DataGridView dataGridViewControl;
    private bool valueIsChanged = false;
    private int rowIndexNum;

    public CalendarEditingControl1()
    {
        this.Format = DateTimePickerFormat.Time;
    }
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToShortTimeString();
        }
        set
        {
            if (value is string)
            {
                this.Value = DateTime.Parse(System.Convert.ToString(value));
            }
        }
    }
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return this.Value.ToShortTimeString();
    }
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.ShowUpDown = true;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
    }

    public int EditingControlRowIndex
    {
        get
        {
            return rowIndexNum;
        }
        set
        {
            rowIndexNum = value;
        }
    }

    public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
    {
        if (Keys.KeyCode == Keys.Left || Keys.KeyCode == Keys.Up || Keys.KeyCode == Keys.Down || Keys.KeyCode == Keys.Right || Keys.KeyCode == Keys.Home || Keys.KeyCode == Keys.End || Keys.KeyCode == Keys.PageDown || Keys.KeyCode == Keys.PageUp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PrepareEditingControlForEdit(bool selectAll)
    {
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

    public Cursor EditingControlCursor
    {
        get
        {
            return base.Cursor;
        }
    }

    protected override void OnValueChanged(System.EventArgs eventargs)
    {
        valueIsChanged = true;
        this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        base.OnValueChanged(eventargs);
    }
    Cursor IDataGridViewEditingControl.EditingPanelCursor
    {
        get
        {
            return this.IDataGridViewEditingControl_EditingPanelCursor;
        }
    }
    private Cursor IDataGridViewEditingControl_EditingPanelCursor
    {
        get //throw new Exception("The method or operation is not implemented."); }
        {
            return base.Cursor;
        }
    }
}