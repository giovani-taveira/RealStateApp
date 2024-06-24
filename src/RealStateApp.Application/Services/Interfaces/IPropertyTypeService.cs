using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Services
{
    public interface IPropertyTypeService
	{
        Task<bool> DeleteAsync(PropertyType propertyType);
        Task<bool> UpdateAsync(PropertyType propertyType);
        Task<List<PropertyType>> GetAllAsync();
		Task<PropertyType> GetByIdAsync(int id);
		Task<bool> CreateAsync(PropertyType propertyType);
    }
}