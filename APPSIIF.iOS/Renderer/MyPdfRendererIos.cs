using System.IO;
using Foundation;
using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(MyPdfRenderer), typeof(MyPdfRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyPdfRendererIos : ViewRenderer<MyPdfRenderer, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MyPdfRenderer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as MyPdfRenderer;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, customWebView.Uri);
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                Control.ScalesPageToFit = true;
            }
        }
    }
}
