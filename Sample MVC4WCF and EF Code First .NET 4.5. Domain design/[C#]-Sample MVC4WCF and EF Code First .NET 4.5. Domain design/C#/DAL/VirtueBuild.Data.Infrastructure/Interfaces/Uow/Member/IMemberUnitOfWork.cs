#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  IMemberUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.Interfaces.Uow.Member {
    #region

    using System;

    using Context.Sources;

    using Domain.Members;

    using Repository.Members;

    #endregion

    public interface IMemberUnitOfWork : IUnitOfWork<OpenFrameworkCoreContext> {

        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        Guid CreateMember(User user);

        User GetUser(Guid userGuid);

        User GetUserByEmail(string email);

        User GetUserByUserName(string userName);

    }
}