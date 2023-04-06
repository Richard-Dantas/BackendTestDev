using BackendTest.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Domain.Database.Interfaces.IRepositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        Task<Tarefa> GetById(int id);
        Task<Tarefa> GetByUserName(string name);
    }
}
