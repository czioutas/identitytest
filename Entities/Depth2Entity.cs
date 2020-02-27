using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identityissue
{
    public class Depth2Entity
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        public string Value2 { get; set; }

        public Depth2Entity()
        {
        }

        public Depth2Entity(string value)
        {
            Value2 = value;
        }
    }
}