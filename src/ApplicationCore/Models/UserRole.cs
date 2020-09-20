using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Architect.ApplicationCore.Models
{
    public class UserRole
    {
        public const string Administrator = "Administrator";

        public int UserId { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        // NAVIGATIONS

        [JsonIgnore]
        public User User { get; set; }

        public UserRole()
        {
            Role = string.Empty;

            User = null!;
        }
    }
}
