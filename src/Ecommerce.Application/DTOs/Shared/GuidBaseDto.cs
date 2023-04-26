using Ecommerce.Domain.Utility;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.DTOs.Shared
{
    public abstract record GuidBaseDto
    {
        public Guid Guid { get; set; }

        [NotMapped, JsonIgnore]
        public bool GuidIsNull { get => Guid == Guid.Empty; }

        protected GuidBaseDto(Guid guid)
        {
            Guid = guid;
        }

        protected GuidBaseDto() { }
    }
}
