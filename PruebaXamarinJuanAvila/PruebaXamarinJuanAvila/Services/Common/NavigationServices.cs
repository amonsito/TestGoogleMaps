using PruebaXamarinJuanAvila.Utils;
using PruebaXamarinJuanAvila.View;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaXamarinJuanAvila.Services
{
    public class NavigationServices
    {
        public async Task NavigationToModalAsync(Type viewType, object parameter = null)
        {
            var CurrentPage = App.Current.MainPage as ContentPage;
            Page page = Activator.CreateInstance(viewType) as Page;
            if (parameter != null)
                await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);

            await CurrentPage.Navigation.PushModalAsync(page);
        }

    }
}
