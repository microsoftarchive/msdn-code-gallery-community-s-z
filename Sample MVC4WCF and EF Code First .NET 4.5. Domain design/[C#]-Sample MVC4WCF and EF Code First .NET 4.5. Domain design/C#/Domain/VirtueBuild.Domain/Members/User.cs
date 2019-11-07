#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  User.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

#region

#endregion

namespace VirtueBuild.Domain.Members {
    #region

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    using Base;

    using Settings;

    #endregion

    [DataContract]
    [KnownType(typeof (Role))]
    [KnownType(typeof (SecurityQuestion))]
    [KnownType(typeof (Organization))]
    public class User : BaseEntity {

        public User(string userName, string password, string email)
            : this()
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public User()
        {
            SecurityQuestions = new List<SecurityQuestion>();
            Roles = new List<Role>();
        }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public int ApplicationId { get; set; }

        [Required]
        [Display(Name = "User name")]
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [DataMember]
        public int OrgId { get; set; }

        [DataMember]
        public int DefaultRoleId { get; set; }

        [DataMember]
        public bool IsApproved { get; set; }

        [DataMember]
        public string Salt { get; set; }

        [DataMember]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataMember]
        public string PasswordQuestion { get; set; }

        [DataMember]
        public string PasswordAnswer { get; set; }

        [DataMember]
        public int PasswordFormat { get; set; }

        [DataMember]
        public DateTime LastLogin { get; set; }

        [DataMember]
        public DateTime LastActivity { get; set; }

        [DataMember]
        public DateTime LastPasswordChange { get; set; }

        [DataMember]
        public DateTime? LastLockout { get; set; }

        [DataMember]
        public int FailedPasswordAttempts { get; set; }

        [DataMember]
        public int FailedAnswerAttempts { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsLocked { get; set; }

        [DataMember]
        public bool Online { get; set; }

        [DataMember]
        public virtual Application Application { get; set; }
        [DataMember]
        public virtual Organization Organization { get; set; }
        [DataMember]
        public virtual ICollection<SecurityQuestion> SecurityQuestions { get; set; }
        [DataMember]
        public virtual ICollection<Role> Roles { get; set; }

    }
}