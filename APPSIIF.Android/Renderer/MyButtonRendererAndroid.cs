using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Renderer;
using APPSIIF.Droid.Renderer;
using APPSIIF.Enums;
using Android.Graphics.Drawables;
using Android.Animation;
using APPSIIF.Converters;
using Color = Xamarin.Forms.Color;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyButtonRenderer), typeof(MyButtonRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyButtonRendererAndroid : ButtonRenderer
    {
        private GradientDrawable _normal, _pressed;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.OldElement == null))
            {

                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                GradientDrawable gradientDrawable = new GradientDrawable();
                if (myButtonRenderer.IsGradient)
                {
                    Color StartColor = ColorInterpolator.InterpolateBetween(myButtonRenderer.EndColor,
                    myButtonRenderer.StartColor,
                    myButtonRenderer.NumOfGradientStart);
                    Color EndColor = ColorInterpolator.InterpolateBetween(myButtonRenderer.StartColor,
                        myButtonRenderer.EndColor,
                        myButtonRenderer.NumOfGradientEnd);
                    if (!myButtonRenderer.IsEnabled)
                    {
                        StartColor = System.Drawing.Color.FromArgb(70, StartColor);
                        EndColor = System.Drawing.Color.FromArgb(70, EndColor);
                    }
                    gradientDrawable = new GradientDrawable(
                    GradientDrawable.Orientation.LeftRight,
                    new int[] { StartColor.ToAndroid(),
                    EndColor.ToAndroid() }
                    );
                }
                else {
                    Color staticColor = myButtonRenderer.StaticColor;
                    if (!myButtonRenderer.IsEnabled) {
                        staticColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.StaticColor);
                    }
                    gradientDrawable.SetColor(staticColor.ToAndroid());
                }
                switch (myButtonRenderer.TypeBorder)
                {
                    case TypeBorder.All:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 80, 80,
                        80, 80, 80, 80});
                        break;
                    case TypeBorder.Left:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 0, 0,
                        0, 0, 80, 80});
                        break;
                    case TypeBorder.Right:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0, 80, 80,
                        80, 80, 0, 0});
                        break;
                    case TypeBorder.Down:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0, 0, 0,
                        80, 80, 80, 80});
                        break;
                    case TypeBorder.Up:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 80, 80,
                        0, 0, 0, 0});
                        break;
                }
                Control.StateListAnimator = new StateListAnimator();
                Control.SetBackground(gradientDrawable);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyButtonRenderer.StaticColorProperty.PropertyName))
            {
                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Control.Background;
                gradientDrawable.SetColor(myButtonRenderer.StaticColor.ToAndroid());
            }
            if (e.PropertyName.Equals(MyButtonRenderer.IsEnabledProperty.PropertyName))
            {
                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Control.Background;
                if (!myButtonRenderer.IsEnabled)
                {
                    if (myButtonRenderer.IsGradient)
                    {
                        Color StartColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.StartColor);
                        Color EndColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.EndColor);

                        gradientDrawable.SetColors(new int[]{
                        StartColor.ToAndroid(),
                        EndColor.ToAndroid()});
                    }
                    else
                    {
                        Color staticColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.StaticColor);
                        gradientDrawable.SetColor(staticColor.ToAndroid());
                    }
                    
                }
                else
                {
                    if (myButtonRenderer.IsGradient)
                    {
                        gradientDrawable.SetColors(new int[]{
                        myButtonRenderer.StartColor.ToAndroid(),
                        myButtonRenderer.EndColor.ToAndroid()});
                    }
                    else
                    {
                        gradientDrawable.SetColor(myButtonRenderer.StaticColor.ToAndroid());
                    }
                    
                }
            }
        }
    }
}
