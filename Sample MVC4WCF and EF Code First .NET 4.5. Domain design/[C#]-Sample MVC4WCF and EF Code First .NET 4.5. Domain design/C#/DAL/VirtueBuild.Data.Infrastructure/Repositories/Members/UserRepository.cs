#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  UserRepository.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.Repositories.Members {
    #region

    using System;
    using System.Linq;

    using Context.Sources;

    using Domain;
    using Domain.Members;
    using Domain.Settings;

    using Interfaces.Repository.Members;

    #endregion

    public class UserRepository : RepositoryBase<User>, IUserRepository {

        public UserRepository(OpenFrameworkCoreContext context)
            : base(context) {}

        #region IUserRepository Members

        public override void Insert(User user)
        {
            user.LastActivity = DateTime.UtcNow;
            user.LastLogin = DateTime.UtcNow;
            user.LastPasswordChange = DateTime.UtcNow;
            Application app = Context.Applications.FirstOrDefault(a => a.Name == Constants.ApplicationName);
            if (app != null) {
                user.ApplicationId = app.Id;
            }

            user.CreatedOn = DateTime.UtcNow;
            user.CreatedBy = Guid.NewGuid(); //TODO: Remove this. It should be existing user
            user.UserGuid = Guid.NewGuid();
            Context.Users.Add(user);
        }

        #endregion
    }
}