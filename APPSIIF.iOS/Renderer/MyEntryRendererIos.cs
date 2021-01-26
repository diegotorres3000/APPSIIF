using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using UIKit;
using Foundation;
using CoreAnimation;
using APPSIIF.Enums;
using System.ComponentModel;
using System.Net;
using System.IO;
using System;
using System.Text.RegularExpressions;

[assembly: ExportRenderer(typeof(MyEntryRenderer), typeof(MyEntryRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyEntryRendererIos : EntryRenderer
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

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;

                TypeBorder = myEntryRenderer.TypeBorder;
                setLeftImage(myEntryRenderer);
                if (myEntryRenderer.MyIsPassword)
                {
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                    myEntryRenderer.SourceImageRight = "icon_eye.png";
                    myEntryRenderer.IsPassword = true;
                }
                else if (myEntryRenderer.IsHelp)
                {
                    myEntryRenderer.SourceImageRight = "help2.png";
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 20, 20);
                }
                else if (myEntryRenderer.IsEraser)
                {
                    myEntryRenderer.SourceImageRight = "x";
                    myEntryRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                }
                setRightImage(myEntryRenderer);
                setPosition(myEntryRenderer);
                setBorder();
                //Control.EditingChanged += OnEditingChanged;
            }
        }

        
        void OnEditingChanged(object sender, EventArgs eventArgs)
        {
            Control.EditingChanged -= OnEditingChanged;

            if (!string.IsNullOrEmpty(Control.Text))
            {
                Control.Text = new Regex(@"^[a-zA-Z]+$")
                .Replace(Control.Text, string.Empty);
            }

            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
            var b = myEntryRenderer.Bounds;
            var a = Control.Bounds;
            Control.EditingChanged += OnEditingChanged;

            var sampleView = new UIView();
            sampleView.Frame = new CoreGraphics.CGRect(100f, 100f, 200f, 300f);
            sampleView.BackgroundColor = UIColor.Blue;

            this.AddSubview(sampleView);

            
        }


        public override void Draw(CGRect rect)
        {
            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
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

        private void setBorder()
        {
            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
            Control.TextColor = myEntryRenderer.ImageLeftColor.ToUIColor();
        }

        private void setPosition(MyEntryRenderer myEntryRenderer)
        {
            switch (myEntryRenderer.Position)
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

        private void setLeftImage(MyEntryRenderer myEntryRenderer)
        {
            if (myEntryRenderer.SourceImageLeft != "")
            {
                CGRect cGRect = new CGRect(myEntryRenderer.BoundsImageLeft.X, myEntryRenderer.BoundsImageLeft.Y,
                myEntryRenderer.BoundsImageLeft.Width + 20, myEntryRenderer.BoundsImageLeft.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = UIImage.FromFile(myEntryRenderer.SourceImageLeft);

                if (image == null)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    String fileName = Path.Combine(path, "images", myEntryRenderer.SourceImageLeft);

                    image = UIImage.FromFile(@fileName);
                }

                if (image != null)
                {
                    if (myEntryRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myEntryRenderer.ImageLeftColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myEntryRenderer.BoundsImageLeft.X + 10, myEntryRenderer.BoundsImageLeft.Y,
                        myEntryRenderer.BoundsImageLeft.Width, myEntryRenderer.BoundsImageLeft.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.LeftView = view;
                    Control.LeftViewMode = UITextFieldViewMode.Always;
                }
                else
                {
                    if (UIImageFromUrl(myEntryRenderer.BaseSource + myEntryRenderer.SourceImageLeft + ".png", myEntryRenderer.SourceImageLeft))
                    {
                        setLeftImage(myEntryRenderer);
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

        private void setRightImage(MyEntryRenderer myEntryRenderer)
        {
            if (myEntryRenderer.SourceImageRight != "")
            {
                CGRect cGRect = new CGRect(myEntryRenderer.BoundsImageRight.X, myEntryRenderer.BoundsImageRight.Y,
                myEntryRenderer.BoundsImageRight.Width + 20, myEntryRenderer.BoundsImageRight.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = UIImage.FromFile(myEntryRenderer.SourceImageRight);

                if (image == null)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    String fileName = Path.Combine(path, "images", myEntryRenderer.SourceImageRight);

                    image = UIImage.FromFile(@fileName);
                }

                if (image != null)
                {
                    if (myEntryRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myEntryRenderer.ImageRightColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myEntryRenderer.BoundsImageRight.X + 10, myEntryRenderer.BoundsImageRight.Y,
                        myEntryRenderer.BoundsImageRight.Width, myEntryRenderer.BoundsImageRight.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.RightView = view;
                    Control.RightViewMode = UITextFieldViewMode.Always;

                    if (myEntryRenderer.MyIsPassword)
                    {
                        UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(StatusBarClicked);
                        Control.RightView.AddGestureRecognizer(tapGesture);
                    }if (myEntryRenderer.IsHelp)
                    {
                        UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(HelpClicked);
                        Control.RightView.AddGestureRecognizer(tapGesture);
                    }if(myEntryRenderer.IsEraser)
                    {
                        UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(XClicked);
                        Control.RightView.AddGestureRecognizer(tapGesture);
                    }
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

        [Action("StatusBarClicked:")]
        public void StatusBarClicked(NSObject sender)
        {
            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
            myEntryRenderer.IsPassword = !myEntryRenderer.IsPassword;
            myEntryRenderer.SourceImageRight = (myEntryRenderer.IsPassword) ? "icon_eye.png" : "icon_eyebloq.png";
            //setRightImage(myEntryRenderer);
            UIImage image = UIImage.FromFile(myEntryRenderer.SourceImageRight);
            ((UIImageView)Control.RightView.Subviews[0]).Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
            ((UIImageView)Control.RightView.Subviews[0]).TintColor = (myEntryRenderer.ImageRightColor.ToUIColor());

            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(StatusBarClicked);
            Control.RightView.AddGestureRecognizer(tapGesture);
        }

        [Action("HelpClicked:")]
        public void HelpClicked(NSObject sender)
        {
            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
            myEntryRenderer.DisplayAlertEntry();
        }

        [Action("XClicked:")]
        public void XClicked(NSObject sender)
        {
            MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
            myEntryRenderer.Text = "";
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyEntryRenderer.StaticColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                Control.BackgroundColor = myEntryRenderer.StaticColor.ToUIColor();
            } else if (e.PropertyName.Equals(MyEntryRenderer.ImageLeftColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                try
                {
                    UIImageView uIImageView = (UIImageView)Control.LeftView.Subviews[0];
                    uIImageView.TintColor = (myEntryRenderer.ImageLeftColor.ToUIColor());
                }
                catch { }
                Control.TextColor = myEntryRenderer.ImageLeftColor.ToUIColor();
            } else if (e.PropertyName.Equals(MyEntryRenderer.ImageRightColorProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                try
                {
                    UIImageView uIImageView = (UIImageView)Control.RightView.Subviews[0];
                    uIImageView.TintColor = (myEntryRenderer.ImageRightColor.ToUIColor());
                }
                catch { }
            } else if (e.PropertyName.Equals(MyEntryRenderer.SourceImageLeftProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                setLeftImage(myEntryRenderer);
            } else if (e.PropertyName.Equals(MyEntryRenderer.SourceImageRightProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                if (myEntryRenderer.SourceImageRight == "")
                {
                    Control.RightView = null;
                }else
                    setRightImage(myEntryRenderer);
            } else if (e.PropertyName.Equals(MyEntryRenderer.IsEraserProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                setRightImage(myEntryRenderer);
            }
            else if (e.PropertyName.Equals(MyEntryRenderer.IsEnabledProperty.PropertyName))
            {
                MyEntryRenderer myEntryRenderer = (MyEntryRenderer)Element;
                if (myEntryRenderer.IsEnabled)
                {
                    Control.TextColor = myEntryRenderer.ImageLeftColor.ToUIColor();
                }
            }
        }
    }
}
