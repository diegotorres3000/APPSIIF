using System.Collections.Generic;
using APPSIIF.Models.Menu;

namespace APPSIIF.ViewModels
{
    public class SubMenuViewModel : BaseViewModel
    {
        public List<MenuItem> MenuItems { get; set; }

        int _NumberOfMenus;
        public int NumberOfMenus
        {
            set { _NumberOfMenus = value; OnPropertyChanged();}
            get { return _NumberOfMenus; }
        }

        public SubMenuViewModel(List<MenuItem> MenuItems)
        {
            this.MenuItems = MenuItems;
            NumberOfMenus = 3;
        }
    }
}
