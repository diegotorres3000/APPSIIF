using System;
using APPSIIF.ViewModels;
using Xamarin.Forms;

namespace APPSIIF.Models.GUI
{
    public class MessageGUI : BaseViewModel
    {
        string _Message;
        public string Message
        {
            set { _Message = value; OnPropertyChanged(); }
            get { return _Message; }
        }

        Color _Color;
        public Color Color
        {
            set { _Color = value; OnPropertyChanged(); }
            get { return _Color; }
        }

        string _Animation;
        public string Animation
        {
            set { _Animation = value; OnPropertyChanged(); }
            get { return _Animation; }
        }
    }
}
