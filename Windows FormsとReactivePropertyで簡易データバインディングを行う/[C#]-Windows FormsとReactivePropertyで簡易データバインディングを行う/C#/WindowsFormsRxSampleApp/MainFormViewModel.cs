using Codeplex.Reactive;
using System;
using System.Reactive.Linq;

namespace WindowsFormsRxSampleApp
{
    public class MainFormViewModel
    {
        public ReactiveProperty<string> Input { get; private set; }
        public ReactiveProperty<string> Output { get; private set; }

        public ReactiveCommand ClearCommand { get; private set; }

        public MainFormViewModel()
        {
            this.Input = new ReactiveProperty<string>();

            this.Output = this.Input
                .Where(x => x != null)
                .Delay(TimeSpan.FromSeconds(3))
                .Select(x => x.ToUpper())
                .ObserveOn(WindowsFormUIDispatcher.Default)
                .ToReactiveProperty();

            this.ClearCommand = new ReactiveCommand();
            this.ClearCommand.Subscribe(_ => this.Input.Value = "Clear value!!");
        }
    }
}
