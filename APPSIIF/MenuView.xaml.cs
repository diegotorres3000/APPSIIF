using System;

using APPSIIF.ViewModels;
using APPSIIF.Views;
using APPSIIF.Models.Api;
using MenuItem = APPSIIF.Models.Menu.MenuItem;
using APPSIIF.Renderer;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using APPSIIF.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using APPSIIF.Services;
using Rg.Plugins.Popup.Extensions;
using APPSIIF.Models.GUI;
using System.Threading.Tasks;

namespace APPSIIF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : MasterDetailPage 
    {
        public static MenuViewModel MenuViewModel;
        private List<MenuItem> MenuItemsAux;

        public MenuView(string NamePerson)
        {
            InitializeComponent();
            MenuViewModel = new MenuViewModel(NamePerson);
            BindingContext = MenuViewModel;
            Initializator();
            Detail = new MyNavigationPageRenderer(new NotFoundView());
        }

        private async void SelectMenuItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItem;
            if (item == null)
                return;
            if (String.IsNullOrEmpty(item.Function))
            {
                await GetMenus(item.Profile);
                Detail = new MyNavigationPageRenderer(new SubMenuView(MenuItemsAux));
                MenuItemsAux = null;
                return;
            }
            var myClassType = Type.GetType(String.Format("{0}.{1}", Constants.NameSpace, item.Page+"View"));
            if (myClassType != null)
                Detail = new MyNavigationPageRenderer((MyContentPageRenderer)Activator.CreateInstance(myClassType));
            else
                Detail = new MyNavigationPageRenderer(new NotFoundView());
            IsPresented = false;
            ((ListView)sender).SelectedItem = null;
        }

        /*
         * metodo que se ejcuta cuando se cierra
         * la ventana de ajustes
         */
        private void SecondaryPage_OperationCompleted(object sender, EventArgs e)
        {
        }

        private async void Initializator()
        {
            await GetMenus("");

            if (MenuItemsAux != null)
            {
                foreach (MenuItem menuItem in MenuItemsAux)
                {
                    MenuViewModel.AddMenu(menuItem);
                }
                MenuItemsAux = null;
            }

            if (MenuViewModel.MenuItems.Count != 0)
            {
                var myClassType = Type.GetType(String.Format("{0}.{1}", Constants.NameSpace, MenuViewModel.GetMenuItem(0).Page + "View"));
                if (myClassType != null)
                    Detail = new MyNavigationPageRenderer((MyContentPageRenderer)Activator.CreateInstance(myClassType));
                else
                    Detail = new MyNavigationPageRenderer(new NotFoundView());
            }
            else
            {
                Detail = new MyNavigationPageRenderer(new NotFoundView());
            }
        }

        private async Task GetMenus(string profile)
        {
            DependencyService.Get<IProgressInterface>().Show();

            MenuRequest menuRequest = new MenuRequest
            {
                profile = profile
            };

            var jsonRequest = JsonConvert.SerializeObject(menuRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio

            try
            {
                response = await ApiService.ConsumoGET(ApiService.URL, "api/User/GetMenu", new Dictionary<string, string> { {"profile", "" } });
                result = response.Result;
            }
            catch
            {

            }

            if (response.Code >= 400)
            {
                ShowErrorMessage(response.Result);
                DependencyService.Get<IProgressInterface>().Hide();
                return;
            }
            else if (response.Code >= 200 && response.Code < 300)
            {
                MenuItemsAux = JsonConvert.DeserializeObject<List<MenuItem>>(response.Result);
                DependencyService.Get<IProgressInterface>().Hide();
                return;
            }
        }

        public void ShowErrorMessage(string Message)
        {
            var vec = Message.Split('');

            for (int i = 0; i < vec.Length; i++)
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
    }
}
