using System;
using APPSIIF.Renderer;
using APPSIIF.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyProgressBarRenderer), typeof(MyProgressBarRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyProgressBarRendererAndroid : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);
            MyProgressBarRenderer myProgressBarRenderer = (MyProgressBarRenderer)Element;

            //Control.ProgressDrawable.SetColorFilter(Color.FromHex("#D9E0EC").ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
            //Control.ProgressTintListColor.FromRgb(182, 231, 233).ToAndroid();
            //Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.FromHex("#D9E0EC").ToAndroid());
            Control.ScaleY = (float)myProgressBarRenderer.ProgressHeight;

        }
    }
}
