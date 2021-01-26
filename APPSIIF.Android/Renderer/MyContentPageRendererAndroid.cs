using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Renderer;
using APPSIIF.Droid.Renderer;
using Android.Graphics;

[assembly: ExportRenderer(typeof(MyContentPageRenderer), typeof(MyContentPageRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyContentPageRendererAndroid :  PageRenderer
    {
        protected override void DispatchDraw(Canvas canvas)
        {
            MyContentPageRenderer myContentPageRenderer = (MyContentPageRenderer)Element;
            if (myContentPageRenderer.IsGradient)
            {
                var gradient = new LinearGradient(0, 0, 0, Height,
                    myContentPageRenderer.StartColor.ToAndroid(),
                    myContentPageRenderer.EndColor.ToAndroid(),
                    Shader.TileMode.Mirror);
                var paint = new Paint
                {
                    Dither = true,
                };
                paint.SetShader(gradient);
                canvas.DrawPaint(paint);
            }
            
            base.DispatchDraw(canvas);
        }
    }
}
