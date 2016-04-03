using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Properties;

namespace WebApp.Core.ViewModel
{
    public class UserViewModel
    {
        [MetadataType(typeof(ValidationUser))]
        public class SignUp
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public DateTime? Birthday { get; set; }
            public string Phone { get; set; }
        }

        [MetadataType(typeof (ValidationUser))]
        public class SignIn
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        private class ValidationUser
        {
            [Required(ErrorMessageResourceName = nameof(Resources.EmailIsRequired), ErrorMessageResourceType = typeof(Resources))]
            [EmailAddress(ErrorMessageResourceName = nameof(Resources.WrongEmail), ErrorMessageResourceType = typeof(Resources))]
            public string Login { get; set; }

            [Required(ErrorMessageResourceName = nameof(Resources.PasswordIsRequired), ErrorMessageResourceType = typeof(Resources))]
            [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessageResourceName = nameof(Resources.WrongPassword), ErrorMessageResourceType = typeof(Resources))]
            public string Password { get; set; }
        }
    }
}