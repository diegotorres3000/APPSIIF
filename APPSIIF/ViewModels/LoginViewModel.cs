using System.Windows.Input;
using APPSIIF.Helpers;

namespace APPSIIF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        bool _IsVisibleLogin;
        public bool IsVisibleLogin
        {
            set { _IsVisibleLogin = value; OnPropertyChanged(); }
            get { return _IsVisibleLogin; }
        }

        bool _IsVisibleRegister;
        public bool IsVisibleRegister
        {
            set { _IsVisibleRegister = value; OnPropertyChanged();}
            get { return _IsVisibleRegister; }
        }

        bool _IsRememberingUserName;
        public bool IsRememberingUserName
        {
            set { _IsRememberingUserName = value; OnPropertyChanged(); }
            get { return _IsRememberingUserName; }
        }

        string _TextNickName;
        public string TextNickName
        {
            set { value = (value == "") ?null:value; _TextNickName = value; OnPropertyChanged();}
            get { return _TextNickName; }
        }

        string _TextPassword;
        public string TextPassword
        {
            set { value = (value == "") ? null : value; _TextPassword = value; OnPropertyChanged(); }
            get { return _TextPassword; }
        }

        public ICommand RegisterCommand { private set; get; }

        public LoginViewModel()
        {
            if (!string.IsNullOrEmpty(Settings.RefreshToken))
            {
                IsVisibleLogin = false;
                IsVisibleRegister = false;
            }

            if (string.IsNullOrEmpty(Settings.RegisterCode))
            {
                IsVisibleLogin = false;
                IsVisibleRegister = true;
            }
            else
            {
                IsVisibleLogin = true;
                IsVisibleRegister = false;
            }
        }
    }
}
