using System;
using Foundation;
using SIIFMOVIL.iOS.Renderer;
using SIIFMOVIL.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyCollectionViewRenderer), typeof(MyCollectionViewRendererIos))]
namespace SIIFMOVIL.iOS.Renderer
{
    public class MyCollectionViewRendererIos : CollectionViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ItemsView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                NSArray s = Control.ValueForKey(new NSString("_subviewCache")) as NSMutableArray;
                UICollectionView c = s.GetItem<UICollectionView>(0);
                c.ShowsHorizontalScrollIndicator = false;
            }
            
        }

        public override void DidChange(NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey)
        {
            var a = indexes;
            base.DidChange(changeKind, indexes, forKey);
        }

    }
}
