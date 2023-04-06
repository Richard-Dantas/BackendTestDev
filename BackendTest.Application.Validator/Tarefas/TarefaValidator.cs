using BackendTest.Application.Models.Tarefas;
using BackendTest.Application.Validator.Interfaces.Tarefas;
using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Application.Validator.Tarefas
{
    public class TarefaValidator : ITarefaValidator
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaValidator(IUsuarioRepository usuarioRepository, ITarefaRepository tarefaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tarefaRepository = tarefaRepository;
        }
        public void CreateValidation(TarefaRequest tarefa)
        {
            var usuario = _usuarioRepository.Select(tarefa.UsuarioId);
            if(usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            if(tarefa.DataInicio > DateTime.Now && tarefa.Status.ToString() != "Agendada")
            {
                throw new Exception("Tarefa com Inicio maior que a data atual precisa estar como Agendada");
            }
            if(tarefa.DataFim != null && tarefa.Status.ToString() != "Concluida")
            {
                throw new Exception("Tarefa com Data de finalização precisa estar como Concluída");
            }
        }

        public void FindValidation(Tarefa tarefa)
        {
            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrado");
            }
        }

        public void FindProgressValidation(Tarefa tarefa)
        {
            if (tarefa.Status == Domain.Core.Enumerables.StatusTarefa.Agendada)
            {
                throw new Exception("Não é possível calcular o tempo de andamento de uma tarefa ainda não iniciada");
            }
        }

        public void EditValidation(TarefaRequest tarefa)
        {
            CreateValidation(tarefa);
        }

        public void FileValidation(IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                throw new Exception("Arquivo não enviado");
            }
        }
    }
}
