using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using APPSIIF.Renderer;
using APPSIIF.Enums;
using APPSIIF.Droid.Renderer;

[assembly: ExportRenderer(typeof(MyEditorRenderer), typeof(MyEditorRendererAndroid))]
namespace APPSIIF.Droid.Renderer
{
    [System.Obsolete]
    public class MyEditorRendererAndroid : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if ((Control != null) && (e.OldElement == null))
            {
                MyEditorRenderer myEditorRenderer = (MyEditorRenderer)Element;

                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(myEditorRenderer.StaticColor.ToAndroid());

                switch (myEditorRenderer.TypeBorder)
                {
                    case TypeBorder.All:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 80, 80,
                        80, 80, 80, 80});
                        break;
                    case TypeBorder.Left:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 0, 0,
                        0, 0, 80, 80});
                        break;
                    case TypeBorder.Right:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0, 80, 80,
                        80, 80, 0, 0});
                        break;
                    case TypeBorder.Down:
                        gradientDrawable.SetCornerRadii(new float[]{0, 0, 0, 0,
                        80, 80, 80, 80});
                        break;
                    case TypeBorder.Up:
                        gradientDrawable.SetCornerRadii(new float[]{80, 80, 80, 80,
                        0, 0, 0, 0});
                        break;
                }
                Control.SetPadding(40, 20, 40, 20);
                Control.SetBackground(gradientDrawable);
            }
        }
    }
}
