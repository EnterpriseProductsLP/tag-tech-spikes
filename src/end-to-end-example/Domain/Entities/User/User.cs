using System.Security;
using System.ComponentModel.DataAnnotations;
using Common.EntityTypes;

namespace Domain.Entities.User
{
    [AggregateRoot]
    public class User : Entity
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MinLength(16)]
        [Required]
        public string Password { get; set; }

        // How do we deal with special formatting?  It is pretty tough...
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Username { get; set; }
    }
}