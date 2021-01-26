using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace APPSIIF.ViewModels
{
    /**
     * clase base para notificar
     * a las vistas que se atcualiza algun dato
     * dentro del modelo (logica)
     */
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
