using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using CoreAnimation;
using CoreGraphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyContentPageRenderer), typeof(MyContentPageRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyContentPageRendererIos : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if (View.Layer.Sublayers != null)
                {
                    if (View.Layer.Sublayers.Length > 1)
                    {
                        View.Layer.Sublayers[0].RemoveFromSuperLayer();
                    }
                }

                MyContentPageRenderer page = (MyContentPageRenderer)Element;

                if (page.IsGradient)
                {
                    var gradientLayer = new CAGradientLayer();
                    gradientLayer.Frame = View.Bounds;
                    gradientLayer.Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() };
                    View.Layer.InsertSublayer(gradientLayer, 0);
                }
            }
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
                if (View.Layer.Sublayers.Length > 1)
                {
                    View.Layer.Sublayers[0].RemoveFromSuperLayer();
                }

                MyContentPageRenderer page = (MyContentPageRenderer)Element;

                if (page.IsGradient)
                {
                    var gradientLayer = new CAGradientLayer();
                    gradientLayer.Frame = View.Bounds;
                    gradientLayer.Colors = new CGColor[] { page.StartColor.ToCGColor(), page.EndColor.ToCGColor() };
                    View.Layer.InsertSublayer(gradientLayer, 0);
                }
            }
        }
    }
}
