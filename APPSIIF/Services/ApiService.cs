using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using APPSIIF.Helpers;
using APPSIIF.Views;
using APPSIIF.Models.Api;
using System.Linq;

using Xamarin.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Web;

namespace APPSIIF.Services
{
    /**
     * clase que permite la conexion con la API
     */
    public class ApiService //COMUNICACION CON LOS APIS
    {
        //.30 = https://app.sistemasgyg.com.co/
        //PRUEBAS = https://presentacion.sistemasgyg.com.co/
        public static string URL = "https://app.sistemasgyg.com.co/";

        //CONSUMIR A APIS SIN TOKEN 
        public async Task<Response> GetList<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", Settings.RefreshToken);
                client.DefaultRequestHeaders.Add("CDI", Settings.RegisterCode);
                client.DefaultRequestHeaders.Add("COD", Settings.Code.ToString());
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller); //ARMA LA URL
                var response = await client.GetAsync(url); //EJECUTA LA CONSULTA
                var result = await response.Content.ReadAsStringAsync();
                //response.Headers.WwwAuthenticate.
                if (!response.IsSuccessStatusCode)// SINO LLEGA 200 O RESPUESTA CORRECTA
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                var List = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok"
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        //GET
        public static async Task<Response> ConsumoGET(string urlBase, string servicePrefix, Dictionary<string, string> parameters)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;
            string IP = GetIpAdress();

            try
            {
                if (!CrossConnectivity.Current.IsConnected)//Verifica si hay Internet
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Configuración del Internet.",
                    };
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
                if (!isReachable)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Conexión del Internet.",
                    };
                }

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", Settings.RefreshToken);
                client.DefaultRequestHeaders.Add("IP", IP);
                //client.BaseAddress = new Uri(urlBase);
                //var url = servicePrefix;

                var builder = new UriBuilder(urlBase + servicePrefix);
                var query = HttpUtility.ParseQueryString(builder.Query);
                foreach (KeyValuePair<string, string> entry in parameters)
                {
                    query[entry.Key] = entry.Value;
                }
                builder.Query = query.ToString();
                string url = builder.ToString();

                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        //POST
        public static async Task<Response> ConsumoPOST(string urlBase, string servicePrefix, StringContent content)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3;
            string IP = GetIpAdress();

            try
            {
                if (!CrossConnectivity.Current.IsConnected)//Verifica si hay Internet
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Configuración del Internet.",
                    };
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
                if (!isReachable)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Conexión del Internet.",
                    };
                }

                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.JwtToken);
                client.DefaultRequestHeaders.Add("IP", IP);
                client.BaseAddress = new Uri(urlBase);

                var url = servicePrefix;

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                //IEnumerable<string> authzHeaders;
                //response.Headers.TryGetValues("Token", out authzHeaders);
                //if (authzHeaders != null)
                //{
                //    string token_ = authzHeaders.ElementAt(0);
                //    token_ = token_.StartsWith("Token ") ? token_.Substring(6) : token_;
                //    Settings.RefreshToken = token_;
                //}

                //if (!response.IsSuccessStatusCode)
                //{
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.ReasonPhrase,
                        Code = (int)response.StatusCode,
                        Result = result
                    };
                //}

                //Application.Current.MainPage = new LoginView();

                //return new Response
                //{
                //    IsSuccess = true,
                //    Message = "Ok",
                //    Result = result,
                //};
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        //PUT
        public static async Task<Response> ConsumoPUT(string urlBase, string servicePrefix, StringContent content)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)//Verifica si hay Internet
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Configuración del Internet.",
                    };
                }

                var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
                if (!isReachable)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Por favor verificar la Conexión del Internet.",
                    };
                }

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("CDI", Settings.RegisterCode);
                client.DefaultRequestHeaders.Add("COD", Settings.Code.ToString());
                client.BaseAddress = new Uri(urlBase);
                var url = servicePrefix;
                var response = await client.PutAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public static string GetIpAdress()
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return addrInfo.Address.ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}
