using Codeplex.Reactive;
using Codeplex.Reactive.Binding;
using Codeplex.Reactive.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRxSampleApp
{
    public partial class MainForm : Form
    {
        private MainFormViewModel viewModel = new MainFormViewModel();
        public MainForm()
        {
            InitializeComponent();

            this.viewModel
                .Input
                .BindTo(
                    this.textBoxInput,
                    x => x.Text,
                    mode: BindingMode.TwoWay,
                    targetUpdateTrigger: Observable.FromEvent<EventHandler, EventArgs>(
                        h => (s, e) => h(e),
                        h => this.textBoxInput.TextChanged += h,
                        h => this.textBoxInput.TextChanged -= h)
                        .ToUnit());

            this.viewModel
                .Output
                .BindTo(
                    this.labelOutput,
                    x => x.Text);

            this.buttonClear.Click += this.viewModel.ClearCommand.ToEventHandler();
        }

    }
}
