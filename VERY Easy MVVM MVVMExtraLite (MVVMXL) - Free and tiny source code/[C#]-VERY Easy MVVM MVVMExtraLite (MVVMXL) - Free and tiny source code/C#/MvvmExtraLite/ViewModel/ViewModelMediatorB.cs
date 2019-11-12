using MvvmExtraLite.Helpers;
namespace MvvmExtraLite.ViewModel
{
    public class ViewModelMediatorB : ViewModelBase
    {
        string myPropertyB;
        public string MyPropertyB
        {
            get
            {
                return myPropertyB;
            }
            set
            {
                if (myPropertyB != value)
                {
                    myPropertyB = value;
                    RaisePropertyChanged("MyPropertyB");
                    Mediator.NotifyColleagues("ViewA", value);
                }
            }
        }

        public ViewModelMediatorB()
        {
            Mediator.Register("ViewB", DoAction);
        }

        void DoAction(object param)
        {
            myPropertyB = param as string;
            RaisePropertyChanged("MyPropertyB");
        }
    }

}
