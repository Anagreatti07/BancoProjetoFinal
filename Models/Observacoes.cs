using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProjetoFinal.Models
{
    [Table("Observacoes")]
    public class Observacoes
    {
        [Column("ObservacaoId")]
        [Display(Name = "Obsevacao")]
        public int Id { get; set; }

        [Column("ObservacaoDescricao")]
        [Display(Name = "observacao descricao")]
        public string ObservacaoDescricao { get; set; } = string.Empty;

        [Column("ObservacaoLocal")]
        [Display(Name = "Observacao Local")]
        public string ObservacaoLocal { get; set; } = string.Empty;

        [Column("ObservacaoData")]
        [Display(Name = "Observacao Data")]
        public string ObservacaoData { get; set; } = string.Empty;

        [ForeignKey("ObjetoId")]
        [Display(Name = "Objeto")]
        public int ObjetoId { get; set; }
        public Objeto? Objeto { get; set; }

        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
