using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Reflection;
using System.Threading;
using System.Windows.Threading;
using System;
using mshtml;

namespace WpfApplication48
{
    public partial class MainWindow : Window
    {
        int Tries;

        public MainWindow()
        {
            InitializeComponent();
            wb1.LoadCompleted += new LoadCompletedEventHandler(bws_LoadCompleted);
            wb1.Navigated += new NavigatedEventHandler(bws_Navigated);
        }

        void bws_Navigated(object sender, NavigationEventArgs e)
        {
            HideScriptErrors(wb1, true);
        }

        void bws_LoadCompleted(object sender, NavigationEventArgs e)
        {
            switch (e.Uri.AbsolutePath)
            {
                case "/":
                    DoExample1();
                    break;
            }
        }

        private void DoExample1()
        {
            TryFillInBing(txtSearch.Text);
        }

        void TryFillInBing(string name)
        {
            Thread.Sleep(500);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                if (!UpdateTextInput(0, "q", name) && Tries < 6)
                {
                    Tries++;
                    TryFillInBing(name);
                }
                else
                {
                    IHTMLFormElement form = GetForm(0);
                    form.submit();
                }
            }));
        }

        private bool UpdateTextInput(int formId, string name, string text)
        {
            bool successful = false;
            IHTMLFormElement form = GetForm(formId);
            if (form != null)
            {
                var element = form.item(name: name);
                if (element != null)
                {
                    var textinput = element as HTMLInputElement;
                    textinput.value = text;
                    successful = true;
                }
            }

            return successful;
        }

        private IHTMLFormElement GetForm(int formNo)
        {
            IHTMLDocument2 doc = (IHTMLDocument2)wb1.Document;
            IHTMLElementCollection forms = doc.forms;
            var ix = 0;
            foreach (IHTMLFormElement f in forms)
                if (ix++ == formNo)
                    return f;

            return null;
        }

        void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wb1.Navigate("http://www.bing.com");
        }
    }
}
