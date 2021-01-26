using System;
using APPSIIF.Interfaces;
using AndroidHUD;
using Xamarin.Forms;
using APPSIIF.Droid.Services;

[assembly: Dependency(typeof(ProgressLoader))]
namespace APPSIIF.Droid.Services
{
    public class ProgressLoader : IProgressInterface
    {
        public ProgressLoader()
        {
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread( () => 
            {
                AndHUD.Shared.Dismiss();
            });
        }

        public void Show(string title = "Cargando")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                AndHUD.Shared.Show(Forms.Context, status: title, maskType: MaskType.Black);
            });
        }
    }
}
