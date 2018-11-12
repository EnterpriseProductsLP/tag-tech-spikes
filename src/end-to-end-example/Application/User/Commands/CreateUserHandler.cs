using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.User.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUser, Unit>
    {
        private readonly IUserDbContext _dbContext;

        public CreateUserHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User.User
            {
                Country = request.Country,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Phone = request.Phone,
                Username = request.Username
            };

            _dbContext.Users.Add(user);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}