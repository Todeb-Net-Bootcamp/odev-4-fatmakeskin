using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitofWorks
{
    public interface IUnitofWork
    {
        int SaveChanges();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
