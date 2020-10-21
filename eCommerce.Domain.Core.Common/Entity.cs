namespace eCommerce.Domain.Core.Common
{
    public class Entity<TKey>
    {
        public TKey Id { get; protected set; }
        public int PersistentId { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}