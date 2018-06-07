using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.ValueObjects
{
    public class Nonconformity: ValueObject {
        public Nonconformity(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
    }
}