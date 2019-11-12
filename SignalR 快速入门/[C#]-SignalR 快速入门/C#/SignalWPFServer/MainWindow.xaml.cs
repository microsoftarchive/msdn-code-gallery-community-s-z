using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SignalWPFHost 
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public IDisposable SignalR { get; set; }
        private const string ServerUri = "http://localhost:8888"; // SignalR服务地址

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            WriteToConsole("正在启动服务...");
            ButtonStart.IsEnabled = false;
            Task.Run(() => StartServer()); // 异步启动SignalR服务
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            SignalR.Dispose();
            Close();
        }

        /// <summary>
        /// 启动SignalR服务，将SignalR服务寄宿在WPF程序中
        /// </summary>
        private void StartServer()
        {
            try
            {
                SignalR = WebApp.Start(ServerUri);  // 启动SignalR服务
            }
            catch (TargetInvocationException)
            {
                WriteToConsole("一个服务已经运行在：" + ServerUri);
                // Dispatcher回调来设置UI控件状态
                this.Dispatcher.Invoke(() => ButtonStart.IsEnabled = true);
                return;
            }

            this.Dispatcher.Invoke(() => ButtonStop.IsEnabled = true);
            WriteToConsole("服务已经成功启动，地址为：" + ServerUri);
        }

        /// <summary>
        /// 将消息添加到消息列表中
        /// </summary>
        /// <param name="message"></param>
        public void WriteToConsole(String message)
        {
            if (!(RichTextBoxConsole.CheckAccess()))
            {
                this.Dispatcher.Invoke(() =>
                    WriteToConsole(message)
                );
                return;
            }

            RichTextBoxConsole.AppendText(message + "\r");
        }
    }

    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public override Task OnConnected()
        {
            //
            Application.Current.Dispatcher.Invoke(() =>
                ((MainWindow)Application.Current.MainWindow).WriteToConsole("客户端连接，连接ID是: " + Context.ConnectionId));

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
             Application.Current.Dispatcher.Invoke(() =>
                ((MainWindow)Application.Current.MainWindow).WriteToConsole("客户端断开连接，连接ID是: " + Context.ConnectionId));

            return base.OnDisconnected(true);
        }
    }
}
