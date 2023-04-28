using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Base
{
    public abstract class EntityBase
    {
        public Guid Guid { get; init; }

        public int Id { get; protected set; }

        [NotMapped, JsonIgnore]
        public bool IdIsNull { get => Id <= 0; }

        [NotMapped, JsonIgnore]
        public bool GuidIsNull { get => Guid == Guid.Empty; }

        protected EntityBase(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentNullException(nameof(guid), "Guid can't be null"); 

            Guid = guid;
        }

        protected EntityBase(EntityBase entity) : this(entity.Guid) 
        { 
            Id = entity.Id;
        }
    }
}
