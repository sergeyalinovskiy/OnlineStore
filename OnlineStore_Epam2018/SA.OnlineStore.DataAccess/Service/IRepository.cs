using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Implements
{
    public interface IRepository<T>
    {
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        T GetById(int id);
        IReadOnlyCollection<T> GetAll();
    }
}
