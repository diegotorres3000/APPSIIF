using System;
using APPSIIF.Renderer;

using System.Collections.Generic;

using Xamarin.Forms;
using APPSIIF.ViewModels;
using APPSIIF.Models.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using APPSIIF.Services;
using APPSIIF.Helpers;

namespace APPSIIF.Views
{
    public partial class FavoriteMenuView : MyContentPageRenderer
    {
        AddFavoritePageView AddFavoritePageView;
        FavoriteMenuViewModel FavoriteMenuViewModel;

        public FavoriteMenuView()
        {
            InitializeComponent();
            BindingContext = FavoriteMenuViewModel = new FavoriteMenuViewModel();
        }

        public async void SelectFavoritePage(object sender, SelectedItemChangedEventArgs e)
        {
            FavoritePage favoritePage = e.SelectedItem as FavoritePage;
            if (favoritePage != null)
            {
                var myClassType = Type.GetType(string.Format("{0}.{1}", Constants.NameSpace, favoritePage.Page + "View"));

                if (myClassType != null)
                    await Navigation.PushAsync((MyContentPageRenderer)Activator.CreateInstance(myClassType));
                else
                    await Navigation.PushAsync(new NotFoundView());
            }
            ((ListView)sender).SelectedItem = null;
        }

        private async void getMenus()
        {
            /*AddFavoritePageView = new AddFavoritePageView(new List<FavoritePage>(FavoriteMenuViewModel.FavoritePages));
            AddFavoritePageView.OperationCompleted += SecondaryPage_OperationCompleted;
            await Navigation.PushAsync(AddFavoritePageView);*/

            ShowLoading();

            MenuRequest menuRequest = new MenuRequest
            {
                profile = "CONSULTA1"
            };

            var jsonRequest = JsonConvert.SerializeObject(menuRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            var response = new Response();
            string result;

            //envio

            try
            {
                response = await ApiService.ConsumoPOST(ApiService.URL, "/apiRPC/api/Menu/Socket", content);
                result = response.Result;
            }
            catch
            {

            }

            if (response.Code >= 400)
            {
                if (response.Code == 401)
                {
                    Settings.JwtToken = "";
                    RefreshToken();
                    if (IsRefreshed)
                        getMenus();
                    return;
                }
                else
                {
                    ShowErrorMessage(response.Message);
                    HideLoading();
                    return;
                }
            }
            else if (response.Code >= 200 && response.Code < 300)
            {
                List<Models.Menu.MenuItem> menuItems = JsonConvert.DeserializeObject<List<Models.Menu.MenuItem>>(response.Result);
                HideLoading();
                ShowSuccessMessage("Exito!");
            }
        }

        async void OnAddFovirePageTap(object sender, EventArgs args)
        {
            getMenus();
        }

        private async void SecondaryPage_OperationCompleted(object sender, EventArgs e)
        {
            FavoriteMenuViewModel.AddFavoritePage(AddFavoritePageView.GetFavoritePage());
        }
    }
}
