using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using APPSIIF.Droid.Renderer;
using Android.Graphics.Drawables;
using Android.Content;
using Android.Views;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ViewCell), typeof(MyCellRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    public class MyCellRendererAndroid : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);

            _selected = false;
            _unselectedBackground = _cellCore.Background;

            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);

            if (args.PropertyName == "IsSelected")
            {
                _selected = !_selected;

                if (_selected)
                {
                    Xamarin.Forms.Color color = (Xamarin.Forms.Color)Application.Current.Resources["BackColor"];
                    _cellCore.SetBackgroundColor(color.ToAndroid());
                }
                else
                {
                    _cellCore.SetBackground(_unselectedBackground);
                }
            }
        }
    }
}
