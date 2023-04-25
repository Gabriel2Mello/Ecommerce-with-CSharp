namespace Ecommerce.Domain.Shared
{
    public class ReturnChanges<TEntity>
    {
        public ReturnChanges(TEntity entity, int changes)
        {
            Entity = entity;
            Changes = changes;
        }

        public TEntity Entity { get; private set; }
        public int Changes { get; private set; }
    }
}
