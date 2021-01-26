using System;
using Foundation;
using SIIFMOVIL.iOS.Renderer;
using SIIFMOVIL.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UICollectionViewCell), typeof(MyCollectionViewSource))]
namespace SIIFMOVIL.iOS.Renderer
{
    public class MyCollectionViewSource : UICollectionViewCell
    {
        [Export("")]
        public override UIView SelectedBackgroundView { get => base.SelectedBackgroundView; set => base.SelectedBackgroundView = value; }
    }
}
