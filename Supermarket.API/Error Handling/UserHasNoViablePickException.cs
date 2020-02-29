using System;
using Supermarket.API.Domain.Services;

namespace Supermarket.API
{
    public class UserHasNoViablePickException : PoolPickingException
    {
        public UserHasNoViablePickException()
        {
            //  Empty implementation.
        }

        public UserHasNoViablePickException(string message) 
            : base(message)
        {
            //  Empty implementation.
        }

        public UserHasNoViablePickException(string message,
                                            Exception innerException) 
            : base(message, innerException)
        {
            //  Empty implementation.
        }
    }
}
