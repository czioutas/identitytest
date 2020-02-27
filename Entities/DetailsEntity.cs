using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityissue
{
    public class DetailsEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        public string Value { get; set; }

        [ForeignKey(nameof(Depth2))]
        public int? Depth2EntityId { get; set; }
        public Depth2Entity Depth2 { get; set; }

        public DetailsEntity()
        {
        }

        public DetailsEntity(string value)
        {
            Value = value;
        }
    }
}