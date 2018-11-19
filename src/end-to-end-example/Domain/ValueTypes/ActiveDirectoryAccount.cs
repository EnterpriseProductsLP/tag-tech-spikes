// <copyright file="ActiveDirectoryAccount.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System;
using System.Collections.Generic;

using Domain.Exceptions;

namespace Domain.ValueTypes
{
    public class ActiveDirectoryAccount : ValueType
    {
        public ActiveDirectoryAccount(string value)
        {
            try
            {
                var separatorIndex = value.IndexOf("\\", StringComparison.Ordinal);
                DomainName = value.Substring(0, separatorIndex);
                UserName = value.Substring(separatorIndex + 1);
            }
            catch (Exception ex)
            {
                throw new ActiveDirectoryAccountInvalidException(value, ex);
            }
        }

        public string DomainName { get; }

        public string UserName { get; }

        public static explicit operator ActiveDirectoryAccount(string value)
        {
            return new ActiveDirectoryAccount(value);
        }

        public static implicit operator string(ActiveDirectoryAccount adAccount)
        {
            return adAccount.ToString();
        }

        public override string ToString()
        {
            return $"{DomainName}\\{UserName}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return DomainName;
            yield return UserName;
        }
    }
}
