using System;
using Xamarin.Forms;

namespace APPSIIF.Renderer
{
    public class MyPopUpRenderer : ContentPage
    {

        #region OptionCenterHeader
        public static readonly BindableProperty OptionCenterHeaderProperty = BindableProperty.Create(nameof(OptionCenterHeader), typeof(int), typeof(MyPopUpRenderer), 0);
        public int OptionCenterHeader
        {
            get => (int)GetValue(OptionCenterHeaderProperty);
            set => SetValue(OptionCenterHeaderProperty, value);
        }
        #endregion

        #region OptionCenterHeader
        public static readonly BindableProperty PageToGoProperty = BindableProperty.Create(nameof(PageToGo), typeof(object), typeof(MyPopUpRenderer), typeof(MyPopUpRenderer));
        public Type PageToGo
        {
            get => (Type)GetValue(PageToGoProperty);
            set => SetValue(PageToGoProperty, value);
        }
        #endregion

        #region ContentBody
        public static readonly BindableProperty ContentBodyProperty = BindableProperty.Create(nameof(ContentBody), typeof(int), typeof(MyPopUpRenderer), null);
        public StackLayout ContentBody
        {
            get => (StackLayout)GetValue(ContentBodyProperty);
            set => SetValue(ContentBodyProperty, value);
        }
        #endregion

        StackLayout content;
        public MyPopUpRenderer Page;
        public bool CancelIsClicked;

        public MyPopUpRenderer()
        {
            PaintHeader();
        }

        void PaintHeader()
        {
            content = new StackLayout
            {
                Spacing = 0
            };
            MyFrameRenderer myFrameRenderer = new MyFrameRenderer
            {
                TypeBorder = Enums.TypeBorder.None,
                Padding = 0
            };
            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1 , GridUnitType.Star)},
                    new ColumnDefinition{ Width = 80},
                    new ColumnDefinition{ Width = new GridLength(1 , GridUnitType.Star)}
                },
                RowDefinitions =
                {
                    new RowDefinition{ Height = 80 }
                }
            };
            MyImageRenderer myImageRenderer = new MyImageRenderer
            {
                Source = "back",
                HeightRequest = 40,
                WidthRequest = 40,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                Foreground = Color.White
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                CancelIsClicked = true;
                Cancel();
            };
            myImageRenderer.GestureRecognizers.Add(tapGestureRecognizer);

            grid.Children.Add(myImageRenderer, 0, 0);
            myFrameRenderer.Content = grid;
            content.Children.Add(myFrameRenderer);
            this.Content = content;

            MyButtonRenderer myButtonRenderer = new MyButtonRenderer
            {
                IsGradient = true,
                Text = "enviar",
                TextColor = Color.White
            };
            myButtonRenderer.Clicked += go;
            content.Children.Add(myButtonRenderer);

            if (this.OptionCenterHeader == 0)
            {

            }
        }

        protected override void OnDisappearing()
        {
            if (!CancelIsClicked)
            {
                Cancel();
            }
            base.OnDisappearing();
        }

        private async void Cancel()
        {
            Page.CancelIsClicked = false;
            await Navigation.PopModalAsync();
        }

        void go(Object sender, EventArgs args)
        {
            var page = (Page)Activator.CreateInstance(PageToGo, this);
            //Page = (MyPopUpRenderer)page;
            Navigation.PushModalAsync(page);
        }

        virtual public void go(Page page)
        {
            Navigation.PushModalAsync(this);
        }
    }
}
