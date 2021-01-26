using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace APPSIIF.Views
{
    public partial class ProgressLoaderView : ContentPage
    {
        public ProgressLoaderView(string message)
        {
            InitializeComponent();
            LabelMessage.Text = message;
        }

        public ProgressLoaderView()
        {
            InitializeComponent();
            LabelMessage.Text = "Cargando...";
        }
    }
}
