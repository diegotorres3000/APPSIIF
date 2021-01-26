using APPSIIF.Enums;
using Xamarin.Forms;

namespace APPSIIF.Renderer
{
    public class MyNavigationPageRenderer : NavigationPage
    {

        #region Orientation
        public static readonly BindableProperty OrientationProperty =
        BindableProperty.Create(nameof(Orientation), typeof(Orientation), typeof(MyNavigationPageRenderer), (Orientation)Application.Current.Resources["Orientation"]);
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        #endregion

        public MyNavigationPageRenderer(Page startupPage) : base(startupPage)
        {
            //this.BarTextColor = Color.White;
            this.SetDynamicResource(NavigationPage.BarTextColorProperty, "MyTextColor");
            ToolbarItems.Add(new ToolbarItem("", "exit.png", () =>
            {
                LogOut();
                
            }));
            SetDynamicResource(OrientationProperty, "Orientation");
        }

        async void LogOut()
        {
            var action = await Application.Current.MainPage.DisplayAlert("Información", "¿Esta seguro de salir de la Aplicación?", "Si", "No");
            if (action)
            {
                /*
                var responseGPS = await InfoGPS.InformacionGPS();
                if (!string.IsNullOrEmpty(responseGPS.Message))
                {
                    DependencyService.Get<ILodingPageService>().HideLoadingPage();
                    await DisplayAlert("Error", responseGPS.Message, "Aceptar");
                    return;
                }
                var registro = new Login //NS004001   //GetSHA1(codvEntry.Text),
                {
                    TipoID = Settings.TipoDocumento,
                    NID = Settings.NumeroDocumento,
                    Longitud = responseGPS.Longitud,
                    Latitud = responseGPS.Latitud
                };
                var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(registro);
                var content = new System.Net.Http.StringContent(jsonRequest, Encoding.UTF8, "application/json");
                string result;
                try
                {
                    var response = await ApiService.ConsumoPOST(ApiService.URL, "api_APP/API/usuario/salir", content);
                    result = response.Result;
                }
                catch (Exception ex)
                {
                    DependencyService.Get<ILodingPageService>().HideLoadingPage();
                    await DisplayAlert("Error", "No hay conexion con la Api", "Aceptar");
                    return;
                }
                if (string.IsNullOrEmpty(result) || result == "null" || result == "{\"status\":404,\"message\":\"Not Found\"}")
                {
                    DependencyService.Get<ILodingPageService>().HideLoadingPage();
                    await DisplayAlert("Error", "no se encontraron registros", "Aceptar");
                    return;
                }
                Ingreso respRegistro = new Ingreso();
                respRegistro = JsonConvert.DeserializeObject<Ingreso>(result);
                if (respRegistro.Registro.Codigo == "CAMBIOC") //SI EL TIPO NO ES CORRECTO
                {*/
                //   Application.Current.MainPage = new LoginView("");
                //    Settings.Token = "";
                //}
            }
            //return;
        }

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyNavigationPageRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyNavigationPageRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion
    }
}
