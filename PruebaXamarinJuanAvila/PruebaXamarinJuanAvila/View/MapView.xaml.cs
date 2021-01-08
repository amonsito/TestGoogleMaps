
using PruebaXamarinJuanAvila.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaXamarinJuanAvila.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            var ViewModel = new MapViewModel();
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}