using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsIDataErrorInfo
{
    public partial class Form1 : Form
    {
        ErrorProvider ep = new ErrorProvider();
        BindingSource bs = new BindingSource();
        Model model = new Model();
        UIObject uiobj = new UIObject();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            bs.DataSource = uiobj;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", bs, "A", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", bs, "B", true, DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", bs, "C", true, DataSourceUpdateMode.OnPropertyChanged));

            ep.ContainerControl = this;
            ep.DataSource = bs;

            //初期値設定
            uiobj.A = "";
            uiobj.B = "";
            uiobj.C = "";

            //初期値によるエラーをクリアしておく。
            uiobj.ClearErrorAll();

            uiobj.HasErrorChanged += uiobj_HasErrorChanged;
        }

        void uiobj_HasErrorChanged(bool hasError)
        {
            bttn_保存.Enabled = !hasError;
        }


        /// <summary>
        /// 保存ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttn_保存_Click(object sender, EventArgs e)
        {
            uiobj.ValidateAll();
            ep.UpdateBinding();

            if (uiobj.HasError)
            {
                MessageBox.Show("以下のエラーのため、保存されませんでした。\r\n\r\n" + uiobj.Error, "エラー有り", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                model.A = uiobj.A;
                model.B = int.Parse(uiobj.B);
                model.C = decimal.Parse(uiobj.C);

                MessageBox.Show("保存されました。");
            }
        }

    }
}
