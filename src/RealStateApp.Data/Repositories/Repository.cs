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

        public async Task<bool> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>()
                        .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicado)
        {
            return await _context.Set<TEntity>()
                           .Where(predicado)
                           .ToListAsync();
        }
    }
}
