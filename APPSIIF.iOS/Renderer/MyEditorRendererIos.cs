using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.Renderer;
using APPSIIF.iOS.Renderer;
using UIKit;
using CoreAnimation;
using APPSIIF.Enums;

[assembly: ExportRenderer(typeof(MyEditorRenderer), typeof(MyEditorRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyEditorRendererIos : EditorRenderer
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

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                MyEditorRenderer myEditorRenderer = (MyEditorRenderer)Element;
                TypeBorder = myEditorRenderer.TypeBorder;
                Control.TextContainerInset = new UIEdgeInsets(10, 10, 10, 10);
            }
        }

        public override void Draw(CGRect rect)
        {
            MyEditorRenderer myEditorRenderer = (MyEditorRenderer)Element;
            Control.BackgroundColor = myEditorRenderer.StaticColor.ToUIColor();
        }
    }
}
