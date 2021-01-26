using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using APPSIIF.Droid.Renderer;
using APPSIIF.Renderer;
using Android.Content;
using Android.Graphics;
using APPSIIF.Enums;
using Color = Xamarin.Forms.Color;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyPickerDateRenderer), typeof(MyPickerDateRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [System.Obsolete]
    public class MyPickerDateRendererAndroid : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.OldElement == null))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                SetDrawable(myPickerDateRenderer);

                Drawable imageLeft = SetLeftImage(myPickerDateRenderer);
                Drawable imageRight = SetRightImage(myPickerDateRenderer);
                Control.SetCompoundDrawables(imageLeft, null, imageRight, null);

                //Control.Gravity = GravityFlags.Center;
                Control.CompoundDrawablePadding = 20;
            }
        }

        void SetDrawable(MyPickerDateRenderer myPickerDateRenderer)
        {
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor(myPickerDateRenderer.StaticColor.ToAndroid());

            switch (myPickerDateRenderer.TypeBorder)
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

        Drawable SetLeftImage(MyPickerDateRenderer myPickerDateRenderer)
        {
            if (myPickerDateRenderer.SourceImageLeft != "")
            {
                Drawable image = Context.GetDrawable(myPickerDateRenderer.SourceImageLeft);
                if (image != null)
                {
                    if (myPickerDateRenderer.ImageLeftColor != Color.Transparent)
                    {
                        image.SetColorFilter(myPickerDateRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                    image.SetBounds((int)myPickerDateRenderer.BoundsImageLeft.X + 5,
                        (int)myPickerDateRenderer.BoundsImageLeft.Y,
                        (int)myPickerDateRenderer.BoundsImageLeft.Width * 2,
                        (int)myPickerDateRenderer.BoundsImageLeft.Height * 2);
                }
                return image;
            }
            return null;
        }

        Drawable SetRightImage(MyPickerDateRenderer myPickerDateRenderer)
        {
            if (myPickerDateRenderer.SourceImageRight != "")
            {
                Drawable image = Context.GetDrawable(myPickerDateRenderer.SourceImageRight);
                if (image != null)
                {
                    if (myPickerDateRenderer.ImageRightColor != Color.Transparent)
                    {
                        image.SetColorFilter(myPickerDateRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                    image.SetBounds((int)myPickerDateRenderer.BoundsImageRight.X + 5,
                        (int)myPickerDateRenderer.BoundsImageRight.Y,
                        (int)myPickerDateRenderer.BoundsImageRight.Width * 2,
                        (int)myPickerDateRenderer.BoundsImageRight.Height * 2);
                }
                return image;
            }
            return null;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyPickerDateRenderer.StaticColorProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Control.Background;
                gradientDrawable.SetColor(myPickerDateRenderer.StaticColor.ToAndroid());

            }
        }
    }
}
