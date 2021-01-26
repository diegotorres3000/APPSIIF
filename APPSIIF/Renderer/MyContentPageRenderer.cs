using Xamarin.Forms;
using APPSIIF.Enums;
using APPSIIF.Interfaces;
using Rg.Plugins.Popup.Extensions;
using APPSIIF.Views;
using APPSIIF.Models.GUI;
using APPSIIF.Helpers;
using APPSIIF.Models.Api;
using Newtonsoft.Json;
using APPSIIF.Services;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APPSIIF.Renderer
{
    /*
     * clase donde se pinta una vista principal
     * permitiendo generalizar el metodo de refrescado
     */
    public class MyContentPageRenderer : ContentPage
    {
        #region StartColor
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyContentPageRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyContentPageRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyContentPageRenderer), true);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty);
            set => SetValue(IsGradientProperty, value);
        }
        #endregion

        #region Orientation
        public static readonly BindableProperty OrientationProperty =
        BindableProperty.Create(nameof(Orientation), typeof(Orientation), typeof(MyContentPageRenderer), (Orientation)Application.Current.Resources["Orientation"]);
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        #endregion

        public bool IsRefreshed { get; set; }

        public MyContentPageRenderer()
        {
            SetDynamicResource(OrientationProperty, "Orientation");
        }

        public void ShowLoading()
        {
            DependencyService.Get<IProgressInterface>().Show();
        }

        public void HideLoading()
        {
            DependencyService.Get<IProgressInterface>().Hide();
        }

        public void ShowErrorMessage(string Message)
        {
            var vec = Message.Split('');

            for (int i = 0 ; i < vec.Length ; i++)
            {
                App.Current.MainPage.Navigation.PushPopupAsync(new MyMessageBoxView(new MessageGUI
                {
                    Message = vec[i],
                    Color = (Color)Application.Current.Resources["MyRed"],
                    Animation = "error.json"
                }), true);
            }

            
        }

        public void ShowSuccessMessage(string Message)
        {
            App.Current.MainPage.Navigation.PushPopupAsync(new MyMessageBoxView(new MessageGUI
            {
                Message = Message,
                Color = (Color)Application.Current.Resources["MyGreen"],
                Animation = "success.json"
            }), true);
        }

        public async Task RefreshToken()
        {
            ShowLoading();

            RefreshRequest refreshRequest = new RefreshRequest
            {
                Code = Settings.Code,
                RegisterCode = Settings.RegisterCode,
                TokenRefresh = Settings.RefreshToken,
                TypeIncome = "1"
            };

            var jsonRequest = JsonConvert.SerializeObject(refreshRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio
            try
            {
                response = await ApiService.ConsumoPOST(ApiService.URL, "api_appsiif/api/User/RefreshToken", content);
                result = response.Result;

                if (response.Code >= 400)
                {
                    if (response.Code == 401)
                    {
                        Settings.RefreshToken = "";
                        Settings.JwtToken = "";
                        Settings.Code = "";
                        ShowErrorMessage("Su sesion Caduco por favor vuelvase a logear.");
                        HideLoading();
                        IsRefreshed = false;
                    }
                    else
                    {
                        ShowErrorMessage(response.Result);
                        HideLoading();
                        IsRefreshed = false;
                    }
                }
                else if (response.Code >= 200 && response.Code < 300)
                {
                    RefreshResponse refreshResponse = JsonConvert.DeserializeObject<RefreshResponse>(response.Result);
                    Settings.RefreshToken = refreshResponse.RefreshToken;
                    Settings.JwtToken = refreshResponse.JwtToken;
                    Settings.Code = refreshResponse.Code;
                    HideLoading();
                    IsRefreshed = true;
                }
            }
            catch
            {
                IsRefreshed = false;
            }
        }

        virtual public void RefreshPage()
        {

        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            int ScreenWidth = (int)width;
            int NumberOfMenus = ScreenWidth / 160;
            NumberOfMenus = (NumberOfMenus > 4) ? 4 : NumberOfMenus;
            Application.Current.Resources["NumberOfMenus"] = NumberOfMenus;
            double MyMenuImageSize = ScreenWidth * 0.06;
            Application.Current.Resources["MyMenuImageSize"] = (MyMenuImageSize > 50) ? 50 : MyMenuImageSize;

            if (width > height)
                Application.Current.Resources["Orientation"] = Orientation.LandScape;
            else
                Application.Current.Resources["Orientation"] = Orientation.Portrait;
        }
    }
}
