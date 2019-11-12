#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Context
// File:  ContentInitialazer.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Context.Initializer {
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    using Domain;
    using Domain.Lookups;
    using Domain.Members;
    using Domain.Settings;

    using Sources;

    #endregion

    //DropCreateDatabaseAlways<OpenFrameworkCoreContext>
    //DropCreateDatabaseIfModelChanges<OpenFrameworkCoreContext>
    public class ContentInitialazer : DropCreateDatabaseAlways<OpenFrameworkCoreContext> {

        private const string HashedPassword = "B23046048EF67A365E069BB82CF801B708ED344D"; //Virtue2013!
        private const string EncryptionKey = "A9C7A8FA-BD16-445B-82BC-37730E683B10";
        private const string Salt = "2tLAsV23kt85bCyBsMOyJQ==";

        protected override void Seed(OpenFrameworkCoreContext context)
        {
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_USER_UserName ON [User] (UserName)");
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_USER_UserEmail ON [User] (Email)");
            context.Database.ExecuteSqlCommand("EXEC sp_changedbowner @loginame = N'sa', @map = false");

            context.Applications.AddOrUpdate(a => a.Name, new Application { Name = Constants.ApplicationName, Id = 1 });

            context.Users.AddOrUpdate(u => u.UserName,
                                      new User("system", HashedPassword, "system@openframework.com") {
                                          Salt = Salt,
                                          ApplicationId = 1,
                                          UserGuid = new Guid(Constants.SystemAccountGuid),
                                          DefaultRoleId = 1,
                                          Roles = new List<Role> {
                                              new Role {Name = "System", SystemRole = true, Id = 1}
                                          },
                                          LastActivity = DateTime.UtcNow,
                                          LastLogin = DateTime.UtcNow,
                                          LastPasswordChange = DateTime.UtcNow,
                                          LastLockout = DateTime.UtcNow.AddYears(-10),
                                          CreatedBy = new Guid(Constants.SystemAccountGuid),
                                          CreatedOn = DateTime.UtcNow,
                                          UpdatedBy = new Guid(Constants.SystemAccountGuid),
                                          UpdatedOn = DateTime.UtcNow,
                                          OrgId = 1
                                      }, new User("sysadmin", HashedPassword, "sysadmin@openframework.com") {
                                          Salt = Salt,
                                          ApplicationId = 1,
                                          UserGuid = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}"),
                                          DefaultRoleId = 2,
                                          Roles = new List<Role> {
                                              new Role {Name = "SysAdmin", SystemRole = true, Id = 2}
                                          },
                                          LastActivity = DateTime.UtcNow,
                                          LastLogin = DateTime.UtcNow,
                                          LastPasswordChange = DateTime.UtcNow,
                                          LastLockout = DateTime.UtcNow.AddYears(-10),
                                          CreatedBy = new Guid(Constants.SystemAccountGuid),
                                          CreatedOn = DateTime.UtcNow,
                                          UpdatedBy = new Guid(Constants.SystemAccountGuid),
                                          UpdatedOn = DateTime.UtcNow,
                                          OrgId = 2
                                      });

            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role {Name = "Customer", SystemRole = false, Id = 3},
                new Role {Name = "OrgAdmin", SystemRole = false, Id = 4},
                new Role {Name = "Admin", SystemRole = false, Id = 5},
                new Role {Name = "Rep", SystemRole = false, Id = 6}
                );

            context.HomeTypes.AddOrUpdate(h => h.Name,
                                          new HomeType {Name = "Single Family", IsActive = true},
                                          new HomeType {Name = "Condominium", IsActive = true}
                );

            context.OrganizationTypes.AddOrUpdate(t => t.Name,
                                                  new OrganizationType {Name = "System", IsActive = true, Id = 1},
                                                  new OrganizationType {Name = "Contractor", IsActive = true, Id = 2},
                                                  new OrganizationType {Name = "Corporation", IsActive = true, Id = 3}
                );
            context.Organizations.AddOrUpdate(t => t.Name,
                                              new Organization {
                                                  Id = 1,
                                                  Name = "SYSTEM",
                                                  OrgTypeId = 1,
                                                  IsActive = true,
                                                  Description = "SYSTEM",
                                                  CreatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}"),
                                                  CreatedOn = DateTime.UtcNow,
                                                  UpdatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}"),
                                                  UpdatedOn = DateTime.UtcNow
                                              },
                                              new Organization {
                                                  Id = 2,
                                                  Name = "VirtueBuild",
                                                  OrgTypeId = 1,
                                                  IsActive = true,
                                                  Description = "Application Owner and Host",
                                                  CreatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}"),
                                                  CreatedOn = DateTime.UtcNow,
                                                  UpdatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}"),
                                                  UpdatedOn = DateTime.UtcNow
                                              });

            base.Seed(context);
        }

    }
}