namespace HelloWorkflowAndMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Web.Mvc;
    using System.Web.Security;

    #region Models

    public class ChangePasswordModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion
    }

    public class LogOnModel
    {
        #region Public Properties

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    public class RegisterModel
    {
        #region Public Properties

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    #endregion

    #region Services

    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IMembershipService
    {
        #region Public Properties

        int MinPasswordLength { get; }

        #endregion

        #region Public Methods and Operators

        bool ChangePassword(string userName, string oldPassword, string newPassword);

        MembershipCreateStatus CreateUser(string userName, string password, string email);

        bool ValidateUser(string userName, string password);

        #endregion
    }

    public class AccountMembershipService : IMembershipService
    {
        #region Constants and Fields

        private readonly MembershipProvider _provider;

        #endregion

        #region Constructors and Destructors

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            this._provider = provider ?? Membership.Provider;
        }

        #endregion

        #region Public Properties

        public int MinPasswordLength
        {
            get
            {
                return this._provider.MinRequiredPasswordLength;
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }
            if (String.IsNullOrEmpty(oldPassword))
            {
                throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            }
            if (String.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException("Value cannot be null or empty.", "newPassword");
            }

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                var currentUser = this._provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be null or empty.", "password");
            }
            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Value cannot be null or empty.", "email");
            }

            MembershipCreateStatus status;
            this._provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be null or empty.", "password");
            }

            return this._provider.ValidateUser(userName, password);
        }

        #endregion
    }

    public interface IFormsAuthenticationService
    {
        #region Public Methods and Operators

        void SignIn(string userName, bool createPersistentCookie);

        void SignOut();

        #endregion
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        #region Public Methods and Operators

        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            }

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }

    #endregion

    #region Validation

    public static class AccountValidation
    {
        #region Public Methods and Operators

        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
    {
        #region Constants and Fields

        private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";

        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        #endregion

        #region Constructors and Destructors

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        #endregion

        #region Public Methods and Operators

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, this.ErrorMessageString, name, this._minCharacters);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            return new[]
                {
                    new ModelClientValidationStringLengthRule(
                        this.FormatErrorMessage(metadata.GetDisplayName()), this._minCharacters, int.MaxValue)
                };
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= this._minCharacters);
        }

        #endregion
    }

    #endregion
}