using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using APPSIIF.Droid.Renderer;
using Android.Content;
using Android.Views;
using Android.Graphics;
using System.ComponentModel;
using System.Net;
using System.IO;
using Android.Widget;

[assembly: ExportRenderer(typeof(MyEntryRenderer), typeof(MyEntryRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [System.Obsolete]
    public class MyEntryRendererAndroid :  EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.OldElement == null))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                if (myEntryRenderer.MyIsPassword)
                {
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                    myEntryRenderer.SourceImageRight = "icon_eye.png";
                    myEntryRenderer.IsPassword = true;
                }
                else if (myEntryRenderer.IsHelp)
                {
                    myEntryRenderer.SourceImageRight = "help2.png";
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                }
                else if (myEntryRenderer.IsEraser)
                {
                    myEntryRenderer.SourceImageRight = "x";
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                }
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(myEntryRenderer.StaticColor.ToAndroid());

                if (myEntryRenderer.IsGradient)
                {
                    gradientDrawable = new GradientDrawable(
                    GradientDrawable.Orientation.LeftRight,
                    new int[] { myEntryRenderer.StartColor.ToAndroid(),
                        myEntryRenderer.EndColor.ToAndroid() }
                    );
                }
                switch (myEntryRenderer.TypeBorder)
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
                Control.SetTextColor(myEntryRenderer.ImageLeftColor.ToAndroid());
                SetPosition(myEntryRenderer);
                // imagen Left
                Drawable imageLeft = SetLeftImage(myEntryRenderer);
                // imagen Right
                Drawable imageRight = SetRightImage(myEntryRenderer);
                Control.SetCompoundDrawables(imageLeft, null, imageRight, null);
                Control.SetPadding(Control.PaddingLeft+20, Control.PaddingTop, Control.PaddingRight+20,
                    Control.PaddingBottom);
                Control.CompoundDrawablePadding = 20;

            }
        }

        void SetPosition(MyEntryRenderer myEntryRenderer)
        {
            switch (myEntryRenderer.Position)
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

        Drawable SetLeftImage(MyEntryRenderer myEntryRenderer)
        {
            if (myEntryRenderer.SourceImageLeft != "")
            {
                Drawable image = Context.GetDrawable(myEntryRenderer.SourceImageLeft);
                if (image != null)
                {
                    image.SetColorFilter(myEntryRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    image.SetBounds((int)myEntryRenderer.BoundsImageLeft.X,
                        (int)myEntryRenderer.BoundsImageLeft.Y,
                        (int)myEntryRenderer.BoundsImageLeft.Width * 2,
                        (int)myEntryRenderer.BoundsImageLeft.Height * 2);
                }
                else
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/" + myEntryRenderer.SourceImageLeft + ".png");
                        ImageView ima2 = new ImageView(Context);
                        Bitmap bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        var imageBitmap2 = bitmap;
                        ima2.SetImageBitmap(imageBitmap2);
                        image = ima2.Drawable;
                        image.SetColorFilter(myEntryRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                        image.SetBounds((int)myEntryRenderer.BoundsImageLeft.X,
                            (int)myEntryRenderer.BoundsImageLeft.Y,
                            (int)myEntryRenderer.BoundsImageLeft.Width * 2,
                            (int)myEntryRenderer.BoundsImageLeft.Height * 2);
                    }
                    catch
                    {
                        ImageView ima = new ImageView(Context);
                        var imageBitmap = GetImageBitmapFromUrl(myEntryRenderer.BaseSource + myEntryRenderer.SourceImageLeft + ".png", myEntryRenderer.SourceImageLeft);
                        ima.SetImageBitmap(imageBitmap);
                        image = ima.Drawable;
                        image.SetColorFilter(myEntryRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                        image.SetBounds((int)myEntryRenderer.BoundsImageLeft.X,
                            (int)myEntryRenderer.BoundsImageLeft.Y,
                            (int)myEntryRenderer.BoundsImageLeft.Width * 2,
                            (int)myEntryRenderer.BoundsImageLeft.Height * 2);
                    }
                }
                return image;
            }
            return null;
        }

        Drawable SetRightImage(MyEntryRenderer myEntryRenderer)
        {
            if (myEntryRenderer.SourceImageRight != "")
            {
                
                Drawable image = Context.GetDrawable(myEntryRenderer.SourceImageRight);
                if (image != null)
                {
                    image.SetColorFilter(myEntryRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                    image.SetBounds((int)myEntryRenderer.BoundsImageRight.X,
                        (int)myEntryRenderer.BoundsImageRight.Y,
                        (int)myEntryRenderer.BoundsImageRight.Width * 2,
                        (int)myEntryRenderer.BoundsImageRight.Height * 2);

                    if (myEntryRenderer.MyIsPassword)
                    {
                        MyOnTouchListener myOnTouchListener = new MyOnTouchListener();
                        myOnTouchListener.form = Control;
                        myOnTouchListener.myEntryRenderer = myEntryRenderer;
                        myOnTouchListener.context = Context;
                        Control.SetOnTouchListener(myOnTouchListener);
                    }else if (myEntryRenderer.IsHelp)
                    {
                        MyOnTouchListenerHelp myOnTouchListenerHelp = new MyOnTouchListenerHelp();
                        myOnTouchListenerHelp.form = Control;
                        myOnTouchListenerHelp.myEntryRenderer = myEntryRenderer;
                        Control.SetOnTouchListener(myOnTouchListenerHelp);
                    }
                    if (myEntryRenderer.IsEraser)
                    {
                        MyOnTouchListenerX myOnTouchListenerX = new MyOnTouchListenerX();
                        myOnTouchListenerX.form = Control;
                        myOnTouchListenerX.myEntryRenderer = myEntryRenderer;
                        Control.SetOnTouchListener(myOnTouchListenerX);
                    }
                }
                //Control.SetPadding(10, ((int)myEntryRenderer.BoundsImageRight.Height /2), ((int)myEntryRenderer.BoundsImageRight.Width * 2) + 5, ((int)myEntryRenderer.BoundsImageRight.Height / 2));
                return image;
            }
            return null;
        }

        private Bitmap GetImageBitmapFromUrl(string url, string name)
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
                    File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/" + name + ".png", imageBytes);
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyEntryRenderer.StaticColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                GradientDrawable gradientDrawable = (GradientDrawable)Control.Background;
                if (gradientDrawable != null)
                    gradientDrawable.SetColor(myEntryRenderer.StaticColor.ToAndroid());
            }else
            if (e.PropertyName.Equals(MyEntryRenderer.ImageLeftColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                Drawable drawable = (Drawable)Control.GetCompoundDrawables()[0];
                if (drawable != null)
                    drawable.SetColorFilter(myEntryRenderer.ImageLeftColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            }else
            if (e.PropertyName.Equals(MyEntryRenderer.ImageRightColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                Drawable drawable = (Drawable)Control.GetCompoundDrawables()[2];
                if (drawable != null)
                    drawable.SetColorFilter(myEntryRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            }else
            if (e.PropertyName.Equals(MyEntryRenderer.SourceImageLeftProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                Control.SetCompoundDrawables(SetLeftImage(myEntryRenderer), null, Control.GetCompoundDrawables()[2], null);
            }else
            if (e.PropertyName.Equals(MyEntryRenderer.SourceImageRightProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                if (myEntryRenderer.SourceImageRight == "")
                {
                    Control.SetCompoundDrawables(Control.GetCompoundDrawables()[0], null, null, null);
                }
                else
                    Control.SetCompoundDrawables(Control.GetCompoundDrawables()[0], null, SetRightImage(myEntryRenderer), null);
            }
        }
    }

    public class MyOnTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public FormsEditText form { get; set; }
        public MyEntryRenderer myEntryRenderer { get; set; }
        public Context context { get; set; }

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if (form != null) {
                    Drawable co = form.GetCompoundDrawables()[2];
                    if (e.GetX() < v.Right && e.GetX() > v.Right - co.Bounds.Width())
                    {
                        myEntryRenderer.IsPassword = !myEntryRenderer.IsPassword;
                        var img = (myEntryRenderer.IsPassword) ? "icon_eye.png" : "icon_eyebloq.png";
                        Drawable imageRight = null;
                        imageRight = context.GetDrawable(img);
                        imageRight.SetColorFilter(myEntryRenderer.ImageRightColor.ToAndroid(), PorterDuff.Mode.SrcIn);
                        imageRight.SetBounds((int)myEntryRenderer.BoundsImageRight.X,
                        (int)myEntryRenderer.BoundsImageRight.Y,
                        (int)myEntryRenderer.BoundsImageRight.Width * 2,
                        (int)myEntryRenderer.BoundsImageRight.Height * 2);
                        form.SetCompoundDrawables(form.GetCompoundDrawables()[0],
                            form.GetCompoundDrawables()[1],
                            imageRight,
                            form.GetCompoundDrawables()[3]);
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class MyOnTouchListenerHelp : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public FormsEditText form { get; set; }
        public MyEntryRenderer myEntryRenderer { get; set; }

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if (form != null)
                {
                    Drawable co = form.GetCompoundDrawables()[2];
                    if (e.GetX() < v.Right && e.GetX() > v.Right - co.Bounds.Width())
                    {
                        myEntryRenderer.DisplayAlertEntry();
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class MyOnTouchListenerX : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public FormsEditText form { get; set; }
        public MyEntryRenderer myEntryRenderer { get; set; }

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if (form != null)
                {
                    Drawable co = form.GetCompoundDrawables()[2];
                    if (co != null) {
                        if (e.GetX() < v.Right && e.GetX() > v.Right - co.Bounds.Width())
                        {
                            myEntryRenderer.Text = "";
                            return true;
                        }
                    }

                    
                }
            }
            return false;
        }
    }
}
