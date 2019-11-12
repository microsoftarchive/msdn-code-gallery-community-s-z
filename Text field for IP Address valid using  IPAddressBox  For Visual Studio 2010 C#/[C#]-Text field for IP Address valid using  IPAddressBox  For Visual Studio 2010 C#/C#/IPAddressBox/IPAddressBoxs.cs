using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Net;

using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace IPAddressBox
{
    public abstract class IPAddressBoxs : TextBox
    {
        private System.ComponentModel.IContainer components;
        public ErrorProvider errorProvider1;
        public ErrorProvider NoErrorProvider;
        public TextBox textBox;

   
    [StructLayout(LayoutKind.Sequential)]
    public struct Nmhdr
    {
        public IntPtr HWndFrom;
        public UIntPtr IdFrom;
        public int Code;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NmIPAddress
    {
        public Nmhdr Hdr;
        public int Field;
        public int Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InitCommonControlsEX
    {
        public int Size;
        public int Icc;
    }

    public enum IPField
    {
        OctetOne = 0,
        OctetTwo = 1,
        OctetThree = 2,
        OctetFour = 3
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPAddressBoxs));
        this.textBox = new System.Windows.Forms.TextBox();
        this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
        this.NoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.NoErrorProvider)).BeginInit();
        this.SuspendLayout();
        // 
        // textBox
        // 
        this.textBox.Location = new System.Drawing.Point(0, 0);
        this.textBox.Name = "textBox";
        this.textBox.Size = new System.Drawing.Size(100, 20);
        this.textBox.TabIndex = 0;
        // 
        // errorProvider1
        // 
        this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
        this.errorProvider1.RightToLeft = true;
        // 
        // NoErrorProvider
        // 
        this.NoErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        this.NoErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("NoErrorProvider.Icon")));
        this.NoErrorProvider.RightToLeft = true;
        this.ResumeLayout(false);

    }
    public delegate void FieldChangedHandler(object sender, FieldChangedEventArgs e);
   
    public class FieldChangedEventArgs : EventArgs
    {
        public FieldChangedEventArgs(int field, int value)
        {
            Field = field;
            Value = value;
        }

        public int Field { get; private set; }
        public int Value { get; private set; }
    }
 [ToolboxBitmap(typeof(IPAddressControl), "app.bmp")]
    public class IPAddressControl : TextBox
    {
        ErrorProvider err = new ErrorProvider();
        ErrorProvider ok = new ErrorProvider();

        private const int WM_NOTIFY = 0x004E,
            WM_USER = 0x0400,
            WM_REFLECT = WM_USER + 0x1C00,
            IPM_SETRANGE = (WM_USER + 103),
            IPM_GETADDRESS = (WM_USER + 102),
            IPM_SETADDRESS = (WM_USER + 101),
            IPM_CLEARADDRESS = (WM_USER + 100),
            IPM_ISBLANK = (WM_USER + 105),
            ICC_INTERNET_CLASSES = 0x00000800;

        private readonly int[] values = new int[4];

        public IPAddressControl()
        {
            for (var i = 0; i < 4; i++)
                values[i] = 0;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var ic = new InitCommonControlsEX();
                ic.Size = Marshal.SizeOf(typeof(InitCommonControlsEX));
                ic.Icc = ICC_INTERNET_CLASSES;
                if (InitCommonControlsEx(ref ic))
                {
                    var cp = base.CreateParams;
                    cp.ClassName = "SysIPAddress32";
                    cp.Height = 23;
                    return cp;
                }
                return base.CreateParams;
            }
        }

        public IPAddress IPAddress
        {
            get { return IPAddress.Parse(Text); }
        }

        public bool IsBlank
        {
            get
            {
                var m = Message.Create(Handle, IPM_ISBLANK, IntPtr.Zero, IntPtr.Zero);
                WndProc(ref m);
                return m.Result.ToInt32() > 0;
            }
        }

        public event FieldChangedHandler FieldChanged;

        [DllImport("comctl32")]
        private static extern bool InitCommonControlsEx(ref InitCommonControlsEX lpInitCtrls);

        protected virtual void OnFieldChanged(FieldChangedEventArgs e)
        {
            if (FieldChanged != null)FieldChanged(this, e);
        }

        public bool SetIPRange(IPField field, byte lowValue, byte highValue)
        {
            var m = Message.Create(Handle, IPM_SETRANGE, (IntPtr)((int)field), MakeRange(lowValue, highValue));
            WndProc(ref m); 
            return m.Result.ToInt32() > 0;
           
        }

        public new void Clear()
        {
            var m = Message.Create(Handle, IPM_CLEARADDRESS, IntPtr.Zero, IntPtr.Zero);
            WndProc(ref m);
        }

        private IPAddress GetIpAddress(IntPtr ip)
        {
            return new IPAddress(ip.ToInt64());
        }

     private IntPtr MakeRange(byte low, byte high)
     {
         return (IntPtr) ((high << 8) + low);
     }
        
        protected override void WndProc(ref Message m)
        {
          //  this.values[0].ToString(); 
           
            if (m.Msg == (WM_REFLECT + WM_NOTIFY))
            {
                var ipInfo = (NmIPAddress)Marshal.PtrToStructure(m.LParam, typeof(NmIPAddress));
                
                if (ipInfo.Hdr.Code == -860)
                {
                    if (values[ipInfo.Field] != ipInfo.Value)
                    {
                        values[ipInfo.Field] = ipInfo.Value;
                        OnFieldChanged(new FieldChangedEventArgs(ipInfo.Field, ipInfo.Value));
                       // err.SetError(this, "HH Only valid for Digit and dot =" + ipInfo.Value + "  values[ipInfo.Field] = " + values[ipInfo.Field]);

                        if (values[0] > 255 || values[1] > 255 || values[2] > 255 || values[3] > 255)
                        {
                            this.err.Icon = new Icon(this.err.Icon, 16, 16);
                            this.err.SetError(this, "Format IP address not valid, max Octet 255");
                            this.err.Icon = Icon.ExtractAssociatedIcon("WarningIP_war.ico");
                            this.err.SetIconPadding(this, 2);  
                        }
                        else
                        {
                            this.err.Clear();
                            err.SetError(this, "Format Ok"+ values[0] + " " + values[1] + " " + values[2] + " " + values[3]);
                            this.err.SetError(this, "Format IP  address is valid ");
                            this.err.Icon = Icon.ExtractAssociatedIcon("WarningIP_ok.ico");
                            this.err.Icon = new Icon(err.Icon, 16, 16);
                            this.err.SetIconPadding(this, 2);
                        }
                    }  
                }
                 
            }

            try
            {
                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + ": " + ex.Message + Environment.NewLine + m);
                
            }
        }
    }

}//
}//
