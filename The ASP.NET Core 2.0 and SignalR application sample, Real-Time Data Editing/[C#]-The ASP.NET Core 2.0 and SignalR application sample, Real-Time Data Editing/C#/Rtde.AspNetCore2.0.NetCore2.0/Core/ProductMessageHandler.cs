using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RealTimeDataEditor.DataAccess;

namespace RealTimeDataEditor.Core
{
    public static class ProductMessageHandler
    {
        public static bool HandleMessage(string receivedString, ref string responseString)
        {
            var responseMessage = new ProductDataMessage() { DataProcessedSuccessfully = true };

            try
            {
                var receivedMessage = JsonConvert.DeserializeObject<ProductDataMessage>(receivedString);
                if (receivedMessage.Product.Id == null)
                {
                    responseMessage.DataProcessedSuccessfully = false;
                    responseMessage.ResponseMessage = "Empty product identifier.";
                }
                else
                {
                    IProductsRepository repository = new ProductsRepository();
                    switch (receivedMessage.MessageType)
                    {
                        case MessageType.Insert:
                            try
                            {
                                responseMessage.MessageType = MessageType.Insert;
                                repository.Insert(receivedMessage.Product);
                                responseMessage.Product = receivedMessage.Product;
                                responseMessage.ResponseMessage = "Record with the identifier "
                                                                  + receivedMessage.Product.Id + " is successfully added.";
                            }
                            catch (ArgumentException e)
                            {
                                System.Diagnostics.Trace.WriteLine(e.Message);
                                responseMessage.DataProcessedSuccessfully = false;
                                responseMessage.ResponseMessage = "Record with the identifier "
                                                                  + receivedMessage.Product.Id + " already exists.";
                            }

                            break;
                        case MessageType.Update:
                            try
                            {
                                responseMessage.MessageType = MessageType.Update;
                                repository.Update(receivedMessage.Product);
                                responseMessage.Product = receivedMessage.Product;
                                responseMessage.ResponseMessage = "Record with the identifier "
                                                                  + receivedMessage.Product.Id + " is successfully updated.";
                            }
                            catch (KeyNotFoundException e)
                            {
                                System.Diagnostics.Trace.WriteLine(e.Message);
                                responseMessage.DataProcessedSuccessfully = false;
                                responseMessage.ResponseMessage = "Record with the identifier "
                                                                  + receivedMessage.Product.Id
                                                                  + " is absent or is deleted.";
                            }

                            break;
                        case MessageType.Delete:
                            responseMessage.MessageType = MessageType.Delete;
                            repository.Delete(receivedMessage.Product.Id.Value);
                            responseMessage.Product = receivedMessage.Product;
                            responseMessage.ResponseMessage = "Record with the identifier " + receivedMessage.Product.Id
                                                              + " is successfully deleted.";
                            break;
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                responseMessage.DataProcessedSuccessfully = false;
                responseMessage.ResponseMessage = "Input data are absent.";
            }
            catch (ArgumentException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                responseMessage.DataProcessedSuccessfully = false;
                responseMessage.ResponseMessage = "Input data had an incorrect format.";
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                responseMessage.DataProcessedSuccessfully = false;
                responseMessage.ResponseMessage = "Data handling error on the server.";
            }

            responseString = JsonConvert.SerializeObject(responseMessage);

            return responseMessage.DataProcessedSuccessfully;
        }
    }
}