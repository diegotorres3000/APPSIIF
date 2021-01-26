using System;
using System.Collections.Generic;
using APPSIIF.Models.GUI;
using APPSIIF.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class MyMessageBoxView : PopupPage
    {
        public MyMessageBoxView(MessageGUI messageGUI)
        {
            InitializeComponent();
            BindingContext = new MyMessageBoxViewModel(messageGUI);
        }
    }
}
