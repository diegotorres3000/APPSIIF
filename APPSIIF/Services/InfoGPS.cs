using System;
using System.Threading.Tasks;
using Plugin.Geolocator;

using APPSIIF.Models;

namespace APPSIIF.Services
{
    /**
     * clase que permite verificar el gps
     * y obternes las coordenadas
     */
    class InfoGPS
    {
        //POST DE USUARIO
        public static async Task<ResponseGPS> InformacionGPS()
        {
            try
            {
                var locator = CrossGeolocator.Current; // Devuelve un IGeolocator
                locator.DesiredAccuracy = 50;
                if (locator.IsGeolocationAvailable)// Devuelve si el servicio existe en el dispositivo
                {
                    if (locator.IsGeolocationEnabled)//Devuelve si el GPS esta activado
                    {
                        if (!locator.IsListening)//Comprueba si el dispositivo esta actualmente escuchando al servicio
                        {
                            await locator.StartListeningAsync(TimeSpan.FromMilliseconds(5), 3000); //Inicio escucha
                        }
                        var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                        return new ResponseGPS
                        {
                            Latitude = position.Latitude.ToString(),
                            Longitude = position.Longitude.ToString(),
                        };
                    }
                    else
                    {
                        return new ResponseGPS
                        {
                            Message = "Se necesita Activar la ubicación",
                        };
                    }
                }
                else
                {
                    return new ResponseGPS
                    {
                        Message = "El servicio de GPS no existe en el dispositivo",
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseGPS
                {
                    Message = ex.Message,
                };
            }
        }
    }
}
