﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // New code will go here
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            // Add code to translate number
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                }
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}