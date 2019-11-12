#region File Attributes

// AdminWeb  Project: VirtueBuild.Data.Infrastructure
// File:  MemberUnitOfWork.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Data.Infrastructure.UnitsOfWork {
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Context.Sources;

    using Domain;
    using Domain.Members;

    using Interfaces.Repository.Members;
    using Interfaces.Uow.Member;

    using Repositories.Members;

    #endregion

    public class MemberUnitOfWork : BaseCoreUnitOfWork, IMemberUnitOfWork {

        private readonly IRoleRepository _roleRepository;

        private readonly IUserRepository _userRepository;

        public MemberUnitOfWork()
            : base(new OpenFrameworkCoreContext())
        {
            _userRepository = new UserRepository(Context);
            _roleRepository = new RoleRepository(Context);
        }

        public MemberUnitOfWork(OpenFrameworkCoreContext context)
            : base(context)
        {
            _userRepository = new UserRepository(context);
            _roleRepository = new RoleRepository(context);
        }

        #region IMemberUnitOfWork Members

        public IUserRepository UserRepository { get { return _userRepository; } }

        public IRoleRepository RoleRepository { get { return _roleRepository; } }

        public Guid CreateMember(User user)
        {
            VerifyNewUser(user);

            var customerRole = _roleRepository.Find(r => r.Name.Equals(Constants.CustomerRole)).FirstOrDefault();
            if (customerRole != null) {
                user.DefaultRoleId = customerRole.Id;
                user.Roles = new List<Role> {customerRole};
            }
            _userRepository.Insert(user);

            return user.UserGuid;
        }

        public User GetUser(Guid userGuid)
        {
            return _userRepository.Find(u => u.UserGuid.Equals(userGuid)).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.Find(u => u.Email.Equals(email)).FirstOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.Find(u => u.UserName.Equals(userName)).FirstOrDefault();
        }

        #endregion

        private void VerifyNewUser(User user)
        {
            User curUser =
                _userRepository.Find(u => u.Email.Equals(user.Email) || u.UserName == user.UserName).FirstOrDefault();
            if (curUser != null) {
                throw new Exception("Account with this name or email already exists");
            }
        }

    }
}