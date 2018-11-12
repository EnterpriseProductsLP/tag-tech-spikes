using MediatR;

namespace Application.User.Commands
{
    public class CreateUser : IRequest
    {
        public string Country { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long Id { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}