using RealStateApp.Application.Services;
using RealStateApp.Application.Services.Interfaces;
using RealStateApp.Domain.Entities;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RealStateApp.Application.ViewModels
{
    public class CondominiumTypeViewModel : INotifyPropertyChanged
    {
        private readonly ICondominiumTypeService _service;
        private List<CondominiumType> _allCondominiumTypes;
        private List<CondominiumType> _condominiumTypes;
        private CondominiumType _currentCondominiumType;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<CondominiumType> CondominiumTypes
        {
            get => _condominiumTypes;
            set
            {
                _condominiumTypes = value;
                OnPropertyChanged();
            }
        }

        public CondominiumType CurrentCondominiumType
        {
            get => _currentCondominiumType;
            set
            {
                _currentCondominiumType = value;
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
                FilterCondominiumTypes();
            }
        }

        public CondominiumTypeViewModel(ICondominiumTypeService service)
        {
            _service = service;
            _allCondominiumTypes = new List<CondominiumType>();
            _condominiumTypes = new List<CondominiumType>();
        }

        public async Task GetAllAsync()
        {
            _allCondominiumTypes = await _service.GetAllAsync();
            FilterCondominiumTypes();
        }

        public async Task GetByIdAsync(int id)
        {
            CurrentCondominiumType = await _service.GetByIdAsync(id);
        }

        private void FilterCondominiumTypes()
        {
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                CondominiumTypes = _allCondominiumTypes;
            }
            else
            {
                CondominiumTypes = _allCondominiumTypes
                    .Where(pt => pt.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ||
                                 pt.Id.ToString().Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            OnPropertyChanged(nameof(CondominiumTypes));
        }

        public void GetNewCondominiumType()
        {
            CurrentCondominiumType = new CondominiumType();
        }

        public async Task<bool> SaveAsync()
        {
            bool isSuccessful = false;

            if (CurrentCondominiumType.Id == 0)
            {
                isSuccessful = await _service.CreateAsync(CurrentCondominiumType);
            }
            else
            {
                isSuccessful = await _service.UpdateAsync(CurrentCondominiumType);
            }
            await GetAllAsync();
            return isSuccessful;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool isSuccessful = false;
            var condominiumType = await _service.GetByIdAsync(id);

            if (condominiumType == null)
                return false;

            isSuccessful = await _service.DeleteAsync(condominiumType);
            await GetAllAsync();
            return isSuccessful;
        }

        protected void OnPropertyChanged([CallerMemberName] string condominiumName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(condominiumName));
        }
    }
}
