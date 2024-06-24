using RealStateApp.Application.Services.Interfaces;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Services
{
    public class CondominiumTypeService : ICondominiumTypeService
    {
        private readonly IRepository<CondominiumType> _condominiumTypeRepository;

        public CondominiumTypeService(IRepository<CondominiumType> condominiumTypeRepository)
        {
            _condominiumTypeRepository = condominiumTypeRepository;
        }

        public async Task<List<CondominiumType>> GetAllAsync()
        {
            return await _condominiumTypeRepository.GetAll();
        }

        public async Task<CondominiumType> GetByIdAsync(int id)
        {
            return await _condominiumTypeRepository.GetById(id);
        }

        public async Task<bool> CreateAsync(CondominiumType propertyType)
        {
            var result = await _condominiumTypeRepository.Create(propertyType);
            return result != null;
        }

        public async Task<bool> UpdateAsync(CondominiumType propertyType)
        {
            return await _condominiumTypeRepository.Update(propertyType);
        }

        public async Task<bool> DeleteAsync(CondominiumType propertyType)
        {
            return await _condominiumTypeRepository.Delete(propertyType);
        }
    }
}
