using Android.App;
using Android.Content.PM;
using Android.OS;

namespace PruebaXamarinJuanAvila.Droid
{
    [Activity(Label = "SplashActivity",
        Theme = "@style/MainTheme.Splash",
        MainLauncher = true,
        NoHistory = true,
        ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}