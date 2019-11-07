using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ScoreServicesRepo
{
    [ServiceContract]
    public interface IScoreSvcRepo
    {
        [OperationContract(IsOneWay=true)]
        void AddToServiceRepo(string uri);

        [OperationContract(IsOneWay = true)]
        void RemoveFromServiceRepo(string uri);

        [OperationContract]
        List<string> GetScoreServicesRepoInfo(); 
    }
}
