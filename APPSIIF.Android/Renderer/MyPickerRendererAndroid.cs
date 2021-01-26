using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using APPSIIF.Droid.Renderer;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Graphics;
using Color = Xamarin.Forms.Color;
using System.ComponentModel;
using System.Net;

[assembly: ExportRenderer(typeof(MyPickerRenderer), typeof(MyPickerRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [System.Obsolete]
    public class MyPickerRendererAndroid : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if((Control != null) && (e.OldElement == null))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                SetPosition(myPickerRenderer);
                SetDrawable(myPickerRenderer);
                Drawable imageLeft = SetLeftImage(myPickerRenderer);
                Drawable imageRight = SetRightImage(myPickerRenderer);
                Control.SetCompoundDrawables(imageLeft, null, imageRight, null);
                Control.SetPadding(Control.PaddingLeft + 20, Control.PaddingTop, Control.PaddingRight + 20,
                    Control.PaddingBottom);
                Control.CompoundDrawablePadding = 20;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyPickerRenderer.SourceImageLeftProperty.PropertyName))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                Drawable imageLeft = null;
                if (myPickerRenderer.SourceImageLeft != "")
                {
                    ImageView ima = new ImageView(Context);
                    var imageBitmap = GetImageBitmapFromUrl(myPickerRenderer.SourceImageLeft);
                    ima.SetImageBitmap(imageBitmap);
                    imageLeft = ima.Drawable;
                    if (myPickerRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageLeft.SetColorFilter(myPickerRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                    imageLeft.SetBounds((int)myPickerRenderer.BoundsImageLeft.X + 5,
                        (int)myPickerRenderer.BoundsImageLeft.Y,
                        (int)myPickerRenderer.BoundsImageLeft.Width * 2,
                        (int)myPickerRenderer.BoundsImageLeft.Height * 2);
                }
                Control.SetCompoundDrawables(imageLeft, Control.GetCompoundDrawables()[1], Control.GetCompoundDrawables()[2], Control.GetCompoundDrawables()[3]);
            } else
            if (e.PropertyName.Equals(MyPickerRenderer.StaticColorProperty.PropertyName))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Control.Background;
                if(gradientDrawable != null)
                    gradientDrawable.SetColor(myPickerRenderer.StaticColor.ToAndroid());
            } else
            if (e.PropertyName.Equals(MyPickerRenderer.ImageLeftColorProperty.PropertyName))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                Drawable drawable = (Drawable)Control.GetCompoundDrawables()[0];
                if (drawable != null)
                    drawable.SetColorFilter(myPickerRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            }
            else
            if (e.PropertyName.Equals(MyPickerRenderer.ImageRightColorProperty.PropertyName))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                Drawable drawable = (Drawable)Control.GetCompoundDrawables()[2];
                if (drawable != null)
                    drawable.SetColorFilter(myPickerRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            }
        }

        void SetPosition(MyPickerRenderer myPickerRenderer)
        {
            switch (myPickerRenderer.Position)
            {
                case Position.Center:
                    Control.Gravity = GravityFlags.Center;
                    break;
                case Position.Left:
                    Control.Gravity = GravityFlags.Left;
                    break;
                case Position.Right:
                    Control.Gravity = GravityFlags.Right;
                    break;
            }
        }

        void SetDrawable(MyPickerRenderer myPickerRenderer)
        {
            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetColor(myPickerRenderer.StaticColor.ToAndroid());

            switch (myPickerRenderer.TypeBorder)
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

        Drawable SetLeftImage(MyPickerRenderer myPickerRenderer)
        {
            if (myPickerRenderer.SourceImageLeft != "")
            {

                Drawable image = null;
                try
                {
                    image = Resources.GetDrawable(myPickerRenderer.SourceImageLeft).Mutate();
                }
                catch
                {
                    ImageView ima = new ImageView(Context);
                    var imageBitmap = GetImageBitmapFromUrl(myPickerRenderer.SourceImageLeft);
                    ima.SetImageBitmap(imageBitmap);
                    image = ima.Drawable;
                }
                if (image != null)
                {
                    if (myPickerRenderer.ImageLeftColor != Color.Transparent)
                    {
                        image.SetColorFilter(myPickerRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                    image.SetBounds((int)myPickerRenderer.BoundsImageLeft.X + 5,
                        (int)myPickerRenderer.BoundsImageLeft.Y,
                        (int)myPickerRenderer.BoundsImageLeft.Width * 2,
                        (int)myPickerRenderer.BoundsImageLeft.Height * 2);
                }
                return image;
            }
            return null;
        }

        Drawable SetRightImage(MyPickerRenderer myPickerRenderer)
        {
            if (myPickerRenderer.SourceImageRight != "")
            {
                Drawable image = Context.GetDrawable(myPickerRenderer.SourceImageRight);
                if (image != null)
                {
                    if (myPickerRenderer.ImageRightColor != Color.Transparent)
                    {
                        image.SetColorFilter(myPickerRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    }
                    image.SetBounds((int)myPickerRenderer.BoundsImageRight.X + 5,
                        (int)myPickerRenderer.BoundsImageRight.Y,
                        (int)myPickerRenderer.BoundsImageRight.Width * 2,
                        (int)myPickerRenderer.BoundsImageRight.Height * 2);
                }
                return image;
            }
            return null;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = null;
                try
                {
                    imageBytes = webClient.DownloadData(url);

                }
                catch
                { }
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}
