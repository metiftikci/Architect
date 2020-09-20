using System.ComponentModel.DataAnnotations;

namespace Architect.ApplicationCore.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [MaxLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public bool Active { get; set; }

        public User()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            EmailAddress = string.Empty;
            PhoneNumber = string.Empty;
        }
    }
}
