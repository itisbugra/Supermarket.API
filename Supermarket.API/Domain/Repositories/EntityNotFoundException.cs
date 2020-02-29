using System;

namespace Supermarket.API.Domain.Repositories
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }

        public object[] KeyValues { get; private set; }

        public EntityNotFoundException(Type entityType,
                                       params object[] keyValues)
            : base($"Cannot find entity of type [{entityType.Name} ({entityType.FullName})] with given identifier {keyValues}.")
        {
            EntityType = entityType;
            KeyValues = keyValues;
        }
    }
}
