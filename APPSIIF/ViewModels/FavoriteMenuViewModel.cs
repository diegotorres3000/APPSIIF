
using System.Collections.ObjectModel;
using APPSIIF.Models.Api;

namespace APPSIIF.ViewModels
{
    public class FavoriteMenuViewModel :  BaseViewModel
    {
        public ObservableCollection<FavoritePage> FavoritePages { get; set; }

        public FavoriteMenuViewModel()
        {
            FavoritePages = new ObservableCollection<FavoritePage>();
        }

        public void AddFavoritePage(FavoritePage favoritePage)
        {
            if (favoritePage != null)
            {
                FavoritePages.Add(favoritePage);
            }
        }
    }
}
