using Microsoft.Maui.Controls;
using Carworkshop.Pages;

namespace Carworkshop
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBookAppointmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookAppointmentPage());
        }

        private async void OnViewAppointmentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAppointmentsPage());
        }

        private async void OnSpecifyWorkClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SpecifyWorkPage());
        }
    }
}