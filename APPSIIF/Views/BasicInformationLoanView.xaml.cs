using System;
using System.Collections.Generic;

using APPSIIF.Renderer;
using APPSIIF.ViewModels;

using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class BasicInformationLoanView : MyContentPageRenderer
    {
        BasicInformationLoanViewModel BasicInformationLoanViewModel;

        public BasicInformationLoanView()
        {
            InitializeComponent();
            BindingContext = BasicInformationLoanViewModel = new BasicInformationLoanViewModel();
        }

        public async void ViewInterests(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new InterestView());
        }

        public async void ViewCustomerInformation(object sender, EventArgs args)
        {
            BasicInformationLoanViewModel.IsClientVisible = !BasicInformationLoanViewModel.IsClientVisible;
        }

        public async void ViewLoanInformation(object sender, EventArgs args)
        {
            BasicInformationLoanViewModel.IsLoanVisible = !BasicInformationLoanViewModel.IsLoanVisible;
        }

        public async void ViewProductInformation(object sender, EventArgs args)
        {
            BasicInformationLoanViewModel.IsProductVisible = !BasicInformationLoanViewModel.IsProductVisible;
        }

        public async void ViewPaymentInformation(object sender, EventArgs args)
        {
            BasicInformationLoanViewModel.IsPaymentVisible = !BasicInformationLoanViewModel.IsPaymentVisible;
        }
    }
}
