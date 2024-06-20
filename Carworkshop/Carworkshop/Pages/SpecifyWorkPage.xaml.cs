using Microsoft.Maui.Controls;

namespace Carworkshop.Pages
{
    public partial class SpecifyWorkPage : ContentPage
    {
        public SpecifyWorkPage()
        {
            InitializeComponent();
            BindingContext = new Carworkshop.ViewModels.SpecifyWorkViewModel();
        }
    }
}