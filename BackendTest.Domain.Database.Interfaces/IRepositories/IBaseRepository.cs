using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Domain.Database.Interfaces.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        TEntity Select(int id);
        void Update(TEntity obj);
    }
}
