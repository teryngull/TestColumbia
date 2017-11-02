using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

namespace TestColumbia.Droid
{
    [Activity(Label = "TestColumbia.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme",
              MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}