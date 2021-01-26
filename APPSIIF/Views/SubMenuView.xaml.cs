using System;
using System.Linq;
using APPSIIF.Renderer;
using APPSIIF.ViewModels;
using MenuItem = APPSIIF.Models.Menu.MenuItem;
using Xamarin.Forms;
using System.Collections.Generic;
using APPSIIF.Models.Api;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using APPSIIF.Services;
using System.Threading.Tasks;

namespace APPSIIF.Views
{
    public partial class SubMenuView : MyContentPageRenderer
    {
        GridItemsLayout grid;
        private List<MenuItem> MenuItemsAux;

        public SubMenuView(List<MenuItem> list)
        {
            InitializeComponent();
            SetNunberColumns();
            BindingContext = new SubMenuViewModel(list);
        }

        public SubMenuView(List<MenuItem> menuItems, List<bool> status)
        {
            InitializeComponent();
            SetNunberColumns();
            List<MenuItem> finalMenuItems = new List<MenuItem>();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (status[i])
                {
                    finalMenuItems.Add(menuItems[i]);
                }
            }
            BindingContext = new SubMenuViewModel(finalMenuItems);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            SetNunberColumns();
        }

        public void SetNunberColumns()
        {
            if (grid == null)
            {
                grid = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                {
                    Span = (int)Application.Current.Resources["NumberOfMenus"],
                    HorizontalItemSpacing = 20,
                    VerticalItemSpacing = 20
                };
                Menu.SetValue(CollectionView.ItemsLayoutProperty, grid);
            }
            else
                grid.Span = (int)Application.Current.Resources["NumberOfMenus"];
        }

        async private void SelectCurrentSubMenu(object sender, SelectionChangedEventArgs e)
        {
            MenuItem item = (e.CurrentSelection.FirstOrDefault()) as MenuItem;
            ((CollectionView)sender).SelectedItem = null;
            if (item != null)
            {
                if (String.IsNullOrEmpty(item.Function))
                {
                    await GetMenus(item.Profile);
                    await Navigation.PushAsync(new SubMenuView(MenuItemsAux));
                    MenuItemsAux = null;
                    return;
                }
                var myClassType = Type.GetType(String.Format("{0}.{1}", Constants.NameSpace, item.Page+"View"));

                if (myClassType != null)
                {
                    await Navigation.PushAsync((MyContentPageRenderer)Activator.CreateInstance(myClassType));
                }else
                {
                    await Navigation.PushAsync(new NotFoundView());
                    //await Navigation.PopAsync();
                }
            }
        }

        private async Task GetMenus(string profile)
        {
            ShowLoading();

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
                response = await ApiService.ConsumoPOST(ApiService.URL, "api_appsiif/api/User/GetMenu", content);
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
                MenuItemsAux = JsonConvert.DeserializeObject<List<MenuItem>>(response.Result);
                HideLoading();
                return;
            }
        }
    }
}
