using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SIIFMOVIL.Renderer;
using SIIFMOVIL.iOS.Renderer;
using UIKit;
using Foundation;
using CoreAnimation;
using SIIFMOVIL.Enums;
using System.ComponentModel;
using Xamarin.Forms.GoogleMaps.iOS;
using Xamarin.Forms.GoogleMaps;
using MapKit;
using Google.Maps;
using MapStyle = Xamarin.Forms.GoogleMaps.MapStyle;
using System;
using System.Collections.Generic;
using System.Linq;

[assembly: ExportRenderer(typeof(MyMapRenderer), typeof(MyMapRendererIos))]
namespace SIIFMOVIL.iOS.Renderer
{
    public class MyMapRendererIos : MapRenderer
    {
        private List<Pin> pins;

        private string Longitude;
        private string Latitude;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                
                MyMapRenderer myMapRenderer = (MyMapRenderer)Element;
                if (myMapRenderer.StaticColor.Equals(Color.FromHex("#212626")))
                {
                    myMapRenderer.MapStyle = MapStyle.FromJson("[{\"featureType\": \"all\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"all\",\"elementType\": \"labels.text.fill\",\"stylers\": [{\"color\": \"#ffffff\"}]},{\"featureType\": \"all\",\"elementType\": \"labels.text.stroke\",\"stylers\": [{\"color\": \"#000000\"},{\"lightness\": 13}]},{\"featureType\": \"administrative\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"administrative\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#144b53\"},{\"lightness\": 14},{\"weight\": 1.4}]},{\"featureType\": \"administrative\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.province\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.locality\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.neighborhood\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"landscape\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#08304b\"}]},{\"featureType\": \"poi\",\"elementType\": \"geometry\",\"stylers\": [{\"color\": \"#0c4152\"},{\"lightness\": 5}]},{\"featureType\": \"poi.attraction\",\"elementType\": \"labels\",\"stylers\": [{\"invert_lightness\": true}]},{\"featureType\": \"poi.attraction\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"poi.park\",\"elementType\": \"labels\",\"stylers\": [{\"visibility\": \"on\"},{\"invert_lightness\": true}]},{\"featureType\": \"poi.park\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#0b434f\"},{\"lightness\": 25}]},{\"featureType\": \"road.highway\",\"elementType\": \"labels\",\"stylers\": [{\"lightness\": \"0\"},{\"saturation\": \"0\"},{\"invert_lightness\": true},{\"visibility\": \"simplified\"},{\"hue\": \"#00e9ff\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.highway.controlled_access\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.arterial\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.arterial\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#0b3d51\"},{\"lightness\": 16}]},{\"featureType\": \"road.arterial\",\"elementType\": \"labels\",\"stylers\": [{\"invert_lightness\": true}]},{\"featureType\": \"road.local\",\"elementType\": \"geometry\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.local\",\"elementType\": \"labels\",\"stylers\": [{\"visibility\": \"simplified\"},{\"invert_lightness\": true}]},{\"featureType\": \"transit\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#146474\"}]},{\"featureType\": \"water\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#021019\"}]}]");
                }
                else
                {
                    myMapRenderer.MapStyle = MapStyle.FromJson("[{\"featureType\": \"administrative.country\",\"elementType\": \"geometry\",\"stylers\": [{\"visibility\": \"simplified\"},{\"hue\": \"#ff0000\"}]}]");
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var formsMap = (MyMapRenderer)Element;
            pins = formsMap.Pins.ToList();

            if (e.PropertyName.Equals(MyMapRenderer.StaticColorProperty.PropertyName))
            {
                MyMapRenderer myMapRenderer = (MyMapRenderer)Element;
                if (myMapRenderer.StaticColor.Equals(Color.FromHex("#061726")))
                {
                    myMapRenderer.MapStyle = MapStyle.FromJson("[{\"featureType\": \"all\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"all\",\"elementType\": \"labels.text.fill\",\"stylers\": [{\"color\": \"#ffffff\"}]},{\"featureType\": \"all\",\"elementType\": \"labels.text.stroke\",\"stylers\": [{\"color\": \"#000000\"},{\"lightness\": 13}]},{\"featureType\": \"administrative\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"administrative\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#144b53\"},{\"lightness\": 14},{\"weight\": 1.4}]},{\"featureType\": \"administrative\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.province\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.locality\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"administrative.neighborhood\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"landscape\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#08304b\"}]},{\"featureType\": \"poi\",\"elementType\": \"geometry\",\"stylers\": [{\"color\": \"#0c4152\"},{\"lightness\": 5}]},{\"featureType\": \"poi.attraction\",\"elementType\": \"labels\",\"stylers\": [{\"invert_lightness\": true}]},{\"featureType\": \"poi.attraction\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"poi.park\",\"elementType\": \"labels\",\"stylers\": [{\"visibility\": \"on\"},{\"invert_lightness\": true}]},{\"featureType\": \"poi.park\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#0b434f\"},{\"lightness\": 25}]},{\"featureType\": \"road.highway\",\"elementType\": \"labels\",\"stylers\": [{\"lightness\": \"0\"},{\"saturation\": \"0\"},{\"invert_lightness\": true},{\"visibility\": \"simplified\"},{\"hue\": \"#00e9ff\"}]},{\"featureType\": \"road.highway\",\"elementType\": \"labels.text\",\"stylers\": [{\"visibility\": \"simplified\"},{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.highway.controlled_access\",\"elementType\": \"labels.text\",\"stylers\": [{\"color\": \"#a1f7ff\"}]},{\"featureType\": \"road.arterial\",\"elementType\": \"geometry.fill\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.arterial\",\"elementType\": \"geometry.stroke\",\"stylers\": [{\"color\": \"#0b3d51\"},{\"lightness\": 16}]},{\"featureType\": \"road.arterial\",\"elementType\": \"labels\",\"stylers\": [{\"invert_lightness\": true}]},{\"featureType\": \"road.local\",\"elementType\": \"geometry\",\"stylers\": [{\"color\": \"#000000\"}]},{\"featureType\": \"road.local\",\"elementType\": \"labels\",\"stylers\": [{\"visibility\": \"simplified\"},{\"invert_lightness\": true}]},{\"featureType\": \"transit\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#146474\"}]},{\"featureType\": \"water\",\"elementType\": \"all\",\"stylers\": [{\"color\": \"#021019\"}]}]");
                }
                else
                {
                    myMapRenderer.MapStyle = MapStyle.FromJson("[{\"featureType\": \"administrative.country\",\"elementType\": \"geometry\",\"stylers\": [{\"visibility\": \"simplified\"},{\"hue\": \"#ff0000\"}]}]");
                }
            }
    
        }

        [Obsolete]
        protected override void OnMarkerCreated(Pin outerItem, Marker innerItem)
        {
            base.OnMarkerCreated(outerItem, innerItem);

            outerItem.Clicked += OnInfoWindowClick;
        }

        void OnInfoWindowClick(object sender, System.EventArgs e)
        {
            Pin pin = (Pin)sender;
            var customPin = GetCustomPin(pin.Position);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }
            /*
            var alert = new UIAlertView(pin.Label, pin.Address, null, "Ver Ruta");
            alert.Dismissed += Alert_Dismissed;

            Latitude = pin.Position.Latitude.ToString();
            Longitude = pin.Position.Longitude.ToString();

            alert.Show();*/

            //Create Alert
            var okCancelAlertController = UIAlertController.Create(pin.Label, pin.Address, UIAlertControllerStyle.Alert);

            //Add Actions
            okCancelAlertController.AddAction(UIAlertAction.Create("Ver Ruta", UIAlertActionStyle.Default, alert => Device.OpenUri(new Uri("http://maps.apple.com/?q=" + pin.Position.Latitude.ToString() + "+" + pin.Position.Longitude.ToString()))));
            okCancelAlertController.AddAction(UIAlertAction.Create("Cerrar", UIAlertActionStyle.Cancel, alert => Console.WriteLine("Cancel was clicked")));

            //Present Alert
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(okCancelAlertController, true, null);

        }

        private void Alert_Dismissed(object sender, UIButtonEventArgs e)
        {
            Device.OpenUri(new Uri("http://maps.apple.com/?q=" + Latitude + "+" + Longitude));
        }

        private Pin GetCustomPin(Xamarin.Forms.GoogleMaps.Position marker)
        {
            return pins.FirstOrDefault(x => x.Position.Latitude == marker.Latitude && x.Position.Longitude == marker.Longitude);
        }
    }
}
