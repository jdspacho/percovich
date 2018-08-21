using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;

namespace Percovich.Models
{
    public class Tratamiento
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public static List<Tratamiento> local()
        {
            return new List<Tratamiento>() {
                new Tratamiento(){name = "Uno" },
                new Tratamiento(){name = "Dos" },
                new Tratamiento(){name = "Tres" },
                new Tratamiento(){name = "Cuatro" },
                new Tratamiento(){name = "Cinco" },
                new Tratamiento(){name = "Seis" },
                new Tratamiento(){name = "Siete" },
                new Tratamiento(){name = "Ocho" },
            };
        }

        public static List<Tratamiento> sync()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/products";

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                TratamientoRest rootObject = deserial.Deserialize<TratamientoRest>(response);
                return rootObject.data;
            }
            else
            {
                TratamientoRest rootObject = new TratamientoRest();
                return rootObject.data;
            }
        }
    }
    public class TratamientoRest
    {
        public List<Tratamiento> data { get; set; }
    }
}
   
