using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Services
{
	public class PropertyTypeService : IPropertyTypeService
	{
		private readonly IRepository<PropertyType> _propertyTypeRepository;

		public PropertyTypeService(IRepository<PropertyType> propertyRepository) => _propertyTypeRepository = propertyRepository;

        public async Task<List<PropertyType>> GetAllAsync()
        {
            return await _propertyTypeRepository.GetAll();
        }

        public async Task<PropertyType> GetByIdAsync(int id)
        {
            return await _propertyTypeRepository.GetById(id);
        }

        public async Task<bool> CreateAsync(PropertyType propertyType)
        {
            var result = await _propertyTypeRepository.Create(propertyType);
            return result != null;
        }

        public async Task<bool> UpdateAsync(PropertyType propertyType)
        {
            return await _propertyTypeRepository.Update(propertyType);
        }

        public async Task<bool> DeleteAsync(PropertyType propertyType)
        {
            return await _propertyTypeRepository.Delete(propertyType);
        }
    }
}
