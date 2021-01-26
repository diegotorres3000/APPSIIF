using System;

using Xamarin.Forms;

using APPSIIF.Renderer;
using APPSIIF.ViewModels;
using APPSIIF.Services;
using APPSIIF.Helpers;
using APPSIIF.Models.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

using System.Collections.ObjectModel;

namespace APPSIIF.Views
{
    public partial class ChangePasswordView : MyContentPageRenderer
    {
        ChangePasswordViewModel ChangePasswordViewModel;

        public ChangePasswordView()
        {
            InitializeComponent();
            this.BindingContext = ChangePasswordViewModel = new ChangePasswordViewModel();
        }

        public ChangePasswordView(string password)
        {
            InitializeComponent();
            this.BindingContext = ChangePasswordViewModel = new ChangePasswordViewModel();
            ChangePasswordViewModel.OldPassword = password;
        }

        async void ChangePasswordClicked(object sender, EventArgs args)
        {
            ShowLoading();

            var responseGPS = await InfoGPS.InformacionGPS();
            if (!string.IsNullOrEmpty(responseGPS.Message))
            {
                HideLoading();
                ShowErrorMessage(responseGPS.Message);
                return;
            }

            ChangePasswordRequest changePasswordRequest = new ChangePasswordRequest
            {
                NickName = ChangePasswordViewModel.NickName,
                Code = Settings.Code,
                OldPassword = ChangePasswordViewModel.OldPassword,
                NewPassword = ChangePasswordViewModel.NewPassword,
            };

            var jsonRequest = JsonConvert.SerializeObject(changePasswordRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio

            try
            {
                response = await ApiService.ConsumoPOST(ApiService.URL, "api_appsiif/api/User/ChangePassword", content);
                result = response.Result;
            }
            catch
            {

            }

            if (response.Code >= 400)
            {
                ShowErrorMessage(response.Result);
                HideLoading();
                return;
            }
            else if (response.Code >= 200 && response.Code < 300)
            {
                HideLoading();
                ShowSuccessMessage("Cambio de Contraseña Exitoso");
                Application.Current.MainPage = new LoginView();
            }
        }
    }
}
