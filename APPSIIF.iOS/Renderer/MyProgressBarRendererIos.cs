using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(MyProgressBarRenderer), typeof(MyProgressBarRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyProgressBarRendererIos : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.TrackTintColor = Color.FromHex("#D9E0EC").ToUIColor();
            }
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MyProgressBarRenderer myProgressBarRenderer = (MyProgressBarRenderer)Element;

            var X = 1.0f;
            var Y = myProgressBarRenderer.ProgressHeight;

            CGAffineTransform transform = CGAffineTransform.MakeScale(X, (float)Y);
            this.Transform = transform;



            this.ClipsToBounds = true;
            this.Layer.MasksToBounds = true;
        }
    }
}
