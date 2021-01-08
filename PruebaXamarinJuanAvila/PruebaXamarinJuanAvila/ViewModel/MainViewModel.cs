using PruebaXamarinJuanAvila.Models;
using PruebaXamarinJuanAvila.Services;
using PruebaXamarinJuanAvila.Services.Countries;
using PruebaXamarinJuanAvila.Utils;
using PruebaXamarinJuanAvila.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaXamarinJuanAvila.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CountriesServices _countriesServices;
        private readonly NavigationServices _navigationServices;
        public MainViewModel()
        {
            _countriesServices = new CountriesServices();
            _navigationServices = new NavigationServices();
        }
        #region PropertyModels
        private List<CountriesModel> Countries;

        private ObservableCollection<CountriesModel> _countriesModels = new ObservableCollection<CountriesModel>();

        public ObservableCollection<CountriesModel> CountriesModels
        {
            get { return _countriesModels; }
            set
            {
                _countriesModels = value;
                OnPropertyChanged();
            }
        }

        private string _filterCountries;

        public string FilterCountries
        {
            get { return _filterCountries; }
            set
            {
                _filterCountries = value;
                Task.Run(async () => await FilerCountries(value));
                OnPropertyChanged();
            }
        }
        private async Task FilerCountries(string value) =>
            await Task.Run(() =>
            {
                var countriesFilter = Countries.Where(x => x.name.ToLower().StartsWith(value.ToLower(), comparisonType: StringComparison.CurrentCulture)).ToList();
                CountriesModels = new ObservableCollection<CountriesModel>(countriesFilter);
            });

        public ICommand GoToMapCommand => new Command(async (object obj) => await GoToMap(obj));
        #endregion
        public override async Task InitializeAsync(object data)
        {
            try
            {
                Countries = await _countriesServices.GetCountries();
                CountriesModels = new ObservableCollection<CountriesModel>(Countries);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}");
                await base.InitializeAsync(false);
            }
        }
        private async Task GoToMap(object obj)
        {
            await _navigationServices.NavigationToModalAsync(typeof(MapView), obj);
        }
    }
}
