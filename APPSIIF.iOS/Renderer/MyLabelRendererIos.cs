using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using APPSIIF.Enums;
using APPSIIF.Converters;

using CoreGraphics;
using UIKit;
using CoreAnimation;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyLabelRenderer), typeof(MyLabelRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyLabelRendererIos : LabelRenderer
    {
        TypeBorder TypeBorder;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CAShapeLayer cAShapeLayer = null;
            MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
            switch (TypeBorder)
            {
                case TypeBorder.All:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft | UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(myLabelRenderer.BorderRadius, myLabelRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Right:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(myLabelRenderer.BorderRadius, myLabelRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Up:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.TopLeft | UIRectCorner.TopRight,
                        new CGSize(myLabelRenderer.BorderRadius, myLabelRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Left:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft,
                        new CGSize(myLabelRenderer.BorderRadius, myLabelRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Down:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.BottomRight,
                        new CGSize(myLabelRenderer.BorderRadius, myLabelRenderer.BorderRadius)).CGPath
                    };
                    break;
            }
            base.Layer.Mask = cAShapeLayer;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
           

            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
                TypeBorder = myLabelRenderer.TypeBorder;
            }
        }


        public override void Draw(CGRect rect)
        {
            MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
            if (myLabelRenderer.IsGradient)
            {
                var gradientView = new UIView(Control.Frame);
                Control.BackgroundColor = UIColor.Clear;
                Color color = ColorInterpolator.InterpolateBetween(myLabelRenderer.StartColor,
                    myLabelRenderer.EndColor,
                    myLabelRenderer.NumToGradient);

                var gradientLayer = new CAGradientLayer
                {
                    Frame = gradientView.Layer.Bounds,
                    Colors = new CGColor[] { myLabelRenderer.StartColor.ToCGColor(), color.ToCGColor() }
                };

                gradientView.Layer.AddSublayer(gradientLayer);
                gradientView.AddSubview(Control);

                var gradientLabel = new UILabel(Control.Frame);
                gradientLabel.AddSubview(gradientView);
                SetNativeControl(gradientLabel);

                gradientLayer.StartPoint = new CGPoint(0, 0.5);
                gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
            }
            else
            {
                Control.BackgroundColor = myLabelRenderer.StaticColor.ToUIColor();
            }
            base.Draw(rect);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyLabelRenderer.StaticColorProperty.PropertyName))
            {
                MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
                Control.BackgroundColor = myLabelRenderer.StaticColor.ToUIColor();
            }
            if (e.PropertyName.Equals(MyLabelRenderer.TextColorProperty.PropertyName))
            {
                MyLabelRenderer myLabelRenderer = (MyLabelRenderer)Element;
                Control.TextColor = myLabelRenderer.TextColor.ToUIColor();
            }
        }
    }
}
