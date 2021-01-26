using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SIIFMOVIL.iOS.Renderer;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using CoreGraphics;
using CoreAnimation;
using System.ComponentModel;
using Foundation;

[assembly: ExportRenderer(typeof(MyPickerDateRenderer), typeof(MyPickerDateRendererIos))]
namespace SIIFMOVIL.iOS.Renderer
{
    public class MyPickerDateRendererIos : DatePickerRenderer
    {
        TypeBorder TypeBorder;

        public override void LayoutSubviews()
        {
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
            if (cAShapeLayer != null)
            {
                base.Layer.Mask = cAShapeLayer;
            }
            base.LayoutSubviews();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);


            if (e.OldElement == null)
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                TypeBorder = myPickerDateRenderer.TypeBorder;

                Control.BackgroundColor = myPickerDateRenderer.StaticColor.ToUIColor();
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;

                Control.Layer.MasksToBounds = true;

                if (myPickerDateRenderer.SourceImageLeft != "")
                {
                    setLeftImage(myPickerDateRenderer);
                }
                if (myPickerDateRenderer.IsHelp)
                {
                    myPickerDateRenderer.SourceImageRight = "help2.png";
                    myPickerDateRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                    setRightImage(myPickerDateRenderer);
                }
                if (myPickerDateRenderer.IsEraser)
                {
                    myPickerDateRenderer.SourceImageRight = "x";
                    myPickerDateRenderer.BoundsImageRight = new Rectangle(0, 0, 25, 25);
                    setRightImage(myPickerDateRenderer);
                }
                if (!string.IsNullOrWhiteSpace(myPickerDateRenderer.Placeholder))
                {
                    Control.Text = myPickerDateRenderer.Placeholder;
                }
            }
        }

        private void setLeftImage(MyPickerDateRenderer myPickerDateRenderer)
        {
            if (myPickerDateRenderer.SourceImageLeft != "")
            {
                CGRect cGRect = new CGRect(myPickerDateRenderer.BoundsImageLeft.X, myPickerDateRenderer.BoundsImageLeft.Y,
                myPickerDateRenderer.BoundsImageLeft.Width + 20, myPickerDateRenderer.BoundsImageLeft.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = UIImage.FromFile(myPickerDateRenderer.SourceImageLeft);
                if (image != null)
                {
                    if (myPickerDateRenderer.ImageLeftColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myPickerDateRenderer.ImageLeftColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myPickerDateRenderer.BoundsImageLeft.X + 10, myPickerDateRenderer.BoundsImageLeft.Y,
                        myPickerDateRenderer.BoundsImageLeft.Width, myPickerDateRenderer.BoundsImageLeft.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.LeftView = view;
                    Control.LeftViewMode = UITextFieldViewMode.Always;
                }

            }
        }

        private void setRightImage(MyPickerDateRenderer myPickerDateRenderer)
        {
            if (myPickerDateRenderer.SourceImageRight != "")
            {
                CGRect cGRect = new CGRect(myPickerDateRenderer.BoundsImageRight.X, myPickerDateRenderer.BoundsImageRight.Y,
                myPickerDateRenderer.BoundsImageRight.Width + 20, myPickerDateRenderer.BoundsImageRight.Height);
                var view = new UIView(cGRect);
                var imageView = new UIImageView();
                UIImage image = UIImage.FromFile(myPickerDateRenderer.SourceImageRight);
                if (image != null)
                {
                    if (myPickerDateRenderer.ImageRightColor != Color.Transparent)
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                        imageView.TintColor = (myPickerDateRenderer.ImageRightColor.ToUIColor());
                    }
                    else
                    {
                        imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                    CGRect cGRectImage = new CGRect(myPickerDateRenderer.BoundsImageRight.X + 10, myPickerDateRenderer.BoundsImageRight.Y,
                        myPickerDateRenderer.BoundsImageRight.Width, myPickerDateRenderer.BoundsImageRight.Height);
                    imageView.Frame = cGRectImage;
                    view.AddSubview(imageView);
                    Control.RightView = view;
                    Control.RightViewMode = UITextFieldViewMode.Always;

                    if (myPickerDateRenderer.IsHelp)
                    {
                        UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(HelpClicked);
                        Control.RightView.AddGestureRecognizer(tapGesture);
                    }
                    if (myPickerDateRenderer.IsEraser)
                    {
                        UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(XClicked);
                        Control.RightView.AddGestureRecognizer(tapGesture);
                    }
                }

            }
        }

        [Action("HelpClicked:")]
        public void HelpClicked(NSObject sender)
        {
            MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
            myPickerDateRenderer.DisplayAlertEntry();
        }

        [Action("XClicked:")]
        public void XClicked(NSObject sender)
        {
            MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
            Control.Text = "borrado";
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyPickerDateRenderer.StaticColorProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                Control.BackgroundColor = myPickerDateRenderer.StaticColor.ToUIColor();
            } else if (e.PropertyName.Equals(MyPickerRenderer.ImageLeftColorProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                try
                {
                    UIImageView uIImageView = (UIImageView)Control.LeftView.Subviews[0];
                    uIImageView.TintColor = (myPickerDateRenderer.ImageLeftColor.ToUIColor());
                }
                catch { }
            }else if (e.PropertyName.Equals(MyPickerRenderer.ImageRightColorProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                try
                {
                    UIImageView uIImageView = (UIImageView)Control.RightView.Subviews[0];
                    uIImageView.TintColor = (myPickerDateRenderer.ImageRightColor.ToUIColor());
                }
                catch { }
            }
            else if (e.PropertyName.Equals(MyPickerDateRenderer.SourceImageRightProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                setRightImage(myPickerDateRenderer);
            }
            else if (e.PropertyName.Equals(MyPickerDateRenderer.IsEraserProperty.PropertyName))
            {
                MyPickerDateRenderer myPickerDateRenderer = (MyPickerDateRenderer)Element;
                setRightImage(myPickerDateRenderer);
            }
        }
    }
}
