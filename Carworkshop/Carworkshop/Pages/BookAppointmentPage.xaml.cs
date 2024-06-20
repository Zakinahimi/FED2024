using Microsoft.Maui.Controls;
using Carworkshop.Models;
using Carworkshop.Services;
using System;
using System.IO;

namespace Carworkshop.Pages
{
    public partial class BookAppointmentPage : ContentPage
    {
        private readonly DatabaseService _databaseService;
        private Appointment _appointment;

        public BookAppointmentPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
            _appointment = new Appointment();
            BindingContext = _appointment;
        }

        private async void OnSaveAppointmentClicked(object sender, EventArgs e)
        {
            await _databaseService.SaveAppointmentAsync(_appointment);
            await Navigation.PopAsync();
        }
    }
}