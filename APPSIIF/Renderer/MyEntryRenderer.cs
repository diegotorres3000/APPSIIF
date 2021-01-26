using Xamarin.Forms;

using APPSIIF.Enums;
//using SIIFMOVIL.ViewModels;
//using SQLite;

namespace APPSIIF.Renderer
{
    public class MyEntryRenderer : Entry
    {
        #region StaticColor
        public static readonly BindableProperty StaticColorProperty =
        BindableProperty.Create(nameof(StaticColor), typeof(Color), typeof(MyEntryRenderer), Color.White);
        public Color StaticColor
        {
            get => (Color)GetValue(StaticColorProperty);
            set => SetValue(StaticColorProperty, value);
        }
        #endregion

        #region TypeBorder
        public static readonly BindableProperty TypeBorderProperty =
        BindableProperty.Create(nameof(Enums.TypeBorder), typeof(TypeBorder), typeof(MyEntryRenderer), TypeBorder.All);
        public TypeBorder TypeBorder
        {
            get => (TypeBorder)GetValue(TypeBorderProperty);
            set => SetValue(TypeBorderProperty, value);
        }
        #endregion

        #region Position
        public static readonly BindableProperty PositionProperty =
        BindableProperty.Create(nameof(APPSIIF.Enums.Position), typeof(Position), typeof(MyEntryRenderer), Position.Left);
        public Position Position
        {
            get => (Position)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
        #endregion

        #region SourceImageLeftProperty
        public static readonly BindableProperty SourceImageLeftProperty =
        BindableProperty.Create(nameof(SourceImageLeft), typeof(string), typeof(MyEntryRenderer), "");
        public string SourceImageLeft
        {
            get => (string)GetValue(SourceImageLeftProperty);
            set => SetValue(SourceImageLeftProperty, value);
        }
        #endregion

        #region ImageLeftColorProperty
        public static readonly BindableProperty ImageLeftColorProperty =
        BindableProperty.Create(nameof(ImageLeftColor), typeof(Color), typeof(MyEntryRenderer), (Color)Application.Current.Resources["StartColorGradientText"]);
        public Color ImageLeftColor
        {
            get => (Color)GetValue(ImageLeftColorProperty);
            set => SetValue(ImageLeftColorProperty, value);
        }
        #endregion

        #region BoundsImageLeftProperty
        public static readonly BindableProperty BoundsImageLeftProperty =
        BindableProperty.Create(nameof(BoundsImageLeft), typeof(Rectangle), typeof(MyEntryRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageLeft
        {
            get => (Rectangle)GetValue(BoundsImageLeftProperty);
            set => SetValue(BoundsImageLeftProperty, value);
        }
        #endregion

        #region SourceImageRightProperty
        public static readonly BindableProperty SourceImageRightProperty =
        BindableProperty.Create(nameof(SourceImageRight), typeof(string), typeof(MyEntryRenderer), "");
        public string SourceImageRight
        {
            get => (string)GetValue(SourceImageRightProperty);
            set => SetValue(SourceImageRightProperty, value);
        }
        #endregion


        #region ImageRightColorProperty
        public static readonly BindableProperty ImageRightColorProperty =
        BindableProperty.Create(nameof(ImageRightColor), typeof(Color), typeof(MyEntryRenderer), (Color)Application.Current.Resources["EndColorGradientText"]);
        public Color ImageRightColor
        {
            get => (Color)GetValue(ImageRightColorProperty);
            set => SetValue(ImageRightColorProperty, value);
        }
        #endregion

        #region BoundsImageRightProperty
        public static readonly BindableProperty BoundsImageRightProperty =
        BindableProperty.Create(nameof(BoundsImageRight), typeof(Rectangle), typeof(MyEntryRenderer), new Rectangle(0, 0, 40, 40));
        public Rectangle BoundsImageRight
        {
            get => (Rectangle)GetValue(BoundsImageRightProperty);
            set => SetValue(BoundsImageRightProperty, value);
        }
        #endregion

        #region StartColor
        public static readonly BindableProperty StartColorProperty =
        BindableProperty.Create(nameof(StartColor), typeof(Color), typeof(MyEntryRenderer), (Color)Application.Current.Resources["StartColorGradient"]);
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        #endregion

        #region EndColor
        public static readonly BindableProperty EndColorProperty =
        BindableProperty.Create(nameof(EndColor), typeof(Color), typeof(MyEntryRenderer), (Color)Application.Current.Resources["EndColorGradient"]);
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }
        #endregion

        #region IsGradient
        public static readonly BindableProperty IsGradientProperty =
        BindableProperty.Create(nameof(IsGradient), typeof(bool), typeof(MyEntryRenderer), false);
        public bool IsGradient
        {
            get => (bool)GetValue(IsGradientProperty);
            set => SetValue(IsGradientProperty, value);
        }
        #endregion

        #region BaseSourceProperty
        public static readonly BindableProperty BaseSourceProperty =
        BindableProperty.Create(nameof(BaseSource), typeof(string), typeof(MyEntryRenderer), Constants.URLImg);
        public string BaseSource
        {
            get => (string)GetValue(BaseSourceProperty);
            set => SetValue(BaseSourceProperty, value);
        }
        #endregion

        #region IsRequired
        public static readonly BindableProperty IsRequiredProperty =
        BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(MyEntryRenderer), false);
        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }
        #endregion

        #region IsHelp
        public static readonly BindableProperty IsHelpProperty =
        BindableProperty.Create(nameof(IsHelp), typeof(bool), typeof(MyEntryRenderer), false);
        public bool IsHelp
        {
            get => (bool)GetValue(IsHelpProperty);
            set => SetValue(IsHelpProperty, value);
        }
        #endregion

        #region MyIsPassword
        public static readonly BindableProperty MyIsPasswordProperty =
        BindableProperty.Create(nameof(MyIsPassword), typeof(bool), typeof(MyEntryRenderer), false);
        public bool MyIsPassword
        {
            get => (bool)GetValue(MyIsPasswordProperty);
            set => SetValue(MyIsPasswordProperty, value);
        }
        #endregion

        #region IsEraser
        public static readonly BindableProperty IsEraserProperty =
        BindableProperty.Create(nameof(IsEraser), typeof(bool), typeof(MyEntryRenderer), false);
        public bool IsEraser
        {
            get => (bool)GetValue(IsEraserProperty);
            set => SetValue(IsEraserProperty, value);
        }
        #endregion

        #region TextHelp
        public static readonly BindableProperty TextHelpProperty =
        BindableProperty.Create(nameof(TextHelp), typeof(string), typeof(MyEntryRenderer), "");
        public string TextHelp
        {
            get => (string)GetValue(TextHelpProperty);
            set => SetValue(TextHelpProperty, value);
        }
        #endregion

        #region TypeProperty
        public static readonly BindableProperty TypeProperty =
        BindableProperty.Create(nameof(Type), typeof(string), typeof(MyEntryRenderer), "D");
        public string Type
        {
            get => (string)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }
        #endregion

        #region MaskProperty
        public static readonly BindableProperty MaskProperty =
        BindableProperty.Create(nameof(Mask), typeof(string), typeof(MyEntryRenderer), "N");
        public string Mask
        {
            get => (string)GetValue(MaskProperty);
            set => SetValue(MaskProperty, value);
        }
        #endregion

        #region MaxAccountProperty
        public static readonly BindableProperty MaxAccountProperty =
        BindableProperty.Create(nameof(MaxAccount), typeof(string), typeof(MyEntryRenderer), "0");
        public string MaxAccount
        {
            get => (string)GetValue(MaxAccountProperty);
            set => SetValue(MaxAccountProperty, value);
        }
        #endregion

        #region MyIsReadOnlyProperty
        public static readonly BindableProperty MyIsReadOnlyProperty =
        BindableProperty.Create(nameof(MyIsReadOnly), typeof(bool), typeof(MyEntryRenderer), true);
        public bool MyIsReadOnly
        {
            get => (bool)GetValue(MyIsReadOnlyProperty);
            set => SetValue(MyIsReadOnlyProperty, value);
        }
        #endregion

        public void DisplayAlertEntry()
        {
            //var db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
            //try
            //{
            //    HelpTextField helpTextField = db.Get<HelpTextField>(SourceImageLeft);
            //    MainViewModel.instance.PageInView.DisplayAlert(helpTextField.Title, helpTextField.Description, "Aceptar");
            //}
            //catch
            //{
            //    MainViewModel.instance.PageInView.DisplayAlert("Error", "La ayuda no se encuentra", "Aceptar");
            //}
                
        }

        public MyEntryRenderer()
        {
            //this.TextChanged += OnTextChange;
            this.SetDynamicResource(HeightRequestProperty, "MyContentFontSizeSpace");
            this.SetDynamicResource(FontSizeProperty, "MyContentFontSize");
        }

        private void OnTextChange(object sender, TextChangedEventArgs args)
        {
            if (Type == "N") { 
            this.TextChanged -= OnTextChange;

            string Mask = "XX:XX:XX";

            var entry = sender as Entry;
            var text = entry.Text;

            if (!string.IsNullOrWhiteSpace(Mask) && !string.IsNullOrEmpty(text) && args.NewTextValue != null && args.OldTextValue != null) { 

                // 1. Adding the MaxLength
                if (text.Length == Mask.Length)
                    entry.MaxLength = Mask.Length;

            // 2. Evaluating if the user is removing test
            if ((args.OldTextValue == null) || (args.OldTextValue.Length <= args.NewTextValue.Length))

                // 3. Evaluating mask positions
                for (int i = Mask.Length; i >= text.Length; i--)
                {
                    if (Mask[(text.Length - 1)] != 'X')
                    {
                        text = text.Insert((text.Length - 1), Mask[(text.Length - 1)].ToString());
                    }
                }
            entry.Text = text;
            }
            this.TextChanged += OnTextChange;
            }
        }
    }
}
