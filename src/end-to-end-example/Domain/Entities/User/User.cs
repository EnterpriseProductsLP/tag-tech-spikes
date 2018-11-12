using System.Security;
using Common.EntityTypes;

namespace Domain.Entities.User
{
    [AggregateRoot]
    public class User : Entity
    {
        public string Country { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Username { get; set; }
    }
}