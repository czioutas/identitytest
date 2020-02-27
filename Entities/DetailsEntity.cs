using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityissue
{
    public class DetailsEntity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        public string Value { get; set; }

        public DetailsEntity()
        {
        }

        public DetailsEntity(string value)
        {
            Value = value;
        }
    }
}