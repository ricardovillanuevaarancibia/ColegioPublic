using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ColegioPublic.Helper
{
    public static class SendImage
    {
        public static string ConvertToBase64(Stream stream)
        {

            String urlImage = "";
            byte[] data;
            using (Stream inputStream = stream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            var datosConvert = Convert.ToBase64String(data);

            try
            {
                var client = new RestClient("https://api.imgbb.com/1/upload?key=288273875e1c26c1b054e73c8cee3a2d");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "multipart/form-data");
                request.AlwaysMultipartFormData = true;
                request.AddParameter("image", datosConvert, "multipart/form-data", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                Console.WriteLine(response.Content);
                JObject rss = JObject.Parse(response.Content);
            
                urlImage = (string)rss["data"]["medium"]["url"];
            }
            catch (Exception ex)
            {
                urlImage = "";
            }
            finally
            {

            }
            return urlImage;
        }

        public static string EnviarWhatsap(string numero)
        {
            string yourId = "ccpRDrqqpESNkn/w/i2cDHJpY2FyZG92aWxsYW51ZXZhYXJhbmNpYmlhX2F0X2dtYWlsX2RvdF9jb20=";
            string yourMobile = "+51"+numero;
            string yourMessage = "Esto es un mensaje de prueba";
            try
            {
                string url = "https://NiceApi.net/API";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-APIId", yourId);
                request.Headers.Add("X-APIMobile", yourMobile);
                using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream()))
                {
                    streamOut.Write(yourMessage);
                }
                using (StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    Console.WriteLine(streamIn.ReadToEnd());
                }
            }
            catch (SystemException se)
            {
                return "";
            }
            return "";
        }







    }
}