using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using APPSIIF.iOS.Renderer;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ViewCell), typeof(MyCellRendererIos))]
namespace APPSIIF.iOS.Renderer
{
    public class MyCellRendererIos : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = UIColor.Clear,
            };
            return cell;
        }

        void OnNativeCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
