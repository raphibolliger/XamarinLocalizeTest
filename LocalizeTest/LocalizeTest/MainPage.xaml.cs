using System.Globalization;
using Xamarin.Forms;

namespace LocalizeTest
{
    public partial class MainPage : ContentPage
    {
        public string English => LocalizeTest.Resources.Resources.ResourceManager.GetString("Test1", new CultureInfo("en"));
        public string German => LocalizeTest.Resources.Resources.ResourceManager.GetString("Test1", new CultureInfo("de"));
        public string French => LocalizeTest.Resources.Resources.ResourceManager.GetString("Test1", new CultureInfo("fr"));
        public string Italian => LocalizeTest.Resources.Resources.ResourceManager.GetString("Test1", new CultureInfo("it"));
        public string Chinese => LocalizeTest.Resources.Resources.ResourceManager.GetString("Test1", new CultureInfo("zh"));

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
