using Xamarin.Forms;
using APPSIIF.Enums;
//using SQLite;
//using SIIFMOVIL.Models.DynamicPages;
//using SIIFMOVIL.ViewModels;


namespace APPSIIF.Renderer
{
    public class MyPickerDateRenderer : DatePicker
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyPickerDateRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region SourceImageLeftProperty
        public static readonly BindableProperty SourceImageLeftProperty =
        BindableProperty.Create(nameof(SourceImageLeft), typeof(string), typeof(MyPickerDateRenderer), "");
        public string SourceImageLeft
        {
            get => (string)GetValue(SourceImageLeftProperty);
            set => SetValue(SourceImageLeftProperty, value);
        }
        #endregion

        #region ImageLeftColorProperty
        public static readonly BindableProperty ImageLeftColorProperty =
        BindableProperty.Create(nameof(ImageLeftColor), typeof(Color), typeof(MyPickerDateRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color ImageLeftColor
        {
            get => (Color)GetValue(ImageLeftColorProperty);
            set => SetValue(ImageLeftColorProperty, value);
        }
        #endregion

        #region BoundsImageLeftProperty
        public static readonly BindableProperty BoundsImageLeftProperty =
        BindableProperty.Create(nameof(BoundsImageLeft), typeof(Rectangle), typeof(MyPickerDateRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageLeft
        {
            get => (Rectangle)GetValue(BoundsImageLeftProperty);
            set => SetValue(BoundsImageLeftProperty, value);
        }
        #endregion

        #region SourceImageRightProperty
        public static readonly BindableProperty SourceImageRightProperty =
        BindableProperty.Create(nameof(SourceImageRight), typeof(string), typeof(MyPickerDateRenderer), "");
        public string SourceImageRight
        {
            get => (string)GetValue(SourceImageRightProperty);
            set => SetValue(SourceImageRightProperty, value);
        }
        #endregion

        #region ImageRightColorProperty
        public static readonly BindableProperty ImageRightColorProperty =
        BindableProperty.Create(nameof(ImageRightColor), typeof(Color), typeof(MyPickerDateRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color ImageRightColor
        {
            get => (Color)GetValue(ImageRightColorProperty);
            set => SetValue(ImageRightColorProperty, value);
        }
        #endregion

        #region BoundsImageRightProperty
        public static readonly BindableProperty BoundsImageRightProperty =
        BindableProperty.Create(nameof(BoundsImageRight), typeof(Rectangle), typeof(MyPickerDateRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageRight
        {
            get => (Rectangle)GetValue(BoundsImageRightProperty);
            set => SetValue(BoundsImageRightProperty, value);
        }
        #endregion

        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(Enums.TypeBorder), typeof(TypeBorder), typeof(MyPickerDateRenderer), Enums.TypeBorder.All);
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion

        #region PlaceholderProperty
        public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MyPickerDateRenderer), "");
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        #endregion

        #region IsHelp
        public static readonly BindableProperty IsHelpProperty =
        BindableProperty.Create(nameof(IsHelp), typeof(bool), typeof(MyPickerDateRenderer), false);
        public bool IsHelp
        {
            get => (bool)GetValue(IsHelpProperty);
            set => SetValue(IsHelpProperty, value);
        }
        #endregion

        #region IsEraser
        public static readonly BindableProperty IsEraserProperty =
        BindableProperty.Create(nameof(IsEraser), typeof(bool), typeof(MyPickerDateRenderer), false);
        public bool IsEraser
        {
            get => (bool)GetValue(IsEraserProperty);
            set => SetValue(IsEraserProperty, value);
        }
        #endregion

        #region IsRequired
        public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(MyPickerDateRenderer), false);
        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
        #endregion

        public MyPickerDateRenderer()
        {
            this.SetDynamicResource(HeightRequestProperty, "MyContentFontSizeSpace");
            this.SetDynamicResource(FontSizeProperty, "MyContentFontSize");
        }

        public void DisplayAlertEntry()
        {
            //var db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
            //try
            //{
                //HelpTextField helpTextField = db.Get<HelpTextField>(SourceImageLeft);
                //MainViewModel.instance.PageInView.DisplayAlert(helpTextField.Title, helpTextField.Description, "Aceptar");
            //}
            //catch
            //{
                //MainViewModel.instance.PageInView.DisplayAlert("Error", "La ayuda no se encuentra", "Aceptar");
            //}
        }
    }
}
