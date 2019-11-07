#region File Attributes

// AdminWeb  Project: VirtueBuild.Core
// File:  IVirtueSecurityService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Core.Interfaces.Services {
    #region

    using System.ServiceModel;

    using Domain.Members;

    #endregion

    [ServiceContract]
    [ServiceKnownType(typeof (User))]
    [ServiceKnownType(typeof (Role))]
    public interface IVirtueSecurityService {

        [OperationContract]
        bool IsValidAccount(User suer);

        [OperationContract]
        User Login(string userName, string password);

        [OperationContract]
        User GetUserByUserNameOrEmail(string userName, string email);

        [OperationContract]
        string CreatePasswordHash(string password, string salt);

    }
}