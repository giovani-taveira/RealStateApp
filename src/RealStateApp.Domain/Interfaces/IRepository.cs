using System.Linq.Expressions;

namespace RealStateApp.Domain.Entities
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> CreateRange(IEnumerable<TEntity> entities);
        Task<bool> Update(TEntity entity);
        Task<bool> UpdateRange(IEnumerable<TEntity> entities);
        Task<bool> Delete(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicado);
    }
}
