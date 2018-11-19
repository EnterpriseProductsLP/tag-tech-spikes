// <copyright file="GetUserHandler.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

using Application.Exceptions;

using MediatR;

namespace Application.User.Queries.GetDetails
{
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

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

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
