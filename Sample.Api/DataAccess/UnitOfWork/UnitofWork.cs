using Data.Context;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitofWorks
{
    public class UnitofWorks:IUnitofWork,IDisposable
    {
        private MasterContext _masterContext;
        public UnitofWorks(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }
        public void Dispose()
        {
            _masterContext.Dispose();
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_masterContext);
        }

        public int SaveChanges()
        {
            try
            {
                var result = _masterContext.SaveChanges();
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
