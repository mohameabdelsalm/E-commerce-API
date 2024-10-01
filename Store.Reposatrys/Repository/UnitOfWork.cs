
using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbcontext _context;
        private Hashtable _hashtable;
        public UnitOfWork(StoreDbcontext context)
        {
            _context = context;   
        }
        public async Task<int> CompleteAsync()

        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity :BaseEntity<TKey>
        {
            if(_hashtable is null)
            
               _hashtable = new Hashtable(); 

            var entitykey=typeof(TEntity).Name; //"Product"

            if (!_hashtable.ContainsKey(entitykey))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var repositoryInstance= Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity),typeof(TKey)), _context);

                _hashtable.Add(entitykey, repositoryInstance);
            }
            return (IGenericRepository<TEntity, TKey>)_hashtable[entitykey];
            
        }
    }
}
