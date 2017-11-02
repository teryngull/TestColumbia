using Xamarin.Forms;

namespace TestColumbia
{
    public partial class TestColumbiaPage : ContentPage
    {
        public TestColumbiaPage()
        {
            InitializeComponent();
            BindingContext = new TestColumbiaViewModel();
        }
    }
}