using BackendTest.Application.Models.Tarefas;
using Microsoft.AspNetCore.Http;

namespace BackendTest.Application.Service.Interfaces.Tarefas
{
    public interface ITarefaService
    {
        Task<TarefaResponse> Find(int id);
        Task<TimeSpan> FindProgress(int id);
        Task<TarefaResponse> Create(TarefaRequest tarefaRequest);
        Task<TarefaResponse> Edit(int id, TarefaRequest tarefaRequest);
        Task<TarefaResponse> CreateJoaoSilva();
        Task<TarefaResponse> CreateAnaSilva();
        Task<TarefaResponse> EditAna();
        Task AnexarArquivo(int tarefaId, IFormFile arquivo);
    }
}
