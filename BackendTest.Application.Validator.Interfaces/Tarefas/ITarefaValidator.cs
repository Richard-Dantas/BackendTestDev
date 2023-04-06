using BackendTest.Application.Models.Tarefas;
using BackendTest.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Application.Validator.Interfaces.Tarefas
{
    public interface ITarefaValidator
    {
        void CreateValidation(TarefaRequest tarefa);
        void FindValidation(Tarefa tarefa);
        void FindProgressValidation(Tarefa tarefa);
        void EditValidation(TarefaRequest tarefa);
        void FileValidation(IFormFile arquivo);
    }
}
