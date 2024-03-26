using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    [Table("consume")]
    public class Consume : BaseEntity
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }

        [Column("student_id")]
        public long StudentId { get; set; }

        [Column("dish_id_list", TypeName = "varchar(100)")]
        public string DishIdList { get; set; }

        [Column("price", TypeName = "decimal(5, 2)")]
        public float Price { get; set; }

        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }
    }
}
