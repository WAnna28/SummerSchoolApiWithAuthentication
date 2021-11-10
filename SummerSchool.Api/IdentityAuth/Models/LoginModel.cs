using System.ComponentModel.DataAnnotations;

namespace SummerSchool.Api.IdentityAuth
{
    // for user login
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}