using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Core.Enumerables;

namespace BackendTest.Application.Models.Tarefas
{
    public class TarefaResponse
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public StatusTarefa Status { get; set; }
        public Usuario Usuario { get; set; }
        public List<ArquivoAnexado> ArquivosAnexados { get; set; }
    }
}
