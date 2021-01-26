using System;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using System.ComponentModel;
using APPSIIF.Renderer;
using Xamarin.Forms;
using APPSIIF.Droid.Renderer;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Net;
using Color = Xamarin.Forms.Color;
using System.IO;

[assembly: ExportRendererAttribute(typeof(MyImageRenderer), typeof(MyImageRendererAndroid))]

namespace APPSIIF.Droid.Renderer
{
    public class MyImageRendererAndroid : ViewRenderer<MyImageRenderer, ImageView>
    {
        private bool _isDisposed;
        private string ImagePrevius;

        [Obsolete]
        public MyImageRendererAndroid()
        {
            base.AutoPackage = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyImageRenderer> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(new ImageView(Context));
            }
            UpdateBitmap(e.OldElement);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == MyImageRenderer.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
            else if (e.PropertyName == MyImageRenderer.ForegroundProperty.PropertyName)
            {
                ImagePrevius = "";
                UpdateBitmap(null);
            }
        }

        private void UpdateBitmap(MyImageRenderer previous = null)
        {
            if (!_isDisposed && !string.IsNullOrWhiteSpace(Element.Source) && ImagePrevius != Element.Source)
            {
                Drawable d = null;
                try
                {
                    d = Resources.GetDrawable(Element.Source).Mutate();
                }
                catch
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/" + Element.Source);
                        ImageView ima2 = new ImageView(Context);
                        Bitmap bitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        var imageBitmap2 = bitmap;
                        ima2.SetImageBitmap(imageBitmap2);
                        d = ima2.Drawable;
                    }
                    catch
                    {
                        ImageView ima = new ImageView(Context);
                        var imageBitmap = GetImageBitmapFromUrl(Element.BaseSource + Element.Source);
                        ima.SetImageBitmap(imageBitmap);
                        ima.Elevation = 10;
                        d = ima.Drawable;
                    }
                }
                if (!Element.Foreground.Equals(Color.Transparent) && d != null)
                {
                    d.SetColorFilter(new LightingColorFilter(Element.Foreground.ToAndroid(), Element.Foreground.ToAndroid()));
                    d.Alpha = Element.Foreground.ToAndroid().A;
                }

                //Paint mShadow = new Paint();
                // radius=10, y-offset=2, color=black 
                //mShadow.SetShadowLayer(10.0f, 0.0f, 2.0f, 0xFF000000);
                // in onDraw(Canvas) 
                

                //Control.SetBackground();

                //Control.Elevation = 5;


                Control.SetImageDrawable(d);
                ((IVisualElementController)Element).NativeSizeChanged();
            }
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                byte[] imageBytes = null;
                try
                {
                    imageBytes = webClient.DownloadData(url + ".png");
                } catch
                { }
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)+"/"+ Element.Source, imageBytes);
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}

