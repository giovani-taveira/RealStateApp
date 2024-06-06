using RealStateApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RealStateApp.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicado)
        {
            return _context.Set<TEntity>()
                           .Where(predicado)
                           .AsQueryable();
        }
    }
}
