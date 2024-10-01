using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Reposatrys
{
    public interface GnericReposatry<T>
    {
        int Add(T item);
        int Update(T item);
        int Delete(T item);
        IEnumerable<T> GetAll();
        T GetbyID(int id);

    }
}
