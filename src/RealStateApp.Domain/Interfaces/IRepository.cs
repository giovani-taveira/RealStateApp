using System.Linq.Expressions;

namespace RealStateApp.Domain.Entities
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> CreateRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);
        Task Delete(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int Id);
        IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicado);
    }
}
