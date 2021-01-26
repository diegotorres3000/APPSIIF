using System;
using System.ComponentModel;
using APPSIIF.Renderer;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.iOS.Renderer;
using CoreGraphics;
using System.IO;
using System.Net;
using System.Drawing;

[assembly: ExportRendererAttribute(typeof(MyImageRenderer), typeof(MyImageRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyImageRendererIos : ViewRenderer<MyImageRenderer, UIImageView>
    {
        private bool _isDisposed;
        private string ImagePrevius;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing && base.Control != null)
            {
                UIImage image = base.Control.Image;
                UIImage uIImage = image;
                if (image != null)
                {
                    uIImage.Dispose();
                }
            }

            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyImageRenderer> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                UIImageView uIImageView = new UIImageView(CGRect.Empty)
                {
                    ContentMode = UIViewContentMode.ScaleAspectFit,
                    ClipsToBounds = true
                };
                SetNativeControl(uIImageView);
            }
            if (e.NewElement != null) 
            {
                SetImage(e.NewElement);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == MyImageRenderer.SourceProperty.PropertyName)
            {
                SetImage(null);
            }
            else if (e.PropertyName == MyImageRenderer.ForegroundProperty.PropertyName)
            {
                ImagePrevius = "";
                SetImage(null);
            }
        }

        private void SetImage(MyImageRenderer previous = null)
        {
            if (!string.IsNullOrWhiteSpace(Element.Source))  //&& ImagePrevius != Element.Source)
            {
                ImagePrevius = Element.Source;

                UIImage uiImage = null;
                uiImage = UIImage.FromFile(Element.Source);

                if (uiImage == null)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    String fileName = Path.Combine(path, "images", Element.Source);

                    uiImage = UIImage.FromFile(@fileName);
                }
                if (uiImage != null)
                {
                    if (Element.Foreground.Equals(Xamarin.Forms.Color.Transparent))
                    {
                        uiImage = uiImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    else
                    {
                        uiImage = uiImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        Control.TintColor = Element.Foreground.ToUIColor();
                    }

                    if (Element.IsShadow)
                    {
                        Control.Layer.ShadowColor = Element.ShadowColor.ToCGColor();
                        Control.Layer.ShadowOffset = new CoreGraphics.CGSize(0f, 0f);
                        Control.Layer.ShadowRadius = 5;
                        Control.Layer.ShadowOpacity = 1;
                    }
                    Control.Image = uiImage;
                    if (!_isDisposed)
                    {
                        ((IVisualElementController)Element).NativeSizeChanged();
                    }
                }
                else
                {
                    if (UIImageFromUrl(Element.BaseSource + Element.Source + ".png", Element.Source))
                    {
                        SetImage();
                    }
                }
            }
        }

        public static bool UIImageFromUrl(string uri, string name)
        {
            Bitmap imageBitmap = null;

            /*
            WebClient webClient = new WebClient();
            string pathToNewFile = Path.Combine("./", Path.GetFileName("water-element.png"));
            webClient.DownloadFileAsync(new Uri(uri), pathToNewFile);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                if (data != null)
                {
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine(elapsedMs);
                    UIImage uIImage = UIImage.LoadFromData(data);
                    FileStream fs = new FileStream("image", FileMode.OpenOrCreate);
                    data.Save("image",true);
                    return UIImage.LoadFromData(data);
                }
                else
                {
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    Console.WriteLine(elapsedMs);
                    return null;
                }
                */
            using (var webClient = new WebClient())
            {
                byte[] imageBytes = null;
                try
                {
                    imageBytes = webClient.DownloadData(uri);
                }
                catch
                { }
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    String fileName = Path.Combine(path, "images", name);

                    String dirName = Path.GetDirectoryName(fileName);

                    if (!Directory.Exists(dirName))
                        Directory.CreateDirectory(dirName);

                    File.WriteAllBytes(fileName, imageBytes);
                    return true;
                    //imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return false;
        }

    }
}
