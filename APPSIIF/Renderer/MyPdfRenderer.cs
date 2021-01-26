
using Xamarin.Forms;

namespace APPSIIF.Renderer
{
    public class MyPdfRenderer : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create("Uri",typeof(string),typeof(MyPdfRenderer),default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}
