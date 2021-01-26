using System.Collections.Generic;
using APPSIIF.Renderer;
using APPSIIF.ViewModels;
using APPSIIF.Models.Api;
using MenuItem = APPSIIF.Models.Menu.MenuItem;
using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class ClientLoansView : MyContentPageRenderer
    {
        public ClientLoansView()
        {
            InitializeComponent();
            BindingContext = new ClientLoansViewModel();
        }

        private async void SelectedLoan(object sender, SelectedItemChangedEventArgs e)
        {
            Loan loan = (Loan)e.SelectedItem;
            if (loan != null)
            {
                List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Consulta Basica",
                    Page = "BasicInformationLoan"
                },
                new MenuItem
                {
                    Title = "Facturacion",
                    Page = ""
                },
                new MenuItem
                {
                    Title = "Movimientos Historicos",
                    Page = ""
                },
                new MenuItem
                {
                    Title = "Planes de Pago",
                    Page = ""
                },
                new MenuItem
                {
                    Title = "Grantias",
                    Page = ""
                },
                new MenuItem
                {
                    Title = "Cuentas Corrientes",
                    Page = ""
                }
            };

                List<bool> status = new List<bool>
            {
                true, true, true, true, true, true
            };

                await Navigation.PushAsync(new SubMenuView(menuItems, status));
            }
           ((ListView)sender).SelectedItem = null;
        }
    }
}
