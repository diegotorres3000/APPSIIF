using System;
using System.Collections.Generic;
using APPSIIF.Interfaces;
using APPSIIF.Models.Api;
using APPSIIF.Models.GUI;
using APPSIIF.Renderer;
using APPSIIF.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class AddFavoritePageView : MyContentPageRenderer
    {
        private AddFavoritePageViewModel AddFavoritePageViewModel;
        public event EventHandler<EventArgs> OperationCompleted;

        public AddFavoritePageView(List<FavoritePage> AddedFavoritePages)
        {
            InitializeComponent();
            BindingContext = AddFavoritePageViewModel = new AddFavoritePageViewModel(AddedFavoritePages);
        }

        public async void SelectFavoritePage(object sender, SelectedItemChangedEventArgs e)
        {
            FavoritePage favoritePage = e.SelectedItem as FavoritePage;
            if (favoritePage != null)
            {

                //DependencyService.Get<IProgressInterface>().Show();

                App.Current.MainPage.Navigation.PushPopupAsync(new MyMessageBoxView(AddErrorMessage("Error al agregar la fucion")), true);
                //App.CSurrent.MainPage.Navigation.PushPopupAsync(new MyMessageBoxView(AddSuccessMessage("Funcion agregada correctamente a tus funciones mas utilizadas")), true);

                /*if (favoritePage.ItsBeingUsed)
                {
                    RemoveFavoritePage();
                }
                else
                {
                    AddFavoritePage();
                }
                */
                favoritePage.ItsBeingUsed = !favoritePage.ItsBeingUsed;
                AddFavoritePageViewModel.FavoritePageSelected = favoritePage;
            }
            ((ListView)sender).SelectedItem = null;
        }

        public string AddFavoritePage()
        {
            return "EXITO";
        }

        public string RemoveFavoritePage()
        {
            return "EXITO";
        }

        public MessageGUI AddSuccessMessage(string Message)
        {
            return new MessageGUI
            {
                Message = Message,
                Color = (Color)Application.Current.Resources["MyGreen"],
                Animation = "success.json"
            };
        }

        public MessageGUI AddErrorMessage(string Message)
        {
            return new MessageGUI
            {
                Message = Message,
                Color = (Color)Application.Current.Resources["MyRed"],
                Animation = "error.json"
            };
        }

        protected override void OnDisappearing()
        {
            OperationCompleted?.Invoke(this, EventArgs.Empty);
            base.OnDisappearing();
        }

        public FavoritePage GetFavoritePage()
        {
            if (AddFavoritePageViewModel.FavoritePageSelected != null)
                AddFavoritePageViewModel.FavoritePageSelected.ItsBeingUsed = false;
            return AddFavoritePageViewModel.FavoritePageSelected;
        }
    }
}
