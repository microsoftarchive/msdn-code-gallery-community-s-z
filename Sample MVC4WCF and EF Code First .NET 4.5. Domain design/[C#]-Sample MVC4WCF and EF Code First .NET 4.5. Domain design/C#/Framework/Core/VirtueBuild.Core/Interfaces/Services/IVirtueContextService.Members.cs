#region File Attributes

// AdminWeb  Project: VirtueBuild.Core
// File:  IVirtueContextService.Members.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Core.Interfaces.Services {
    #region

    using System;
    using System.ServiceModel;

    using Domain.Members;

    #endregion

    [ServiceContract]
    public partial interface IVirtueContextService {

        [OperationContract]
        Guid CreateCustomer(User customer);

        [OperationContract]
        void UpdateUserInfo(User user);

    }
}