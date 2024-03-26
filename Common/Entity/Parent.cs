using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entity
{
    [Table("parent")]
    public class Parent : BaseEntity
    {
        [Key]
        [Column("id")]
        public override long Id { get ; set ; }

        [Column("name", TypeName = "varchar(10)")]
        public string Name { get; set; }

        [Column("student_id", TypeName = "varchar(100)")]
        public string StudentId { get; set; }
    }
}
