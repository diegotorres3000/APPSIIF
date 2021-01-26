using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using APPSIIF.iOS.Renderer;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyFrameRenderer), typeof(MyFrameRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyFrameRendererIos : FrameRenderer
    {
        Xamarin.Forms.Color StartColor;
        Xamarin.Forms.Color EndColor;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
            CAShapeLayer cAShapeLayer = null;
            switch (myFrameRenderer.TypeBorder)
            {
                case TypeBorder.All:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft | UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(myFrameRenderer.BorderRadius, myFrameRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Right:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomRight | UIRectCorner.TopRight,
                        new CGSize(myFrameRenderer.BorderRadius, myFrameRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Up:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.TopLeft | UIRectCorner.TopRight,
                        new CGSize(myFrameRenderer.BorderRadius, myFrameRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Left:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.TopLeft,
                        new CGSize(myFrameRenderer.BorderRadius, myFrameRenderer.BorderRadius)).CGPath
                    };
                    break;
                case TypeBorder.Down:
                    cAShapeLayer = new CAShapeLayer()
                    {
                        Path = UIBezierPath.FromRoundedRect(base.Bounds,
                        UIRectCorner.BottomLeft | UIRectCorner.BottomRight,
                        new CGSize(myFrameRenderer.BorderRadius, myFrameRenderer.BorderRadius)).CGPath
                    };
                    break;
            }
            if (!myFrameRenderer.IsGradient)
            {
                Layer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
                //cAShapeLayer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
            }
            base.Layer.Mask = cAShapeLayer;
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                StartColor = myFrameRenderer.StartColor;
                EndColor = myFrameRenderer.EndColor;
                if (!myFrameRenderer.IsGradient)
                {
                    Layer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
                }
            }
            if (e.NewElement != null)
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                if (!myFrameRenderer.IsGradient)
                {
                    Layer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
                }
            }
        }

        public override void Draw(CGRect rect)
        {
            MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
            if (myFrameRenderer.IsGradient)
            {
                AddGradient(rect);
            }
            else
            {
                Layer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
            }
            base.Draw(rect);
        }

        public static CGColor ToCGColor(Xamarin.Forms.Color color)
        {
            return new CGColor(CGColorSpace.CreateSrgb(), new nfloat[] { (float)color.R, (float)color.G, (float)color.B, (float)color.A });
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(MyFrameRenderer.StaticColorProperty.PropertyName))
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                Layer.BackgroundColor = myFrameRenderer.StaticColor.ToCGColor();
            }else if (e.PropertyName.Equals(MyFrameRenderer.HeightProperty.PropertyName))
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                if (myFrameRenderer.IsGradient)
                    AddGradient(new CGRect(0, 0, myFrameRenderer.Width, myFrameRenderer.Height));
            }
            else if (e.PropertyName.Equals(MyFrameRenderer.OrientationProperty.PropertyName))
            {
                MyFrameRenderer myFrameRenderer = (MyFrameRenderer)Element;
                if (myFrameRenderer.IsGradient)
                    AddGradient(new CGRect(0, 0, myFrameRenderer.Width, myFrameRenderer.Height));
            } 
        }

        public void AddGradient(CGRect rect)
        {
            if (Layer.Sublayers.Length > 1)
            {
                Layer.Sublayers[0].RemoveFromSuperLayer();
            }
            var gradientLayer = new CAGradientLayer
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5),
                Frame = rect,
                Colors = new CGColor[]
                { ToCGColor(StartColor), ToCGColor(EndColor) }
            };
            Layer.BackgroundColor = UIColor.Clear.CGColor;
            Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}