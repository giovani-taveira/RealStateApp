using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Services.Interfaces
{
    public interface ICondominiumTypeService
    {
        Task<List<CondominiumType>> GetAllAsync();
        Task<CondominiumType> GetByIdAsync(int id);
        Task<bool> CreateAsync(CondominiumType propertyType);
        Task<bool> DeleteAsync(CondominiumType propertyType);
        Task<bool> UpdateAsync(CondominiumType propertyType);
    }
}
