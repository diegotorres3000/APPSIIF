using Xamarin.Forms;
using APPSIIF.Enums;

namespace APPSIIF.Renderer
{
    public class MyButtonRenderer : Button
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyButtonRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyButtonRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyButtonRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion

        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(Enums.TypeBorder), typeof(TypeBorder), typeof(MyButtonRenderer), Enums.TypeBorder.All);
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyButtonRenderer), true);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty);
            set => SetValue(IsGradientProperty, value);
        }
        #endregion

        #region NumOfGradientStart
        public static readonly BindableProperty NumOfGradientStartProperty =
        BindableProperty.Create(nameof(NumOfGradientStart), typeof(double), typeof(MyButtonRenderer), 1.0);
        public double NumOfGradientStart
        {
            get => (double)GetValue(NumOfGradientStartProperty);
            set => SetValue(NumOfGradientStartProperty, value);
        }
        #endregion

        #region NumOfGradientEnd
        public static readonly BindableProperty NumOfGradientEndProperty =
        BindableProperty.Create(nameof(NumOfGradientEnd), typeof(double), typeof(MyButtonRenderer), 1.0);
        public double NumOfGradientEnd
        {
            get => (double)GetValue(NumOfGradientEndProperty);
            set => SetValue(NumOfGradientEndProperty, value);
        }
        #endregion

        public MyButtonRenderer()
        {
            this.SetDynamicResource(HeightRequestProperty, "MyContentFontSizeSpace");
            this.SetDynamicResource(FontSizeProperty, "MyContentFontSize");
        }
    }
}
