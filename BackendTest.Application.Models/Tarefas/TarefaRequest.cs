using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Core.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Application.Models.Tarefas
{
    public class TarefaRequest
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public StatusTarefa Status { get; set; }
        public int UsuarioId { get; set; }
        public List<ArquivoAnexado>? ArquivosAnexados { get; set; }
    }
}
