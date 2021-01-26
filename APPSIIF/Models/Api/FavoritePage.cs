using System;
using APPSIIF.ViewModels;

namespace APPSIIF.Models.Api
{
    public class FavoritePage : BaseViewModel
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public string Page { get; set; }
        public string Icon { get; set; }


        bool _ItsBeingUsed;
        public bool ItsBeingUsed
        {
            set { _ItsBeingUsed = value; OnPropertyChanged(); }
            get { return _ItsBeingUsed; }
        }
    }
}
