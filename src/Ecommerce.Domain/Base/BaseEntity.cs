namespace Ecommerce.Domain.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; init; }

        public int Id { get; }
    }
}
