#region File Attributes

// AdminWeb  Project: VirtueBuild.SecurityService
// File:  VirtueSecurityService.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.SecurityService {
    #region

    using System;

    using AutoMapper;

    using Core.Interfaces.Services;

    using Data.Infrastructure.UnitsOfWork;

    using Domain.Members;
    using Domain.Settings;

    using Security;

    #endregion

    public class VirtueSecurityService : IVirtueSecurityService {

        public VirtueSecurityService()
        {
            InitEntityMapping();
        }

        private void InitEntityMapping()
        {
            Mapper.CreateMap<User, User>();
            Mapper.CreateMap<Role, Role>();
            Mapper.CreateMap<Organization, Organization>();
            Mapper.CreateMap<SecurityQuestion, SecurityQuestion>();
            Mapper.CreateMap<Application, Application>();
        }

        #region Implementation of IVertueSecurityService

        public bool IsValidAccount(User suer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IVertueSecurityService

        public User Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserNameOrEmail(string userName, string email)
        {
            User userDto = null;
            using (var memberUow = new MemberUnitOfWork()) {
                var user = memberUow.GetUserByEmail(email) ?? memberUow.GetUserByUserName(userName);
                if (user != null) {
                   
                    userDto = Mapper.Map<User, User>(user);

                    userDto.Application.Users = null;
                    userDto.Organization.Users = null;
                    userDto.Organization.OrganizationType.Organizations = null;
                }
            }
            return userDto;
        }

        public string CreatePasswordHash(string password, string salt)
        {
            var encriptionServcie = new EncryptionService();
            return encriptionServcie.CreatePasswordHash(password, salt);
        }

        #endregion
    }
}