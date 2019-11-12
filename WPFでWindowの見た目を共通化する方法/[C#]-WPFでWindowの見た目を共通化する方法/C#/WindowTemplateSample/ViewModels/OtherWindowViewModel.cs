namespace WindowTemplateSample.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;

    /// <summary>
    /// 他のWindowでも同様にWindowViewModelBaseを継承して動作をカスタマイズできる。
    /// </summary>
    public class OtherWindowViewModel : WindowViewModelBase
    {
        public OtherWindowViewModel() : base()
        {
            this.CommonAButton.Label.Value = "OK";
            this.CommonBButton.Label.Value = "Cancel";

            this.CommonAButton.Command.Subscribe(_ =>
                MessageBox.Show("OK"));
            this.CommonBButton.Command.Subscribe(_ =>
                MessageBox.Show("Cancel"));
        }
    }
}
