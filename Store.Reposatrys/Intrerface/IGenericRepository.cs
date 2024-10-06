
using Store.Data.Entites;
using Store.Repository.Specifications;

namespace Store.Repository.Interface
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity :BaseEntity<Tkey>
    {
        Task<TEntity> GetByIdAsync(Tkey? id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
		Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> spec);
		Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> spec);
		Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}
