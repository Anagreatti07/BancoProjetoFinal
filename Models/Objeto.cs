using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    [Table("Objeto")]
    public class Objeto
    {
        [Column("ObjetoId")]
        [Display(Name = "Objeto")]
        public int Id { get; set; }

        [Column("ObjetoNome")]
        [Display(Name = "Objeto Nome")]
        public string ObjetoNome { get; set; } = string.Empty;

        [Column("ObjetoCor")]
        [Display(Name = "Objeto Cor")]
        public string ObjetoCor { get; set; } = string.Empty;

        [Column("ObjetoObservacao")]
        [Display(Name = "Objeto Observacao")]
        public string ObjetoObservacao { get; set; } = string.Empty;

        [Column("ObjetoLocalDesaparecimento")]
        [Display(Name = "Objeto Local Desaparecimento")]
        public string ObjetoLocalDesaparecimento { get; set; } = string.Empty;

        [Column("ObjetoFoto")]
        [Display(Name = "Objeto Foto")]
        public string? ObjetoFoto { get; set; } = string.Empty;

        [Column("ObjetoDtDesaparecimento")]
        [Display(Name = "Objeto data de desaparecimento")]
        public DateTime ObjetoDtDesaparecimento { get; set; }

        [Column("ObjetoDtEncontro")]
        [Display(Name = "Objeto data de encontro")]
        public DateTime? ObjetoDtEncontro { get; set; }

        [Column("ObjetoStatus")]
        [Display(Name = "Status do objeto")]
        public byte ObjetoStatus { get; set; }


        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
