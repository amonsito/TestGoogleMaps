using PruebaXamarinJuanAvila.Models;
using PruebaXamarinJuanAvila.Utils;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace PruebaXamarinJuanAvila.ViewModel
{
    public class MapViewModel : ViewModelBase
    {

        #region Private Methods
        private CameraUpdate _position;

        public CameraUpdate Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }

        #endregion
        public override async Task InitializeAsync(object data)
        {
            try
            {
                var latLong = (data as CountriesModel).latlng;

                Position = CameraUpdateFactory.NewCameraPosition(new CameraPosition(
                          new Position(latLong[0], latLong[1]),  // latlng
                          5d // zoom
                          //30d, // rotation
                          //60d) // tilt
                          ));
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"{ ex.GetType().Name + " : " + ex.Message}");
                await base.InitializeAsync(false);
            }
        }
    }
}
