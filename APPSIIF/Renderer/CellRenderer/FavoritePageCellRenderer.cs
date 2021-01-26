using System;
using APPSIIF.Converters;
using APPSIIF.ViewModels;
using Lottie.Forms;
using Xamarin.Forms;

namespace APPSIIF.Renderer.CellRenderer
{
    public class FavoritePageCellRenderer : ViewCell
    {
        public FavoritePageCellRenderer()
        {
            MyImageRenderer ImagePageModule = new MyImageRenderer
            {
                Source = "empresa",
                Foreground = Color.Transparent,
                HeightRequest = (double)Application.Current.Resources["MyMenuImageSize"],
                WidthRequest = (double)Application.Current.Resources["MyMenuImageSize"]
            };

            Label LabelPageTitle = new Label
            {
                Style = (Style)Application.Current.Resources["MyContent"],
                HorizontalTextAlignment = TextAlignment.Start,
            };
            LabelPageTitle.SetDynamicResource(Label.TextColorProperty, "StartColorGradientText");

            Label LabelPageModule = new Label
            {
                Style = (Style)Application.Current.Resources["MyContent"],
                HorizontalTextAlignment = TextAlignment.Start,
            };
            LabelPageModule.SetDynamicResource(Label.TextColorProperty, "EndColorGradientText");


            AnimationView ImageBoxItsBeingUsed = new AnimationView
            {
                Animation = "favorite.json",
                Loop = false,
                IsPlaying = true,
                HeightRequest = (double)Application.Current.Resources["MyMenuImageSize"]/1.5,
                WidthRequest = (double)Application.Current.Resources["MyMenuImageSize"]/1.5
            };
            ImageBoxItsBeingUsed.SetDynamicResource(MyImageRenderer.ForegroundProperty, "EndColorGradientText");

            //Binding
            LabelPageTitle.SetBinding(Label.TextProperty, "Title");
            LabelPageModule.SetBinding(Label.TextProperty, "Module");
            ImageBoxItsBeingUsed.SetBinding(VisualElement.IsVisibleProperty, "ItsBeingUsed");

            Grid grid = new Grid {
                ColumnDefinitions = {
                    new ColumnDefinition { Width =  (double)Application.Current.Resources["MyMenuImageSize"]+20},
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width =  (double)Application.Current.Resources["MyMenuImageSize"]},
                },
                ColumnSpacing = 20
            };
            grid.Children.Add(ImagePageModule, 0, 0);
            Grid.SetRowSpan(ImagePageModule, 2);
            grid.Children.Add(LabelPageTitle, 1, 0);
            grid.Children.Add(LabelPageModule, 1, 1);
            grid.Children.Add(ImageBoxItsBeingUsed, 2, 0);
            Grid.SetRowSpan(ImageBoxItsBeingUsed, 2);

            MyFrameRenderer myFrameRenderer = new MyFrameRenderer
            {
                Margin = new Thickness((int)Application.Current.Resources["MySideMargin"], (int)Application.Current.Resources["MyEndsMarginList"], (int)Application.Current.Resources["MySideMargin"], (int)Application.Current.Resources["MyEndsMarginList"]),
                TypeBorder = Enums.TypeBorder.All,
                IsGradient = false,
                BorderRadius = 20
            };
            myFrameRenderer.SetDynamicResource(MyFrameRenderer.StaticColorProperty, "ItemColor");

            myFrameRenderer.Content = grid;

            View = myFrameRenderer;
        }
    }
}
