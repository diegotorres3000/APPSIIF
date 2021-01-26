using Xamarin.Forms;

namespace APPSIIF.Renderer
{
    public class MyImageRenderer : View
    {
        #region ForegroundProperty
        public static readonly BindableProperty ForegroundProperty =
        BindableProperty.Create(nameof(Foreground), typeof(Color), typeof(MyImageRenderer), default(Color));
        public Color Foreground
        {
            get => (Color)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }
        #endregion

        #region SourceProperty
        public static readonly BindableProperty SourceProperty =
        BindableProperty.Create(nameof(Source), typeof(string), typeof(MyImageRenderer), default(string));
        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
        #endregion

        #region BaseSourceProperty
        public static readonly BindableProperty BaseSourceProperty =
        BindableProperty.Create(nameof(BaseSource), typeof(string), typeof(MyImageRenderer), "https://imgappgyg.s3-sa-east-1.amazonaws.com/");
        public string BaseSource
        {
            get => (string)GetValue(BaseSourceProperty);
            set => SetValue(BaseSourceProperty, value);
        }
        #endregion

        #region IsShadow
        public static readonly BindableProperty IsShadowProperty =
        BindableProperty.Create(nameof(IsShadow), typeof(bool), typeof(MyImageRenderer), false);
        public bool IsShadow
        {
            get => (bool)GetValue(IsShadowProperty);
            set => SetValue(IsShadowProperty, value);
        }
        #endregion

        #region ShadowColorProperty
        public static readonly BindableProperty ShadowColorProperty =
        BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MyImageRenderer), default(Color));
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }
        #endregion
    }
}
