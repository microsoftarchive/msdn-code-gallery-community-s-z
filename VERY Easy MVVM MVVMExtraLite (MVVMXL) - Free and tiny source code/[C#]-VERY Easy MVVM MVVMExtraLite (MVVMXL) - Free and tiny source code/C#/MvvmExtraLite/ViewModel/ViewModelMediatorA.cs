using MvvmExtraLite.Helpers;
namespace MvvmExtraLite.ViewModel
{
    public class ViewModelMediatorA : ViewModelBase
    {
        string myPropertyA;
        public string MyPropertyA
        {
            get
            {
                return myPropertyA;
            }
            set
            {
                if (myPropertyA != value)
                {
                    myPropertyA = value;
                    RaisePropertyChanged("MyPropertyA");
                    Mediator.NotifyColleagues("ViewB", value);
                }
            }
        }

        public ViewModelMediatorA()
        {
            Mediator.Register("ViewA", DoAction);
        }

        void DoAction(object param)
        {
            myPropertyA = param as string;
            RaisePropertyChanged("MyPropertyA");
        }
    }
}
