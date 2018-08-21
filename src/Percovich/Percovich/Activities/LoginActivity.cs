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

namespace Percovich.Activities
{
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme.GeneralForm", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        Button btnLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            btnLogin = FindViewById<Button>(Resource.Id.bottom);
            btnLogin.Click += doLogin;

            // Create your application here
        }
        private void doLogin(object sender, EventArgs o)
        {
            bool valid = true;
            if (valid)
            {
                Intent newActivity = new Intent(this, typeof(MainActivity));
                this.StartActivity(newActivity);
            }
            else
            {

            }
        }
    } }

