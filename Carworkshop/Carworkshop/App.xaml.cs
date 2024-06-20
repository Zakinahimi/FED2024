using Microsoft.Maui.Controls;
using Carworkshop.Pages;

namespace Carworkshop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}