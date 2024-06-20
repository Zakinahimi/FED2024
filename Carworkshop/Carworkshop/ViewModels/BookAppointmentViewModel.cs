using Carworkshop.Models;
using Carworkshop.Services;
using System;
using System.IO;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Carworkshop.ViewModels
{
    public class BookAppointmentViewModel : AppointmentViewModel
    {
        private readonly DatabaseService _databaseService;

        public BookAppointmentViewModel()
        {
            _databaseService = new DatabaseService(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
            SaveCommand = new Command(OnSaveAppointment);
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveAppointment()
        {
            var appointment = new Appointment
            {
                CustomerName = CustomerName,
                Address = Address,
                CarBrand = CarBrand,
                CarModel = CarModel,
                LicensePlate = LicensePlate,
                Date = Date,
                TaskDescription = TaskDescription
            };

            await _databaseService.SaveAppointmentAsync(appointment);
            await Application.Current.MainPage.DisplayAlert("Success", "Appointment saved successfully.", "OK");
        }
    }
}