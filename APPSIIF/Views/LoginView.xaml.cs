using System;
using System.Text;
using APPSIIF.Renderer;
using APPSIIF.Models.Hash;
using SHA3.Net;
using Xamarin.Forms;
using APPSIIF.ViewModels;
using APPSIIF.Models.Api;
using APPSIIF.Services;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Net.Http;
using APPSIIF.Helpers;

namespace APPSIIF.Views
{
    public partial class LoginView : MyContentPageRenderer
    {
        private LoginViewModel LoginViewModel;

        public LoginView()
        {
            InitializeComponent();
            
            this.BindingContext = LoginViewModel = new LoginViewModel();
            LoginViewModel.IsRememberingUserName = Settings.IsRememberingUserName;
            LoginViewModel.TextNickName = Settings.NickName;
            Initializator();
        }

        private async void Initializator()
        {
            if (!string.IsNullOrEmpty(Settings.RefreshToken))
            {
                await RefreshToken();
                if (IsRefreshed)
                {
                    ShowSuccessMessage("Bienvenido!");
                    Application.Current.MainPage = new MenuView(Settings.UserName);
                }
            }
        }

        async void RememberUserName(object sender, ToggledEventArgs e)
        {
            Switch sw = (Switch)sender;
            Settings.IsRememberingUserName = sw.IsToggled;
            if (sw.IsToggled)
            {
                if (String.IsNullOrEmpty(LoginViewModel.TextNickName))
                {
                    ShowErrorMessage("Necesitas digitar el nombre de usuario.");
                    sw.IsToggled = false;
                }
                else
                {
                    Settings.NickName = LoginViewModel.TextNickName;
                }
            }
            else
            {
                Settings.NickName = "";
            }
        }

        async void LoginClicked(object sender, EventArgs args)
        {
            ShowLoading();

            var responseGPS = await InfoGPS.InformacionGPS();
            if (!string.IsNullOrEmpty(responseGPS.Message))
            {
                HideLoading();
                ShowErrorMessage(responseGPS.Message);
                return;
            }

            LoginRequest loginRequest = new LoginRequest
            {
                NickName = LoginViewModel.TextNickName,
                Password = LoginViewModel.TextPassword,
                RegisterCode = Settings.RegisterCode,
                Longitude = responseGPS.Longitude,
                Latitude = responseGPS.Latitude,
                IpAdress = GetIpAdress(),
                TypeIncome = "1"
            };

            var jsonRequest = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio

            try
            {
                response = await ApiService.ConsumoPOST(ApiService.URL, "api_appsiif/api/User/Login", content);
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
                HideLoading();
                ShowSuccessMessage("Bienvenido!");
            }

            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Result);
            Settings.RefreshToken = loginResponse.RefreshToken;
            Settings.JwtToken = loginResponse.JwtToken;
            Settings.Code = loginResponse.Code;
            Settings.UserName = loginResponse.UserName;
            Application.Current.MainPage = new MenuView(loginResponse.UserName);
        }

        async void RegisterClicked(object sender, EventArgs args)
        {
            Application.Current.MainPage = new RegisterView();
        }

        async void RecoverPasswordClicked(object sender, EventArgs args)
        {
        }

        public string GetIpAdress()
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return addrInfo.Address.ToString();
                        }
                    }
                }
            }
            return null;
        }

        public string HashByCript(string password)
        {
            string myPassword = password;
            string mySalt = BCrypt.GenerateSalt();
            //mySalt == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO"
            string myHash = BCrypt.HashPassword(myPassword, mySalt);
            //myHash == "$2a$10$rBV2JDeWW3.vKyeQcM8fFO4777l4bVeQgDL6VIkxqlzQ7TCalQvla"
            bool doesPasswordMatch = BCrypt.CheckPassword(myPassword, myHash);
            return "";
        }
    }
}
