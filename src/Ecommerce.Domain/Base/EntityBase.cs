namespace Ecommerce.Domain.Base
{
    public abstract class EntityBase
    {
        public Guid Guid { get; init; }

        public int Id { get; }

        protected EntityBase(Guid guid)
        {
            Guid = guid;
        }
    }
}
