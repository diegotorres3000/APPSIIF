using System.Windows.Input;
using Xamarin.Forms;

using APPSIIF.Views;

namespace APPSIIF.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        
        string _TextNickName;
        public string TextNickName
        {
            set { value = (value == "") ? null : value; _TextNickName = value; OnPropertyChanged(); }
            get { return _TextNickName; }
        }

        string _TextVerificationCode;
        public string TextVerificationCode
        {
            set { value = (value=="") ?null:value; _TextVerificationCode = value; OnPropertyChanged(); }
            get { return _TextVerificationCode; }
        }

        public ICommand CancelCommand { private set; get; }

        public RegisterViewModel()
        {
            CancelCommand = new Command(Cancel);
        }

        async void Cancel()
        {
            var action = await Application.Current.MainPage.DisplayAlert("Información", "¿Esta seguro de cancelar la transacción?", "Si", "No");
            if (action)
            {
                Application.Current.MainPage = new LoginView();
            }
        }
    }
}
