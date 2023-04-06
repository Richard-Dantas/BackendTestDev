using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using BackendTest.Infrastructure.DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Infrastructure.Database.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Tarefa> GetById(int id)
        {
            return await _context.Set<Tarefa>().Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tarefa> GetByUserName(string name)
        {
            return await _context.Set<Tarefa>().Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Usuario.Name == name);
        }
    }
}
