using Microsoft.Maui.Controls;

namespace Carworkshop.Pages
{
    public partial class BookAppointmentPage : ContentPage
    {
        public BookAppointmentPage()
        {
            InitializeComponent();
            BindingContext = new Carworkshop.ViewModels.BookAppointmentViewModel();
        }
    }
}