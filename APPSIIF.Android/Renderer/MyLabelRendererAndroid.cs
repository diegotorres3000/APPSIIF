using System;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Droid.Renderer;
using APPSIIF.Renderer;
using APPSIIF.Converters;
using APPSIIF.Enums;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyLabelRenderer), typeof(MyLabelRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyLabelRendererAndroid : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.OldElement == null))
            {
                MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
                SetDrawable(myLabelRenderer);
            }
        }

        void SetDrawable(MyLabelRenderer myLabelRenderer)
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            if (myLabelRenderer.IsGradient)
            {
                Color color = ColorInterpolator.InterpolateBetween(myLabelRenderer.StartColor,
                    myLabelRenderer.EndColor,
                    myLabelRenderer.NumToGradient);
                gradientDrawable = new GradientDrawable(
                    GradientDrawable.Orientation.LeftRight,
                    new int[] { myLabelRenderer.StartColor.ToAndroid(), color.ToAndroid() }
                );
            }
            else
            {
                gradientDrawable.SetColor(myLabelRenderer.StaticColor.ToAndroid()); 
            }
            switch (myLabelRenderer.TypeBorder)
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
            Control.SetBackground(gradientDrawable);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyLabelRenderer.StaticColorProperty.PropertyName))
            {
                MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
                SetDrawable(myLabelRenderer);
            }
        }
    }
}
