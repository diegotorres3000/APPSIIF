using Xamarin.Forms;
using APPSIIF.Enums;

namespace APPSIIF.Renderer
{
    public class MyFrameRenderer : Frame
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyFrameRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyFrameRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyFrameRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion

        #region Direction
        public static readonly BindableProperty DirectionProperty =
        BindableProperty.Create(nameof(Direction), typeof(Direction), typeof(MyFrameRenderer), Enums.Direction.LeftRight);
        public Enums.Direction Direction
        {
            get => (Enums.Direction)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }
        #endregion


        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(Enums.TypeBorder), typeof(TypeBorder), typeof(MyFrameRenderer), Enums.TypeBorder.All);
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion

        #region BorderRadius
        public static readonly BindableProperty BorderRadiusProperty =
        BindableProperty.Create(nameof(BorderRadius), typeof(int), typeof(MyFrameRenderer), 0);
        public int BorderRadius
        {
            get => (int)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyFrameRenderer), true);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty);
            set => SetValue(IsGradientProperty, value);
        }
        #endregion

        #region Orientation
        public static readonly BindableProperty OrientationProperty =
        BindableProperty.Create(nameof(Orientation), typeof(Orientation), typeof(MyFrameRenderer), (Orientation)Application.Current.Resources["Orientation"]);
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        #endregion

        public MyFrameRenderer()
        {
            SetDynamicResource(OrientationProperty, "Orientation");
        }
    }
}
