using System;
using Xamarin.Forms;

namespace APPSIIF.Converters
{
    /**
     * clase que permite hallar el color intermendio de
     * otros dos colores
     */
    public class ColorInterpolator
    {
        delegate double ComponentSelector(Color color);
        static ComponentSelector _redSelector = color => color.R;
        static ComponentSelector _greenSelector = color => color.G;
        static ComponentSelector _blueSelector = color => color.B;

        /**
         * metodo para hallar la mitad de dos colores
         */
        public static Color InterpolateBetween(
            Color endPoint1,
            Color endPoint2,
            double lambda)
        {
            if (lambda < 0 || lambda > 1)
            {
                throw new ArgumentOutOfRangeException("lambda");
            }
            Color color = Color.FromRgb(
                InterpolateComponent(endPoint1, endPoint2, lambda, _redSelector),
                InterpolateComponent(endPoint1, endPoint2, lambda, _greenSelector),
                InterpolateComponent(endPoint1, endPoint2, lambda, _blueSelector)
            );

            return color;
        }

        static double InterpolateComponent(
            Color endPoint1,
            Color endPoint2,
            double lambda,
            ComponentSelector selector)
        {
            return (double)(selector(endPoint1)
                + (selector(endPoint2) - selector(endPoint1)) * lambda);
        }
    }
}
