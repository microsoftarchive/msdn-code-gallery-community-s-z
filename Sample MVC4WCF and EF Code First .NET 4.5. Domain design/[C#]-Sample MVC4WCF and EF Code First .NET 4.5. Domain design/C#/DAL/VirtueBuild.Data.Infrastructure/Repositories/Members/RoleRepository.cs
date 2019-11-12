#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  RoleRepository.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.Repositories.Members {
    #region

    using Context.Sources;

    using Domain.Members;

    using Interfaces.Repository.Members;

    #endregion

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository {

        public RoleRepository(OpenFrameworkCoreContext context)
            : base(context) {}

    }
}