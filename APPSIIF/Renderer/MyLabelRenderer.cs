using Xamarin.Forms;
using APPSIIF.Enums;

namespace APPSIIF.Renderer
{
    public class MyLabelRenderer : Label
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyLabelRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyLabelRenderer), false);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty); 
            set => SetValue(IsGradientProperty, value); 
        }
        #endregion

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyLabelRenderer), Color.White);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty); 
            set => SetValue(StartColorProperty, value); 
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyLabelRenderer), Color.White);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty); 
            set => SetValue(EndColorProperty, value); 
        }
        #endregion

        #region BorderRadius
        public static readonly BindableProperty BorderRadiusProperty =
        BindableProperty.Create(nameof(BorderRadius), typeof(int), typeof(MyLabelRenderer), 20);
        public int BorderRadius
        {
            get => (int)GetValue(BorderRadiusProperty);
            set => SetValue(BorderRadiusProperty, value);
        }
        #endregion


        #region NumToGradient
        public static readonly BindableProperty NumToGradientProperty =
        BindableProperty.Create(nameof(NumToGradient), typeof(double), typeof(MyLabelRenderer), 1.0);
        public double NumToGradient
        {
            get => (double)GetValue(NumToGradientProperty);
            set => SetValue(NumToGradientProperty, value);
        }
        #endregion


        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(APPSIIF.Enums.TypeBorder), typeof(TypeBorder), typeof(MyLabelRenderer), APPSIIF.Enums.TypeBorder.None);
        /// <summary>
        /// Gets or sets the shadow color of the text.
        /// </summary>
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion
    }
}
