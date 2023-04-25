using Ecommerce.Domain.Utility;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Base
{
    public abstract class EntityBase
    {
        public Guid Guid { get; init; }

        public int Id { get; }

        [NotMapped, JsonIgnore]
        public bool IdIsNull { get => Id <= 0; }

        [NotMapped, JsonIgnore]
        public bool GuidIsNull { get => GuidUtility.IsNull(Guid); }

        protected EntityBase(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentNullException(nameof(guid), "Guid can't be null"); 

            Guid = guid;
        }
    }
}
