using System;
using System.Globalization;
using System.Resources;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace LocalizeTest.Droid
{
    [Activity(Label = "LocalizeTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            var resourceNames = typeof(Resources.Resources).Assembly.GetManifestResourceNames();
            Console.WriteLine("### RESOURCE NAME ### | Found [{resourceNames.Length}] resource names.");
            foreach (var name in resourceNames)
            {
                Console.WriteLine($"### RESOURCE NAME ### | : {name}");
            }

            ResourceManager rm = new ResourceManager("LocalizeTest.Resources.Resources", typeof(Resources.Resources).Assembly);

            string unsupportedLanguages = "";

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                try
                {
                    var translatedString = rm.GetString("Test1", culture);
                    Console.WriteLine($"### LANGUAGES ### | {culture.DisplayName} is supported | String: {translatedString}");
                }
                catch (Exception)
                {
                    unsupportedLanguages += $"[{culture.TwoLetterISOLanguageName}] ";
                }
            }

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}