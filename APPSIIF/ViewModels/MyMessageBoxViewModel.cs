using System;
using APPSIIF.Models.GUI;

namespace APPSIIF.ViewModels
{
    public class MyMessageBoxViewModel : BaseViewModel
    {
        MessageGUI _MessageGUI;
        public MessageGUI MessageGUI
        {
            set { _MessageGUI = value; OnPropertyChanged(); }
            get { return _MessageGUI; }
        }

        public MyMessageBoxViewModel(MessageGUI messageGUI)
        {
            this.MessageGUI = messageGUI;
        }
    }
}

