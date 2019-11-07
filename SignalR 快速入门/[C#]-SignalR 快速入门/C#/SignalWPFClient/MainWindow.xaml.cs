using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNet.SignalR.Client;

namespace SignalWPFClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly char[] Constant =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z'
        };

        public IHubProxy HubProxy { get; set; }
        const string ServerUri = "http://localhost:8888/signalr";
        public HubConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // 窗口启动时开始连接服务
            ConnectAsync();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            // 通过代理来调用服务端的Send方法
            // 服务端Send方法再调用客户端的AddMessage方法将消息输出到消息框中
            HubProxy.Invoke("Send",  GenerateRandomName(4), TextBoxMessage.Text.Trim());

            TextBoxMessage.Text = String.Empty;
            TextBoxMessage.Focus();
        }

        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerUri);
            Connection.Closed += Connection_Closed;

            // 创建一个集线器代理对象
            HubProxy = Connection.CreateHubProxy("ChatHub");

            // 供服务端调用，将消息输出到消息列表框中
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                 this.Dispatcher.Invoke(() =>
                    RichTextBoxConsole.AppendText(String.Format("{0}: {1}\r", name, message))
                ));

            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                ChatPanel.Visibility = Visibility.Visible;
                RichTextBoxConsole.AppendText("请检查服务是否开启：" + ServerUri + "\r");
                // 连接失败
                return;
            }

            // 显示聊天控件
            ChatPanel.Visibility = Visibility.Visible;
            ButtonSend.IsEnabled = true;
            TextBoxMessage.Focus();
            RichTextBoxConsole.AppendText("连上服务：" + ServerUri + "\r");
        }

        /// <summary>
        /// 窗口关闭触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WPFClient_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        void Connection_Closed()
        {
            // 隐藏聊天界面
            var dispatcher = Application.Current.Dispatcher;
            dispatcher.Invoke(() => ChatPanel.Visibility = Visibility.Collapsed);
            dispatcher.Invoke(() => ButtonSend.IsEnabled = false);
        }

        /// <summary>
        /// 产生随机用户名
        /// </summary>
        /// <param name="length">用户名长度</param>
        /// <returns></returns>
        public static string GenerateRandomName(int length)
        {
            var newRandom = new StringBuilder(62);
            var rd = new Random();
            for (var i = 0; i < length; i++)
            {
                newRandom.Append(Constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
