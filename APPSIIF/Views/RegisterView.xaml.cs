using System;
using System.Net.Http;
using System.Text;
using APPSIIF.Models.Api;
using APPSIIF.Renderer;
using APPSIIF.ViewModels;
using APPSIIF.Services;
using APPSIIF.Helpers;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class RegisterView : MyContentPageRenderer
    {
        RegisterViewModel RegisterViewModel;

        public RegisterView()
        {
            InitializeComponent();
            RegisterViewModel = new RegisterViewModel();
            BindingContext = RegisterViewModel;

        }

        async void RegisterClicked(object sender, EventArgs args)
        {
            ShowLoading();

            var responseGPS = await InfoGPS.InformacionGPS();
            if (!string.IsNullOrEmpty(responseGPS.Message))
            {
                HideLoading();
                ShowErrorMessage(responseGPS.Message);
                return;
            }

            RegisterRequest registerRequest = new RegisterRequest
            {
                NickName = RegisterViewModel.TextNickName,
                VerificationCode = RegisterViewModel.TextVerificationCode,
                DeviceName = CrossDeviceInfo.Current.DeviceName,
                DeviceSerial = CrossDeviceInfo.Current.Id,
                DeviceBrand = CrossDeviceInfo.Current.Manufacturer,
                DeviceModel = CrossDeviceInfo.Current.Model,
                DeviceOperatingSystem = CrossDeviceInfo.Current.Platform.ToString(),
                Longitude = responseGPS.Longitude,
                Latitude = responseGPS.Latitude,
                TypeIncome = "1"
            };

            var jsonRequest = JsonConvert.SerializeObject(registerRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio

            try
            {
                response = await ApiService.ConsumoPOST(ApiService.URL, "api_appsiif/api/User/Register", content);
                result = response.Result;
            }
            catch (InvalidCastException e)
            {
                ShowErrorMessage(e.Message);
                HideLoading();
            }

            if (response.Code >= 400)   
            {
                ShowErrorMessage(response.Result);
                HideLoading();
                return;
            }
            else if (response.Code >= 200 && response.Code < 300)
            {
                RegisterResponse registerResponse = JsonConvert.DeserializeObject<RegisterResponse>(response.Result);
                Settings.RegisterCode = registerResponse.RegisterCode;
                HideLoading();
                ShowSuccessMessage("Registro de dispositivo exitoso.");
                Application.Current.MainPage = new ChangePasswordView(RegisterViewModel.TextVerificationCode);
            }
        }
    }
}
