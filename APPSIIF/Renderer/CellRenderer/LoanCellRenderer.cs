using System;
using Xamarin.Forms;

namespace APPSIIF.Renderer.CellRenderer
{
    public class LoanCellRenderer : ViewCell
    {
        public LoanCellRenderer()
        {
            Label LabelAccountNumber = new Label
            {
                Style = (Style)Application.Current.Resources["MyContent"],
                HorizontalTextAlignment = TextAlignment.Start,
            };
            LabelAccountNumber.SetDynamicResource(Label.TextColorProperty, "StartColorGradientText");

            Label LabelAccountBalance = new Label
            {
                Style = (Style)Application.Current.Resources["MyContent"],
                HorizontalTextAlignment = TextAlignment.End,
            };
            LabelAccountBalance.SetDynamicResource(Label.TextColorProperty, "EndColorGradientText");

            //Binding
            LabelAccountNumber.SetBinding(Label.TextProperty, "Number");
            LabelAccountBalance.SetBinding(Label.TextProperty, "Balance");

            Grid grid = new Grid();
            grid.Children.Add(LabelAccountNumber, 0, 0);
            grid.Children.Add(LabelAccountBalance, 1, 0);

            MyFrameRenderer myFrameRenderer = new MyFrameRenderer
            {
                Margin = new Thickness(20, 10, 20, 10),
                TypeBorder = Enums.TypeBorder.All,
                IsGradient = false,
                BorderRadius = 10
            };
            myFrameRenderer.SetDynamicResource(MyFrameRenderer.StaticColorProperty, "ItemColor");

            myFrameRenderer.Content = grid;

            View = myFrameRenderer;
        }
    }
}
