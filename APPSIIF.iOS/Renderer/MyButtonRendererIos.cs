using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using CoreAnimation;
using CoreGraphics;
using System.Linq;
using UIKit;
using APPSIIF.Enums;
using APPSIIF.Converters;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyButtonRenderer), typeof(MyButtonRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyButtonRendererIos : ButtonRenderer
    {
        TypeBorder TypeBorder;

        public override void LayoutSubviews()
        {

            var newBounds = Element.Bounds.ToRectangleF();
            foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                layer.Frame = new CGRect(0, 0, newBounds.Width, newBounds.Height);

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
                Control.Layer.Mask = cAShapeLayer;
            }
            base.LayoutSubviews();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null && e.NewElement != null)
            {
                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                if (!myButtonRenderer.IsEnabled)
                {
                    SetDrawable2(myButtonRenderer.StartColor, myButtonRenderer.EndColor);
                }
                else {
                    SetDrawable(myButtonRenderer);
                }
                TypeBorder = myButtonRenderer.TypeBorder;
                
            }
        }

        void SetDrawable(MyButtonRenderer myButtonRenderer)
        {
            if (myButtonRenderer.IsGradient)
            {
                Color StartColor = ColorInterpolator.InterpolateBetween(myButtonRenderer.EndColor,
                    myButtonRenderer.StartColor,
                    myButtonRenderer.NumOfGradientStart);
                Color EndColor = ColorInterpolator.InterpolateBetween(myButtonRenderer.StartColor,
                    myButtonRenderer.EndColor,
                    myButtonRenderer.NumOfGradientEnd);
                var gradient = new CAGradientLayer();
                gradient.Colors = new CGColor[]
                {
                    StartColor.ToCGColor(),
                    EndColor.ToCGColor()
                };
                gradient.StartPoint = new CGPoint(0, 0.5);
                gradient.EndPoint = new CGPoint(1, 0.5);
                Control.Layer.InsertSublayer(gradient, 0);
            }
            else
            {
                Control.BackgroundColor = myButtonRenderer.StaticColor.ToUIColor();
            }
        }

        void SetDrawable(Color StartColor, Color EndColor)
        {
            MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;

            if (myButtonRenderer.IsGradient)
            {
                if (!myButtonRenderer.IsEnabled)
                {
                    StartColor = System.Drawing.Color.FromArgb(70, StartColor);
                    EndColor = System.Drawing.Color.FromArgb(70, EndColor);
                }

                var gradient = new CAGradientLayer();
                gradient.Colors = new CGColor[]
                {
                StartColor.ToCGColor(),
                EndColor.ToCGColor()
                };
                gradient.StartPoint = new CGPoint(0, 0.5);
                gradient.EndPoint = new CGPoint(1, 0.5);
                Control.Layer.ReplaceSublayer(Control?.Layer.Sublayers[0], gradient);

                var newBounds = Element.Bounds.ToRectangleF();
                foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                    layer.Frame = new CGRect(0, 0, newBounds.Width, newBounds.Height);
            }
            else
            {
                if (!myButtonRenderer.IsEnabled)
                {
                    Color staticColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.StaticColor);
                    Control.BackgroundColor = staticColor.ToUIColor();
                }
                else
                {
                    Control.BackgroundColor = myButtonRenderer.StaticColor.ToUIColor();
                }
                    
            }
        }

        void SetDrawable2(Color StartColor, Color EndColor)
        {
            MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;

            if (myButtonRenderer.IsGradient)
            {
                StartColor = System.Drawing.Color.FromArgb(70, StartColor);
                EndColor = System.Drawing.Color.FromArgb(70, EndColor);


                var gradient = new CAGradientLayer();
                gradient.Colors = new CGColor[]
                {
                StartColor.ToCGColor(),
                EndColor.ToCGColor()
                };
                gradient.StartPoint = new CGPoint(0, 0.5);
                gradient.EndPoint = new CGPoint(1, 0.5);
                Control.Layer.InsertSublayer(gradient, 0);

                var newBounds = Element.Bounds.ToRectangleF();
                foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                    layer.Frame = new CGRect(0, 0, newBounds.Width, newBounds.Height);
            }
            else
            {
                Color staticColor = System.Drawing.Color.FromArgb(70, myButtonRenderer.StaticColor);
                Control.BackgroundColor = staticColor.ToUIColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(MyButtonRenderer.StaticColorProperty.PropertyName))
            {
                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                Control.BackgroundColor = myButtonRenderer.StaticColor.ToUIColor();
            }
            if (e.PropertyName.Equals(MyButtonRenderer.IsEnabledProperty.PropertyName))
            {
                MyButtonRenderer myButtonRenderer = (MyButtonRenderer)Element;
                if (!myButtonRenderer.IsEnabled)
                {
                    //SetDrawable2(myButtonRenderer.StartColor, myButtonRenderer.EndColor);
                    //Control.TintColor = Color.White.ToUIColor();
                    SetDrawable(myButtonRenderer.StartColor, myButtonRenderer.EndColor);
                    var newBounds = Element.Bounds.ToRectangleF();
                    foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                        layer.Frame = new CGRect(0, 0, newBounds.Width, newBounds.Height);
                }
                else
                    {
                    SetDrawable(myButtonRenderer.StartColor, myButtonRenderer.EndColor);
                    /*if (myButtonRenderer.IsGradient)
                    {

                    }
                    else
                    {
                        SetDrawable(myButtonRenderer.StartColor, myButtonRenderer.EndColor);
                        var newBounds = Element.Bounds.ToRectangleF();
                        foreach (var layer in Control?.Layer.Sublayers.Where(layer => layer is CAGradientLayer))
                            layer.Frame = new CGRect(0, 0, newBounds.Width, newBounds.Height);
                    }*/
                }
            }
        }
    }
}
