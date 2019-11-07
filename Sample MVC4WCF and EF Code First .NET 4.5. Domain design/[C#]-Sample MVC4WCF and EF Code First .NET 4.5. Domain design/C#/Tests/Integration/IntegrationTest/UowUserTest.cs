#region File Attributes

// AdminWeb  Project: IntegrationTest
// File:  UowUserTest.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace IntegrationTest {
    #region

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Runtime.InteropServices;
    using System.Transactions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VirtueBuild.Data.Context.Initializer;
    using VirtueBuild.Data.Context.Sources;
    using VirtueBuild.Data.Infrastructure.Interfaces.Uow.Member;
    using VirtueBuild.Data.Infrastructure.UnitsOfWork;
    using VirtueBuild.Domain.Members;
    using VirtueBuild.Security;

    #endregion

    [TestClass, Guid("A6C710CE-AFFC-4866-8C07-915FDB384E2A")]
    public class UowUserTest {

        private OpenFrameworkCoreContext _dBcontext;
        private EncryptionService _encryptionService;
        private string _salt;
        private SecuritySettings _securSettings;

        [TestInitialize]
        public void TestSetup()
        {
            _securSettings = new SecuritySettings {EncryptionKey = "A9C7A8FA-BD16-445B-82BC-37730E683B10"};
            _encryptionService = new EncryptionService(_securSettings);
            _salt = _encryptionService.CreateSaltKey(16);
            _dBcontext = new OpenFrameworkCoreContext();
        }

        [TestMethod]
        public void CreateAndSeedDatabaseTest()
        {
            var dbInitializer = new ContentInitialazer();
            Database.SetInitializer(dbInitializer);
            
            dbInitializer.InitializeDatabase(_dBcontext);
        }

        [TestMethod]
        public void ShouldCreateNewUserInUserTableWithDefaultRole()
        {
            var encryptedPassword = _encryptionService.CreatePasswordHash("password", _salt);
            var userName = Guid.NewGuid().ToString();
            var email = Guid.NewGuid().ToString();
            var member = new User(userName, encryptedPassword, email) {
                Salt = _salt,
                OrgId = 2,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}")
            };

            //using (var scope = new TransactionScope()) {
            using (IMemberUnitOfWork memberUow = new MemberUnitOfWork(_dBcontext)) {
                memberUow.CreateMember(member);
                memberUow.Save();
                Assert.IsNotNull(member.UserGuid);
                Assert.AreNotEqual(member.UserGuid, Guid.Empty);
                memberUow.UserRepository.Delete(member);
                memberUow.Save();
                //scope.Complete();
            }
            //}
        }

        [TestMethod]
        //[Ignore]
        [ExpectedException(typeof (DbUpdateException))]
        public void ShouldNotCreateUserWithSameUserName()
        {
            var encryptedPassword = _encryptionService.CreatePasswordHash("password", _salt);
            var member = new User("testuser", encryptedPassword, "testuser@test.com")
            {
                Salt = _salt,
                OrgId = 2,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = new Guid("{7BE26044-11B6-4042-BDF5-900722713215}")
            };

            using (var scope = new TransactionScope()) {
                using (IMemberUnitOfWork memberUow = new MemberUnitOfWork(_dBcontext)) {
                    memberUow.CreateMember(member);
                    memberUow.Save();
                    Assert.IsNotNull(member.UserGuid);
                    Assert.AreNotEqual(member.UserGuid, Guid.Empty);
                    scope.Complete();
                }
            }
        }

    }
}