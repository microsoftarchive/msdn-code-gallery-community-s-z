namespace SerialPortExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    
    public abstract class RestrictedUpDown : NumericUpDown
    {
        protected int[] baudRates = new int[2]{1,2};
        private int oldValue = 0;
        
        protected override void OnCreateControl()
        {
            base.Minimum = baudRates[0];
            base.Maximum = baudRates[baudRates.Length - 1];
            base.OnCreateControl();
        }
        protected override void OnValueChanged(EventArgs e)
        {
            if (!baudRates.Contains((int)this.Value) )
            {
                if ((int)this.Value > oldValue)
                    this.Value = baudRates.First(p => p > this.Value);
                else this.Value = baudRates.Last(p => p < this.Value);
            }
            base.OnValueChanged(e);
            oldValue = (int) this.Value;
        }
       
    }
    public class BaudRateUpDown : RestrictedUpDown
    {
        public BaudRateUpDown()
        {
            baudRates= new int[]{1200,1800,2400,4800,7200,9600,14400,19200,38400,57600,115200,128000};
        }
    }
    public class DataBits : RestrictedUpDown
    {
        public DataBits() :base()
        {
            baudRates = new int[] { 4, 5, 6, 7, 8 };
        }
    }
    public abstract class EnumComboBox<T> : ComboBox
    {
        
        protected override void OnCreateControl()
        {
            Type enumType = typeof(T);
            if (!this.DesignMode)
            {
                base.Items.Clear();
                foreach (var item in Enum.GetValues(enumType))
                {
                    base.Items.Add(item);
                }
                this.SelectedIndex = 0;
            }
            base.OnCreateControl();
        }

    }
    public class ParityComboBox : EnumComboBox<Parity> { }
    public class StopBitsComboBox : EnumComboBox<StopBits> { }
    public class HandShakeComboBox : EnumComboBox<Handshake> { }
    public class ComPortComboBox : ComboBox
    {
        protected override void OnCreateControl()
        {
            this.Items.Clear();
            if (!this.DesignMode)
            {
                this.Items.AddRange(SerialPort.GetPortNames());
                this.SelectedIndex = 0;
            }

            base.OnCreateControl();
        }
    }
}
