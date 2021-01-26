using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using APPSIIF.iOS.Renderer;
using UIKit;
using CoreAnimation;
using System.ComponentModel;
using System.Net;
using System;
using System.IO;

[assembly: ExportRenderer(typeof(MyPickerRenderer), typeof(MyPickerRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyPickerRendererIos : PickerRenderer
    {
        private TypeBorder TypeBorder;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CAShapeLayer cAShapeLayer = null;
            switch (TypeBorder)
            {
                case TypeBorder.All:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft | UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(20, 20)).CGPath
                    };
                    break;
                case TypeBorder.Right:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(20, 20)).CGPath
                    };
                    break;
                case TypeBorder.Up:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.TopLeft | UIRectCorner.TopRight,
                        new CGSize(20, 20)).CGPath
                    };
                    break;
                case TypeBorder.Left:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft,
                        new CGSize(20, 20)).CGPath
                    };
                    break;
                case TypeBorder.Down:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.BottomRight,
                        new CGSize(20, 20)).CGPath
                    };
                    break;
            }
            base.Layer.Mask = cAShapeLayer;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                TypeBorder = myPickerRenderer.TypeBorder;
                setBorder();
                setPosition(myPickerRenderer);
                setLeftImage(myPickerRenderer);
                setRightImage(myPickerRenderer);
            }
        }

        public override void Draw(CGRect rect)
        {
            MyPickerRenderer myEntryRenderer = (MyPickerRenderer)Element;
            if (myEntryRenderer.IsGradient)
            {
                Control.BackgroundColor = UIColor.Clear;
                var gradientLayer = new CAGradientLayer
                {
                    Frame = rect,
                    Colors = new CGColor[] { myEntryRenderer.StartColor.ToCGColor(), myEntryRenderer.EndColor.ToCGColor() }
                };
                gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
                gradientLayer.StartPoint = new CGPoint(0, 0.5);
                Control.Layer.AddSublayer(gradientLayer);
            }
            else
                Control.BackgroundColor = myEntryRenderer.StaticColor.ToUIColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyPickerRenderer.SourceImageLeftProperty.PropertyName))
            {
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                if (myPickerRenderer.SourceImageLeft != "")
                {
                    setLeftImage(myPickerRenderer);
                }
            }
            if (e.PropertyName.Equals(MyPickerRenderer.StaticColorProperty.PropertyName))
            {
                MyPickerRenderer myEntryRenderer = (MyPickerRenderer)Element;
                Control.BackgroundColor = myEntryRenderer.StaticColor.ToUIColor();
            }
            if (e.PropertyName.Equals(MyPickerRenderer.ImageLeftColorProperty.PropertyName))
            {
                MyPickerRenderer myEntryRenderer = (MyPickerRenderer)Element;
                if (!(myEntryRenderer.SourceImageLeft == ""))
                {
                    UIImageView uIImageView = (UIImageView)Control.LeftView.Subviews[0];
                    if (uIImageView != null)
                    {
                        uIImageView.TintColor = (myEntryRenderer.ImageLeftColor.ToUIColor());
                    }
                }
            }
            if (e.PropertyName.Equals(MyPickerRenderer.ImageRightColorProperty.PropertyName))
            {
                
                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                try
                {
                    UIImageView uIImageView = (UIImageView)Control.RightView.Subviews[0];
                    uIImageView.TintColor = (myPickerRenderer.ImageRightColor.ToUIColor());
                }
                catch { }
            }
            if (e.PropertyName.Equals(MyPickerRenderer.IsEnabledProperty.PropertyName))
            {

                MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
                if (!myPickerRenderer.IsEnabled)
                {
                    Control.TextColor = myPickerRenderer.TextColor.ToUIColor();
                }
            }
        }

        private void setBorder()
        {
            MyPickerRenderer myPickerRenderer = (MyPickerRenderer)Element;
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
            Control.BackgroundColor = myPickerRenderer.StaticColor.ToUIColor();
            Control.TextColor = myPickerRenderer.TextColor.ToUIColor();
        }

        private void setPosition(MyPickerRenderer myPickerRenderer)
        {
            switch (myPickerRenderer.Position)
            {
                case Position.Center:
                    Control.TextAlignment = UIKit.UITextAlignment.Center;
                    break;
                case Position.Right:
                    Control.TextAlignment = UIKit.UITextAlignment.Right;
                    break;
                case Position.Left:
                    Control.TextAlignment = UIKit.UITextAlignment.Left;
                    break;
            }
        }
        /*
        private void setLeftImage(MyPickerRenderer myPickerRenderer)
        {
            if (myPickerRenderer.SourceImageLeft != "")
            {
                CGRect cGRect = new CGRect(myPickerRenderer.BoundsImageLeft.X, myPickerRenderer.BoundsImageLeft.Y,
                myPickerRenderer.BoundsImageLeft.Width + 20, myPickerRenderer.BoundsImageLeft.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = null;
                try
                {
                    image = new UIImage(myPickerRenderer.SourceImageLeft);
                }
                catch
                {
                    //image = UIImageFromUrl("https://imgappgyg.s3-sa-east-1.amazonaws.com/" + myPickerRenderer.SourceImageLeft);
                    if (UIImageFromUrl("https://imgappgyg.s3-sa-east-1.amazonaws.com/" + myPickerRenderer.SourceImageLeft + ".png", myPickerRenderer.SourceImageLeft))
                    {
                        setLeftImage(myPickerRenderer);
                    }
                }
                if (image != null)
                {
                    if (myPickerRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myPickerRenderer.ImageLeftColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myPickerRenderer.BoundsImageLeft.X + 10, myPickerRenderer.BoundsImageLeft.Y,
                        myPickerRenderer.BoundsImageLeft.Width, myPickerRenderer.BoundsImageLeft.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.LeftView = view;
                    Control.LeftViewMode = UITextFieldViewMode.Always;
                }
                
            }
        }
        */

        private void setLeftImage(MyPickerRenderer myPickerRenderer)
        {
            if (myPickerRenderer.SourceImageLeft != "")
            {
                CGRect cGRect = new CGRect(myPickerRenderer.BoundsImageLeft.X, myPickerRenderer.BoundsImageLeft.Y,
                myPickerRenderer.BoundsImageLeft.Width + 20, myPickerRenderer.BoundsImageLeft.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = UIImage.FromFile(myPickerRenderer.SourceImageLeft);

                if (image == null)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    String fileName = Path.Combine(path, "images", myPickerRenderer.SourceImageLeft);

                    image = UIImage.FromFile(@fileName);
                }

                if (image != null)
                {
                    if (myPickerRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myPickerRenderer.ImageLeftColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myPickerRenderer.BoundsImageLeft.X + 10, myPickerRenderer.BoundsImageLeft.Y,
                        myPickerRenderer.BoundsImageLeft.Width, myPickerRenderer.BoundsImageLeft.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.LeftView = view;
                    Control.LeftViewMode = UITextFieldViewMode.Always;
                }
                else
                {
                    if (UIImageFromUrl("https://imgappgyg.s3-sa-east-1.amazonaws.com/" + myPickerRenderer.SourceImageLeft + ".png", myPickerRenderer.SourceImageLeft))
                    {
                        setLeftImage(myPickerRenderer);
                    }
                    else
                    {
                        Control.LeftView = new UIView(new CGRect(0, 0, 20, 0));
                        Control.LeftViewMode = UITextFieldViewMode.Always;
                    }
                }
            }
            else
            {
                Control.LeftView = new UIView(new CGRect(0, 0, 20, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
            }

        }

        private void setRightImage(MyPickerRenderer myPickerRenderer)
        {
            if (myPickerRenderer.SourceImageRight != "")
            {
                CGRect cGRect = new CGRect(myPickerRenderer.BoundsImageRight.X, myPickerRenderer.BoundsImageRight.Y,
                myPickerRenderer.BoundsImageRight.Width + 20, myPickerRenderer.BoundsImageRight.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = null;
                try
                {
                    image = new UIImage(myPickerRenderer.SourceImageRight);
                }
                catch
                {
                    //image = UIImageFromUrl("https://imgappgyg.s3-sa-east-1.amazonaws.com/" + myPickerRenderer.SourceImageRight);
                    if (UIImageFromUrl("https://imgappgyg.s3-sa-east-1.amazonaws.com/" + myPickerRenderer.SourceImageLeft + ".png", myPickerRenderer.SourceImageLeft))
                    {
                        setRightImage(myPickerRenderer);
                    }
                }
                if (image != null)
                {
                    if (myPickerRenderer.ImageRightColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myPickerRenderer.ImageRightColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myPickerRenderer.BoundsImageRight.X + 10, myPickerRenderer.BoundsImageRight.Y,
                        myPickerRenderer.BoundsImageRight.Width, myPickerRenderer.BoundsImageRight.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.RightView = view;
                    Control.RightViewMode = UITextFieldViewMode.Always;
                }
            }

        }

        public static bool UIImageFromUrl(string uri, string name)
        {
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
                }
            }
            return false;
        }

    }
}
