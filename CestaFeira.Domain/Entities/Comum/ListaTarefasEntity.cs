using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CestaFeira.Domain.Entities.Comum
{
    public class ListaTarefasEntity : BaseEntity
    {
        public Guid ListaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public ListaEntity Listas { get; set; }
    }
}
