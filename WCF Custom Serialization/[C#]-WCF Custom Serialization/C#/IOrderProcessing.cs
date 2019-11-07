using System.ServiceModel;

namespace OptimizedSerialization
{
    [MyNewSerializerContractBehavior]
    [ServiceContract]
    public interface IOrderProcessing
    {
        [OperationContract]
        void ProcessOrder(Order order);
        [OperationContract]
        Order GetOrder(int id);
    }
}
