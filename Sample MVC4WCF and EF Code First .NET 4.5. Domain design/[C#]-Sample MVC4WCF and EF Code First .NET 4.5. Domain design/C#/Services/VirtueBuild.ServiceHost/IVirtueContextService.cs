#region File Attributes

// AdminWeb  Project: VirtueBuild.ServiceHost
// File:  IVirtueContextService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.ServiceHost {
    #region

    using System.ServiceModel;

    #endregion

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVirtueContextService" in both code and config file together.
    [ServiceContract]
    public interface IVirtueContextService {

        [OperationContract]
        void DoWork();

    }
}