using PruebaXamarinJuanAvila.ViewModel;
using Xamarin.Forms;

namespace PruebaXamarinJuanAvila.View
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            var ViewModel = new MainViewModel();
            ViewModel.InitializeAsync(null).ConfigureAwait(false);
            this.BindingContext = ViewModel;
            InitializeComponent();
        }
    }
}
