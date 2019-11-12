namespace RealTimeDataEditor.Core
{
    public class ProductDataMessage
    {
        public MessageType MessageType { get; set; }

        public Product Product { get; set; }

        public string ResponseMessage { get; set; }

        public bool DataProcessedSuccessfully { get; set; }
    }
}