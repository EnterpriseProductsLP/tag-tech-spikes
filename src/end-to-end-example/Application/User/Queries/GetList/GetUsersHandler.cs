using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.User.Queries.GetList
{
    public class GetCustomersHandler : IRequestHandler<GetUsers, UserListModel>
    {
        private readonly IUserDbContext _dbContext;

        public GetCustomersHandler(IUserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<UserListModel> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var viewModel = new UserListModel
            {
                Users = await _dbContext.Users.Select(x => new UserLookupModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username
                }).ToListAsync(cancellationToken)
            };

            return viewModel;
        }
    }
}