using Xamarin.Forms;

namespace APPSIIF.Renderer
{
    public class MyProgressBarRenderer : ProgressBar
    {
        #region ProgressHeight
        public static readonly BindableProperty ProgressHeightProperty =
        BindableProperty.Create(nameof(ProgressHeight), typeof(double), typeof(MyProgressBarRenderer), 5.0);
        public double ProgressHeight
        {
            get => (double)GetValue(ProgressHeightProperty);
            set => SetValue(ProgressHeightProperty, value);
        }
        #endregion
    }
}
