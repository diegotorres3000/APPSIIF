using Xamarin.Forms;
using APPSIIF.Views;
using APPSIIF.Enums;
using APPSIIF.Interfaces;

namespace APPSIIF
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IProgressInterface>();
            SetSizeFrame();
            SetColors();
            SetFontSize();
            SetSizeMenu();
            SetOrientation();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        /*
         * carga los tamaños de la pantalla
         * dentro de una recursos
         */
        void SetSizeFrame()
        {
            Application.Current.Resources.Add("ScreenHeight", ScreenHeight);
            Application.Current.Resources.Add("ScreenWidth", ScreenWidth);
            Application.Current.Resources.Add("NavigationHeight", 48);
        }

        void SetColors()
        {
            Application.Current.Resources["StartColorGradient"] = Color.FromHex(Constants.StartColor);
            Application.Current.Resources["EndColorGradient"] = Color.FromHex(Constants.EndColor);
            Application.Current.Resources["StartColorGradientText"] = Color.FromHex(Constants.StartColor);
            Application.Current.Resources["EndColorGradientText"] = Color.FromHex(Constants.EndColor);
            Application.Current.Resources["BackColor"] = Color.FromHex(Constants.BackColorLight);
            Application.Current.Resources["DarkColor"] = Color.Black;
            Application.Current.Resources["ItemColor"] = Color.FromHex(Constants.ItemColorLight);
            Color color = System.Drawing.Color.FromArgb(50, Color.Black);
            Application.Current.Resources.Add("BackOpacyColor", color);
        }

        /*
        * determina los tamaños de letra
        * que se trabajaran en la aplicacion
        */
        void SetFontSize()
        {
            double MyTitleFontSize = ScreenWidth * 0.06;
            Application.Current.Resources.Add("MyTitleFontSize", (MyTitleFontSize > 35) ? 35 : MyTitleFontSize);
            double MySubTitleFontSize = ScreenWidth * 0.045;
            Application.Current.Resources.Add("MySubTitleFontSize", (MySubTitleFontSize > 30) ? 30 : MySubTitleFontSize);
            double MyContentFontSize = ScreenWidth * 0.04;
            Application.Current.Resources.Add("MyContentFontSize", (MyContentFontSize > 25) ? 25 : MyContentFontSize);
            double MyMicroFontSize = ScreenWidth * 0.035;
            Application.Current.Resources.Add("MyMicroFontSize", (MyMicroFontSize > 20) ? 20 : MyMicroFontSize);
            double MyContentFontSizeSpace = MyContentFontSize * 2.8;
            Application.Current.Resources.Add("MyContentFontSizeSpace", (MyContentFontSizeSpace > 60) ? 60 : MyContentFontSizeSpace);
        }

        /*
        * determina el tamaño del menu
        */
        void SetSizeMenu()
        {
            int NumberOfMenus = ScreenWidth / 160;
            Application.Current.Resources.Add("NumberOfMenus", NumberOfMenus);
            int MyMenuImageSize = (int)(ScreenWidth * 0.06);
            Application.Current.Resources["MyMenuImageSize"] = MyMenuImageSize = (MyMenuImageSize > 70) ? 70 : MyMenuImageSize;
            Application.Current.Resources["MyMenuFullSize"] = MyMenuImageSize * 3;
            int MySideMargin = (int)(ScreenWidth * 0.04);
            Application.Current.Resources["MySideMargin"] = MySideMargin = (MySideMargin > 40) ? 40 : MySideMargin;
            int MyEndsMargin = MyMenuImageSize / 2;
            int MyEndsMarginList = MyEndsMargin / 2;
            Application.Current.Resources["MyEndsMargin"] = MyEndsMargin;
            Application.Current.Resources["MyEndsMarginList"] = MyEndsMarginList;
            Application.Current.Resources["MyTitleMargin"] = new Thickness(0, 0, 0, MySideMargin);
            Application.Current.Resources["MyElementFormMargin"] = new Thickness(MySideMargin, 0, MySideMargin, MyEndsMarginList);
        }

        void SetOrientation()
        {
            Orientation Orientation = Orientation.LandScape;
            Application.Current.Resources.Add("Orientation", Orientation);
        }
    }
}
