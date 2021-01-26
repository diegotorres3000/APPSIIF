using System;
using System.Collections.Generic;
using APPSIIF.Models.Api;
using APPSIIF.Models.GUI;
using Xamarin.Forms;

namespace APPSIIF.ViewModels
{
    public class AddFavoritePageViewModel : BaseViewModel
    {
        public List<FavoritePage> FavoritePages { get; set; }

        FavoritePage _FavoritePageSelected;
        public FavoritePage FavoritePageSelected
        {
            set { _FavoritePageSelected = value; OnPropertyChanged(); }
            get { return _FavoritePageSelected; }
        }

        public AddFavoritePageViewModel(List<FavoritePage> AddedFavoritePages)
        {
            FavoritePages = new List<FavoritePage>
            {
                new FavoritePage
                {
                    Title = "Buscar Cliente",
                    Icon = "empresa",
                    Module = "Clientes",
                    Page = "FindClient"
                },
                new FavoritePage
                {
                    Title = "Buscar Prestamo",
                    Icon = "empresa",
                    Module = "Colocaciones",
                    Page = "PAGE2"
                },
                new FavoritePage
                {
                    Title = "Buscar Plan de intereses",
                    Icon = "empresa",
                    Module = "Colocaciones",
                    Page = "PAGE3"
                },
                new FavoritePage
                {
                    Title = "Buscar Tasas de interes",
                    Icon = "empresa",
                    Module = "Captaciones",
                    Page = "PAGE4"
                },
                new FavoritePage
                {
                    Title = "Buscar Tasas de interes",
                    Icon = "empresa",
                    Module = "Captaciones",
                    Page = "PAGE5"
                },
                new FavoritePage
                {
                    Title = "Buscar Tasas de interes",
                    Icon = "empresa",
                    Module = "Captaciones",
                    Page = "PAGE6"
                },
                new FavoritePage
                {
                    Title = "Buscar Tasas de interes",
                    Icon = "empresa",
                    Module = "Captaciones",
                    Page = "PAGE7"
                },
                new FavoritePage
                {
                    Title = "Buscar Tasas de interes",
                    Icon = "empresa",
                    Module = "Captaciones",
                    Page = "PAGE8"
                }
            };
            foreach (FavoritePage favoritePage in AddedFavoritePages)
            {
                FavoritePages.Find(item => item.Page == favoritePage.Page).ItsBeingUsed = true;
            }
        }
    }
}
