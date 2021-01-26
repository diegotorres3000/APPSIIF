using System;
namespace APPSIIF.ViewModels
{
    public class BasicInformationLoanViewModel : BaseViewModel
    {
        bool _IsClientVisible;
        public bool IsClientVisible
        {
            get { return _IsClientVisible; }
            set { _IsClientVisible = value; OnPropertyChanged(); }
        }

        bool _IsLoanVisible;
        public bool IsLoanVisible
        {
            get { return _IsLoanVisible; }
            set { _IsLoanVisible = value; OnPropertyChanged(); }
        }

        bool _IsProductVisible;
        public bool IsProductVisible
        {
            get { return _IsProductVisible; }
            set { _IsProductVisible = value; OnPropertyChanged(); }
        }

        bool _IsPaymentVisible;
        public bool IsPaymentVisible
        {
            get { return _IsPaymentVisible; }
            set { _IsPaymentVisible = value; OnPropertyChanged(); }
        }

        public BasicInformationLoanViewModel()
        {
        }
    }
}
