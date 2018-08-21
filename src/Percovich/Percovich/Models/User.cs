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
    public class User
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public User()
        {
        }
        public static List<User> sync()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/users";

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                UserRest rootObject = deserial.Deserialize<UserRest>(response);
                return rootObject.data;
            }
            else
            {
                UserRest rootObject = new UserRest();
                return rootObject.data;
            }
        }
    }
    public class UserRest
    {
        public List<User> data { get; set; }
    }
}

    