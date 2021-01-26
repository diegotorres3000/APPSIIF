using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Renderer;
using APPSIIF.Droid.Renderer;
using System.Net;

[assembly: ExportRenderer(typeof(MyPdfRenderer), typeof(MyPdfRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyPdfRendererAndroid : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                MyPdfRenderer customWebView = Element as MyPdfRenderer;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", WebUtility.UrlEncode(customWebView.Uri)));
            }
        }
    }
}
