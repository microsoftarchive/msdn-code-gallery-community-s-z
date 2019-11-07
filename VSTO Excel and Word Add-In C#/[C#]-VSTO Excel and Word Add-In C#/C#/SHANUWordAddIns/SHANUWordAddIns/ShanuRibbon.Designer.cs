namespace SHANUWordAddIns
{
    partial class ShanuRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ShanuRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnPDF = this.Factory.CreateRibbonButton();
            this.btnImage = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnPDF);
            this.group1.Items.Add(this.btnImage);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "SHANU Add-In";
            this.group1.Name = "group1";
            // 
            // btnPDF
            // 
            this.btnPDF.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPDF.Image = global::SHANUWordAddIns.Properties.Resources.pdfico;
            this.btnPDF.Label = "Export PDF";
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.ShowImage = true;
            this.btnPDF.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPDF_Click);
            // 
            // btnImage
            // 
            this.btnImage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnImage.Image = global::SHANUWordAddIns.Properties.Resources.iPhoto;
            this.btnImage.Label = "Add Image";
            this.btnImage.Name = "btnImage";
            this.btnImage.ShowImage = true;
            this.btnImage.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImage_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = global::SHANUWordAddIns.Properties.Resources.ordering;
            this.button1.Label = "Add Table";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // ShanuRibbon
            // 
            this.Name = "ShanuRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ShanuRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPDF;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal ShanuRibbon ShanuRibbon
        {
            get { return this.GetRibbon<ShanuRibbon>(); }
        }
    }
}
