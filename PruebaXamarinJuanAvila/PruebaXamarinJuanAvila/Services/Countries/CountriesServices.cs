using PruebaXamarinJuanAvila.Models;
using PruebaXamarinJuanAvila.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaXamarinJuanAvila.Services.Countries
{
    public class CountriesServices
    {
        private ApiServices _servicesApi;
        public CountriesServices()
        {
            _servicesApi = new ApiServices();
        }
        public async Task<List<CountriesModel>> GetCountries() =>
            await _servicesApi.GetToCacheAsync<List<CountriesModel>>("/all");
    }
}
