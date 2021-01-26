using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Renderer;
using APPSIIF.Droid.Renderer;
using Android.Graphics.Drawables;
using APPSIIF.Enums;
using static Android.Graphics.Drawables.GradientDrawable;
using System.ComponentModel;
using Orientation = Android.Graphics.Drawables.GradientDrawable.Orientation;

[assembly: ExportRenderer(typeof(MyFrameRenderer), typeof(MyFrameRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyFrameRendererAndroid : VisualElementRenderer<MyFrameRenderer>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MyFrameRenderer> e)
        {
            base.OnElementChanged(e);
            if ((e.OldElement == null))
            {
                SetBackgroundColor(Android.Graphics.Color.Transparent);
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                GradientDrawable gradientDrawable = new GradientDrawable();
                if (myFrameRenderer.IsGradient)
                {
                    gradientDrawable = new GradientDrawable(
                        Orientation.LeftRight,
                        new int[] { myFrameRenderer.StartColor.ToAndroid(),
                            myFrameRenderer.EndColor.ToAndroid() });
                }
                else
                {
                    gradientDrawable.SetColor(myFrameRenderer.StaticColor.ToAndroid());
                }
                
                switch (myFrameRenderer.TypeBorder)
                {
                    case TypeBorder.All:
                        gradientDrawable.SetCornerRadii(new float[]{myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2});
                        break;
                    case TypeBorder.Left:
                        gradientDrawable.SetCornerRadii(new float[]{myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            0, 0,
                            0, 0,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2});
                        break;
                    case TypeBorder.Right:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            0, 0});
                        break;
                    case TypeBorder.Down:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0,
                            0, 0,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2});
                        break;
                    case TypeBorder.Up:
                        gradientDrawable.SetCornerRadii(new float[]{myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            myFrameRenderer.BorderRadius*2, myFrameRenderer.BorderRadius*2,
                            0, 0,
                            0, 0});
                        break;
                }
                if (myFrameRenderer.HasShadow)
                {
                    
                }
                 SetBackgroundDrawable(gradientDrawable);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyFrameRenderer.StaticColorProperty.PropertyName))
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Background;
                gradientDrawable.SetColor(myFrameRenderer.StaticColor.ToAndroid());
            }
        }
    }
}
