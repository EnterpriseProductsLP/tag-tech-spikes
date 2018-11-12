using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using MediatR;

namespace Application.User.Queries.GetDetails
{
    public class GetUser : IRequest<UserDetailModel>
    {
        public string Id { get; set; }
    }

    public class GetUserHandler : IRequestHandler<GetUser, UserDetailModel>
    {
        private readonly IUserDbContext _dbContext;

        public GetUserHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailModel> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(request.Id);

            if (user == null) throw new NotFoundException(nameof(User), request.Id);

            return new UserDetailModel
            {
                Country = user.Country,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Username = user.Username
            };
        }
    }
}