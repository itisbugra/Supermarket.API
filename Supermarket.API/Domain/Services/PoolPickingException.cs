using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public abstract class PoolPickingException : Exception
    {
        private static string GenerateMessage(string message) =>
            $"Could not pick from the pool: {message}";

        public PoolPickingException()
        {
            //  Empty implementation.
        }

        public PoolPickingException(string message)
            : base(GenerateMessage(message))
        {
            //  Empty implementation.
        }

        public PoolPickingException(string message,
                                    Exception innerException)
            : base(GenerateMessage(message), innerException)
        {
            //  Empty implementation.
        }
    }
}
