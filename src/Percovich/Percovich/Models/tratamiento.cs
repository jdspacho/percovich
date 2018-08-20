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
    class tratamiento
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public static List<tratamiento> local()
        {
            return new List<tratamiento>() {
                new tratamiento(){name = "Uno" },
                new tratamiento(){name = "Dos" },
                new tratamiento(){name = "Tres" },
                new tratamiento(){name = "Cuatro" },
                new tratamiento(){name = "Cinco" },
                new tratamiento(){name = "Seis" },
                new tratamiento(){name = "Siete" },
                new tratamiento(){name = "Ocho" },
            };
        }

        public static List<tratamiento> sync()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/products";

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                ProductRest rootObject = deserial.Deserialize<ProductRest>(response);
                return rootObject.data;
            }
            else
            {
                ProductRest rootObject = new ProductRest();
                return rootObject.data;
            }
        }
    }
    public class ProductRest
    {
        public List<tratamiento> data { get; set; }
    }
}
    }
}