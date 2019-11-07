namespace Microsoft.Example.Circuits.DslPackage
{
  partial class WrappingForm
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.DiagramPanel = new System.Windows.Forms.Panel();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // DiagramPanel
      // 
      this.DiagramPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.DiagramPanel.Location = new System.Drawing.Point(4, 4);
      this.DiagramPanel.Name = "DiagramPanel";
      this.DiagramPanel.Size = new System.Drawing.Size(664, 608);
      this.DiagramPanel.TabIndex = 0;
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(675, 130);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(118, 472);
      this.listBox1.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(675, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(118, 34);
      this.button1.TabIndex = 2;
      this.button1.Text = "Validate";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click_1);
      // 
      // WrappingForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.button1);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.DiagramPanel);
      this.Name = "WrappingForm";
      this.Size = new System.Drawing.Size(796, 612);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel DiagramPanel;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button button1;
  }
}
