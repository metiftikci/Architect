using System.ComponentModel.DataAnnotations;

namespace Architect.Web.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public AuthenticateRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
