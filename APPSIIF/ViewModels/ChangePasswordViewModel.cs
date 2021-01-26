using System;
using System.Collections.Generic;
using System.Text;

namespace APPSIIF.ViewModels
{
    class ChangePasswordViewModel : BaseViewModel
    {
        string _NickName;
        public string NickName
        {
            set { value = (value == "") ? null : value; _NickName = value; OnPropertyChanged(); }
            get { return _NickName; }
        }

        string _OldPassword;
        public string OldPassword
        {
            set { value = (value == "") ? null : value; _OldPassword = value; OnPropertyChanged(); }
            get { return _OldPassword; }
        }

        string _NewPassword;
        public string NewPassword
        {
            set { value = (value == "") ? null : value; _NewPassword = value; OnPropertyChanged(); }
            get { return _NewPassword; }
        }

        string _ConfirmPassword;
        public string ConfirmPassword
        {
            set { value = (value == "") ? null : value; _ConfirmPassword = value; OnPropertyChanged(); }
            get { return _ConfirmPassword; }
        }
    }
}
