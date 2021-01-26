using System;
using System.Collections.Generic;
using APPSIIF.Renderer;
using MenuItem = APPSIIF.Models.Menu.MenuItem;
using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class FindClientView : MyContentPageRenderer
    {
        public FindClientView()
        {
            InitializeComponent();
        }

        async void FindClientClicked(object sender, EventArgs args)
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Informacion Basica del Cliente",
                    Page = "ClientBasicInformation",
                    Icon = "APPNPL"
                },
                new MenuItem
                {
                    Title = "Informacion Finaciera",
                    Page = "ClientFinancialInformation",
                    Icon = "APPVOR"
                },
                new MenuItem
                {
                    Title = "Direcciones",
                    Page = "ClientAddresses",
                    Icon = "bank"
                },
                new MenuItem
                {
                    Title = "Colocaciones",
                    Page = "ClientLoans",
                    Icon = "idPerson"
                },
                new MenuItem
                {
                    Title = "Informacion Crediticia",
                    Page = "ClientCreditInformation"
                },
                new MenuItem
                {
                    Title = "Cuentas Corrientes",
                    Page = "ClientCurrentAccounts"
                }
            };

            List<bool> status = new List<bool>
            {
                true, true, true, true, true, true
            };

            await Navigation.PushAsync(new SubMenuView(menuItems, status));
        }
    }
}
