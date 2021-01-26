using Xamarin.Forms;
using APPSIIF.Enums;

namespace APPSIIF.Renderer
{
    public class MyPickerRenderer : Picker
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyPickerRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(APPSIIF.Enums.TypeBorder), typeof(TypeBorder), typeof(MyPickerRenderer), TypeBorder.All);
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion

        #region Position
        public static readonly BindableProperty PositionProperty =
        BindableProperty.Create(nameof(APPSIIF.Enums.Position), typeof(Position), typeof(MyPickerRenderer), Position.Center);
        public Position Position
        {
            get => (Position)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
        #endregion

        #region SourceImageLeftProperty
        public static readonly BindableProperty SourceImageLeftProperty =
        BindableProperty.Create(nameof(SourceImageLeft), typeof(string), typeof(MyPickerRenderer), "");
        public string SourceImageLeft
        {
            get => (string)GetValue(SourceImageLeftProperty);
            set => SetValue(SourceImageLeftProperty, value);
        }
        #endregion

        #region ImageLeftColorProperty
        public static readonly BindableProperty ImageLeftColorProperty =
        BindableProperty.Create(nameof(ImageLeftColor), typeof(Color), typeof(MyPickerRenderer), (Color)Application.Current.Resources["StartColorGradientText"]);
        public Color ImageLeftColor
        {
            get => (Color)GetValue(ImageLeftColorProperty);
            set => SetValue(ImageLeftColorProperty, value);
        }
        #endregion

        #region BoundsImageLeftProperty
        public static readonly BindableProperty BoundsImageLeftProperty =
        BindableProperty.Create(nameof(BoundsImageLeft), typeof(Rectangle), typeof(MyPickerRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageLeft
        {
            get => (Rectangle)GetValue(BoundsImageLeftProperty);
            set => SetValue(BoundsImageLeftProperty, value);
        }
        #endregion

        #region SourceImageRightProperty
        public static readonly BindableProperty SourceImageRightProperty =
        BindableProperty.Create(nameof(SourceImageRight), typeof(string), typeof(MyPickerRenderer), "");
        public string SourceImageRight
        {
            get => (string)GetValue(SourceImageRightProperty);
            set => SetValue(SourceImageRightProperty, value);
        }
        #endregion


        #region ImageRightColorProperty
        public static readonly BindableProperty ImageRightColorProperty =
        BindableProperty.Create(nameof(ImageRightColor), typeof(Color), typeof(MyPickerRenderer), (Color)Application.Current.Resources["EndColorGradientText"]);
        public Color ImageRightColor
        {
            get => (Color)GetValue(ImageRightColorProperty);
            set => SetValue(ImageRightColorProperty, value);
        }
        #endregion

        #region BoundsImageRightProperty
        public static readonly BindableProperty BoundsImageRightProperty =
        BindableProperty.Create(nameof(BoundsImageRight), typeof(Rectangle), typeof(MyPickerRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageRight
        {
            get => (Rectangle)GetValue(BoundsImageRightProperty);
            set => SetValue(BoundsImageRightProperty, value);
        }
        #endregion

        #region TextFieldName
        public static readonly BindableProperty TextFieldNameProperty =
        BindableProperty.Create(nameof(TextFieldName), typeof(string), typeof(MyPickerRenderer), "");
        public string TextFieldName
        {
            get => (string)GetValue(TextFieldNameProperty);
            set => SetValue(TextFieldNameProperty, value);
        }
        #endregion

        #region IsRequired
        public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(MyPickerRenderer), false);
        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyPickerRenderer), false);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty);
            set => SetValue(IsGradientProperty, value);
        }
        #endregion

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyPickerRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyPickerRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion

        public MyPickerRenderer()
        {
            this.SetDynamicResource(HeightRequestProperty, "MyContentFontSizeSpace");
            this.SetDynamicResource(FontSizeProperty, "MyContentFontSize");
        }
    }
}
