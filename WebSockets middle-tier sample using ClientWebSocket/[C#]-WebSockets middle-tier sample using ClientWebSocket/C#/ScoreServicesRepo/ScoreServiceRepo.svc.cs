using System.Collections.Generic;
using System.ServiceModel;

namespace ScoreServicesRepo
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ScoreServiceRepo : IScoreSvcRepo
    {
        // Structure to keep the list of score services coming up and going down
        List<string> ScoreServicesUris;

        public ScoreServiceRepo()
        { 
            ScoreServicesUris = new List<string>();
        }
        
        public void AddToServiceRepo(string uri)
        {
            // Add the uri from the repo
            ScoreServicesUris.Add(uri);
        }

        public void RemoveFromServiceRepo(string uri)
        {
            // Remove the uri from the repo
            ScoreServicesUris.Remove(uri);
        }

        public List<string> GetScoreServicesRepoInfo()
        {
            return ScoreServicesUris;
        }
    }
}
