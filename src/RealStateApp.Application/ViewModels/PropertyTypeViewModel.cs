using RealStateApp.Application.Services;
using RealStateApp.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RealStateApp.Application.ViewModels
{
    public record PropertyTypeViewModel : INotifyPropertyChanged
	{
        private readonly IPropertyTypeService _service;
        private List<PropertyType> _allPropertyTypes;
        private List<PropertyType> _propertyTypes;
        private PropertyType _currentPropertyType;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<PropertyType> PropertyTypes
        {
            get => _propertyTypes;
            set
            {
                _propertyTypes = value;
                OnPropertyChanged();
            }
        }

        public PropertyType CurrentPropertyType
        {
            get => _currentPropertyType;
            set
            {
                _currentPropertyType = value;
                OnPropertyChanged();
            }
        }

        private string _searchString;
        public string SearchString
        {
            get => _searchString;
            set
            {
                _searchString = value;
                OnPropertyChanged();
                FilterPropertyTypes();
            }
        }

        public PropertyTypeViewModel(IPropertyTypeService service)
        {
            _service = service;
            _allPropertyTypes = new List<PropertyType>();
            _propertyTypes = new List<PropertyType>();
        }

        public async Task GetAllAsync()
        {
            _allPropertyTypes = await _service.GetAllAsync();
            FilterPropertyTypes();
        }

        public async Task GetByIdAsync(int id)
        {
            CurrentPropertyType = await _service.GetByIdAsync(id);
        }

        private void FilterPropertyTypes()
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                PropertyTypes = _allPropertyTypes;
            }
            else
            {
                PropertyTypes = _allPropertyTypes
                    .Where(pt => pt.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ||
                                 pt.Id.ToString().Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            OnPropertyChanged(nameof(PropertyTypes));
        }

        public void GetNewProperty()
        {
            CurrentPropertyType = new PropertyType();
        }

        public async Task<bool> SaveAsync()
        {
            bool isSuccessful = false;

            if (CurrentPropertyType.Id == 0)
            {
                isSuccessful = await _service.CreateAsync(CurrentPropertyType);
            }
            else
            {
                isSuccessful = await _service.UpdateAsync(CurrentPropertyType);
            }
            await GetAllAsync();
            return isSuccessful;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool isSuccessful = false;
            var propertyType = await _service.GetByIdAsync(id);

            if (propertyType == null)
                return false;

            isSuccessful = await _service.DeleteAsync(propertyType);
            await GetAllAsync();
            return isSuccessful;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
