using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template_dotnet.Models
{
    [Table("departamento")]
    public class SSExampleModel: IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("descripcion")]
        public required string Description { get; set; }
        [Required]
        [Column("fecha_registro", TypeName = "datetime2")]
        public required DateTime RegisterDate { get; set; }
        [Required]
        [Column("estado")]
        public required char State { get; set; }

        public ICollection<SSRExampleModel> Ubications { get; set; } = new List<SSRExampleModel>();

    }
}
