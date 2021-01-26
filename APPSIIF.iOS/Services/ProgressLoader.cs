using System;
using APPSIIF.Interfaces;
using APPSIIF.iOS.Services;
using APPSIIF.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFPlatform = Xamarin.Forms.Platform.iOS.Platform;

[assembly: Dependency(typeof(ProgressLoader))]
namespace APPSIIF.iOS.Services
{
    public class ProgressLoader : IProgressInterface
    {
        private UIView _nativeView;

        public ProgressLoader()
        {
        }

        public void InitLoadingPage(ContentPage loadingIndicatorPage)
        {
            // check if the page parameter is available
            if (loadingIndicatorPage != null)
            {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingIndicatorPage.GetOrCreateRenderer();
                _nativeView = renderer.NativeView;
            }
        }

        public void Hide()
        {
            _nativeView.RemoveFromSuperview();
        }

        public void Show(string title = "Cargando")
        {
            InitLoadingPage(new ProgressLoaderView(title));
            UIApplication.SharedApplication.KeyWindow.AddSubview(_nativeView);
        }
    }

    internal static class PlatformExtension
    {
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement bindable)
        {
            var renderer = XFPlatform.GetRenderer(bindable);
            if (renderer == null)
            {
                renderer = XFPlatform.CreateRenderer(bindable);
                XFPlatform.SetRenderer(bindable, renderer);
            }
            return renderer;
        }
    }
}
