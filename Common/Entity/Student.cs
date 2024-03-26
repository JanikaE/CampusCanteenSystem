using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    [Table("student")]
    public class Student : BaseEntity
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }

        [Column("card_id", TypeName = "varchar(10)")]
        public string CardId { get; set; }

        [Column("name", TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Column("money", TypeName = "decimal(5, 2)")]
        public float Money { get; set; }

        public static Student None => new()
        {
            Id = -1
        };
    }
}
