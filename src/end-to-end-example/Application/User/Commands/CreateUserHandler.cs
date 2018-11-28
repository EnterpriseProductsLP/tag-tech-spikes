// <copyright file="CreateUserHandler.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

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
