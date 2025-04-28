using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template_dotnet.Models
{
    [Table("ubicacion")]
    public class SSRExampleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("departamento_id")]
        public int StateId { get; set; }
        [Required]
        [Column("departamento")]
        public required string Ubication { get; set; }
        [Required]
        [Column("provincia")]
        public required string Province { get; set; }
        [Required]
        [Column("municipio")]
        public required string Municipe { get; set; }
        [Required]
        [Column("comunidad")]
        public required string Comunity { get; set; }
        [Required]
        [Column("fecha_registro", TypeName = "datetime2")]
        public required DateTime RegisterDate { get; set; }
        [Required]
        [Column("estado")]
        public required char State { get; set; }
        public SSExampleModel? UbicationModel { get; set; } = null;
    }
}
