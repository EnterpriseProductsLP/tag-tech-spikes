// <copyright file="CreateUser.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// � Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using MediatR;

namespace Application.User.Commands
{
    public class CreateUser : IRequest
    {
        public string Country { get; set; }

        public string FirstName { get; set; }

        public long Id { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Username { get; set; }
    }
}
