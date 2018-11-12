using System;

namespace Domain.Exceptions
{
    public class ActiveDirectoryAccountInvalidException : Exception
    {
        public ActiveDirectoryAccountInvalidException(string adAccount, Exception ex)
            : base($"AD Account \"{adAccount}\" is invalid.", ex)
        {
        }
    }
}