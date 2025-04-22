using ImcMauiApp.Mvvm.Views;

namespace ImcMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ImcView());// new AppShell();
        }
    }
}