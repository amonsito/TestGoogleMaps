using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PruebaXamarinJuanAvila.Utils
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }
    }
}
