// <copyright file="GetCustomersHandler.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

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
            return new UserListModel
            {
                Users = await _dbContext.Users.Select(
                                            x => new UserLookupModel
                                            {
                                                FirstName = x.FirstName,
                                                LastName = x.LastName,
                                                Username = x.Username
                                            })
                                        .ToListAsync(cancellationToken)
            };
        }
    }
}
