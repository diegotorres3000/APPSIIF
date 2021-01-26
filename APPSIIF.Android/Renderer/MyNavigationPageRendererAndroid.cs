using System;
using Android.Content;
using Android.Graphics.Drawables;
using APPSIIF.Droid.Renderer;
using APPSIIF.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MyNavigationPageRenderer), typeof(MyNavigationPageRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [Obsolete]
    public class MyNavigationPageRendererAndroid : NavigationPageRenderer
    {

        private Android.Support.V7.Widget.Toolbar _toolbar;

        public MyNavigationPageRendererAndroid(Context context) : base(context)
        {

        }       

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                _toolbar = (Android.Support.V7.Widget.Toolbar)child;
                MyNavigationPageRenderer myNavigationPageRenderer = (MyNavigationPageRenderer)Element;
                GradientDrawable gradientDrawable = new GradientDrawable(
                    GradientDrawable.Orientation.LeftRight,
                    new int[] { myNavigationPageRenderer.StartColor.ToAndroid(),
                            myNavigationPageRenderer.EndColor.ToAndroid() });
                _toolbar.SetBackgroundDrawable(gradientDrawable);
                _toolbar.Elevation = 0;
            }
        }


        protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        {
            if (isPush)
            {
                transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                Resource.Animation.enter_left, Resource.Animation.exit_right);
            }
            else
            {
                transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                Resource.Animation.enter_right, Resource.Animation.exit_left);
            }
        }
    }
}
