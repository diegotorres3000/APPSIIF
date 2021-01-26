using CoreAnimation;
using CoreGraphics;
using APPSIIF.iOS.Renderer;
using APPSIIF.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyNavigationPageRenderer), typeof(MyNavigationPageRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyNavigationPageRendererIos : NavigationRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            MyNavigationPageRenderer myNavigationPageRenderer = (MyNavigationPageRenderer)this.Element;
            
            var gradientLayer = new CAGradientLayer();
            gradientLayer.Bounds = NavigationBar.Bounds;
            gradientLayer.Colors = new CGColor[] {
                myNavigationPageRenderer.StartColor.ToCGColor(),
                myNavigationPageRenderer.EndColor.ToCGColor() };
            gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
            gradientLayer.EndPoint = new CGPoint(1.0, 0.5);

            UIGraphics.BeginImageContext(gradientLayer.Bounds.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            NavigationBar.ShadowImage = new UIImage();
            NavigationBar.SetBackgroundImage(image, UIBarMetrics.Default);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Element.PropertyChanged += OnElementPropertyChanged;
        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == MyContentPageRenderer.OrientationProperty.PropertyName)
            {
                MyNavigationPageRenderer myNavigationPageRenderer = (MyNavigationPageRenderer)this.Element;

                var gradientLayer = new CAGradientLayer();
                gradientLayer.Bounds = NavigationBar.Bounds;
                gradientLayer.Colors = new CGColor[] {
                myNavigationPageRenderer.StartColor.ToCGColor(),
                myNavigationPageRenderer.EndColor.ToCGColor() };
                gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
                gradientLayer.EndPoint = new CGPoint(1.0, 0.5);

                UIGraphics.BeginImageContext(gradientLayer.Bounds.Size);
                gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
                UIImage image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                NavigationBar.ShadowImage = new UIImage();
                NavigationBar.SetBackgroundImage(image, UIBarMetrics.Default);
            }
        }
    }
}
