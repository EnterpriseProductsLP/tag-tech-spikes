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

        public string UserName { get; }

        public string DomainName { get; }

        public static implicit operator string(ActiveDirectoryAccount adAccount)
        {
            return adAccount.ToString();
        }

        public static explicit operator ActiveDirectoryAccount(string value)
        {
            return new ActiveDirectoryAccount(value);
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