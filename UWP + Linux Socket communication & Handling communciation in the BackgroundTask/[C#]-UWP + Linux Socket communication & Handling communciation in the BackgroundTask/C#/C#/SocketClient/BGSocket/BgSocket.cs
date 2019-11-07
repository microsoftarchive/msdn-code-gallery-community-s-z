using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Notifications;

namespace BGSocket
{
    public sealed class BgSocket : IBackgroundTask
    {
        private BackgroundTaskDeferral _bgDeferral;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _bgDeferral = taskInstance.GetDeferral();

            var socketActivate = taskInstance.TriggerDetails as SocketActivityTriggerDetails;
            if (socketActivate != null)
            {
                var socketInfo = socketActivate.SocketInformation;

                StreamSocket socket;

                switch (socketActivate.Reason)
                {
                    case SocketActivityTriggerReason.None:
                        break;
                    case SocketActivityTriggerReason.SocketActivity:
                        socket = socketInfo.StreamSocket;
                        await ReadRecevice(socket);
                        socket.TransferOwnership(socketActivate.SocketInformation.Id);
                        break;
                    case SocketActivityTriggerReason.ConnectionAccepted:
                        break;
                    case SocketActivityTriggerReason.KeepAliveTimerExpired:
                        break;
                    case SocketActivityTriggerReason.SocketClosed:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _bgDeferral.Complete();

        }

        private static async Task ReadRecevice(StreamSocket socket)
        {
            var reader = new DataReader(socket.InputStream)
            {
                InputStreamOptions = InputStreamOptions.Partial
            };

            await reader.LoadAsync(256);

            var response = reader.ReadString(reader.UnconsumedBufferLength);
            reader.DetachStream();

            var tost = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);
            var childUpdate = tost?.GetElementsByTagName("text");
            if (childUpdate != null) childUpdate[0].InnerText = response;
            ToastNotification titleNotification = new ToastNotification(tost) {Group = "NetUpdate"};
            ToastNotificationManager.CreateToastNotifier().Show(titleNotification);
        }
    }
}
