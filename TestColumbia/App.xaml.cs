using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TestColumbia
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TestColumbiaPage();
        }

        protected override void OnStart()
        {
			AppCenter.Start("ios=36fe1047-0a50-405c-a15e-560351ba5397;" + "android=d34b422f-6a18-4214-9b97-8fff2725cf8b;",
				typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
