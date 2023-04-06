using BackendTest.Domain.Core.Entities;
using BackendTest.Domain.Database.Interfaces.IRepositories;
using BackendTest.Infrastructure.DataAcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Infrastructure.Database.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
