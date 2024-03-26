using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    [Table("dish")]
    public class Dish : BaseEntity
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }

        [Column("name", TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Column("price", TypeName = "decimal(5, 2)")]
        public float Price { get; set; }

        public static Dish None => new()
        {
            Id = -1
        };
    }
}
