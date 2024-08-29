using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CestaFeira.Domain.Entities.Comum
{
    public class ListaEntity : BaseEntity
    {
        public string NomeLista { get; set; }
        public string NomeAutor { get; set; }
        public DateTime DataCriacao { get; set; }
        public IEnumerable<ListaTarefasEntity> ListaTarefas { get; set; }
        [Column("idLista")]
        public override Guid Id { get; set; }

    }
}
