using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using APPSIIF.Models.Api;
using APPSIIF.Models.GUI;
using APPSIIF.Models.Menu;
using APPSIIF.Services;
using APPSIIF.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using MenuItem = APPSIIF.Models.Menu.MenuItem;

namespace APPSIIF.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public string NamePerson { get; set; }

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public MenuViewModel(string NamePerson)
        {
            this.NamePerson = NamePerson;
            MenuItems = new ObservableCollection<MenuItem>();
        }

        public void AddMenu(string Title, string Icon, string Page)
        {
            MenuItems.Add(new MenuItem
            {
                Title = Title,
                Icon = Icon,
                Page = Page
            });
        }

        public void AddMenu(MenuItem menuItem)
        {
            MenuItems.Add(menuItem);
        }

        public MenuItem GetMenuItem(int i)
        {
            return MenuItems[i];
        }
    }
}
