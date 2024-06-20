using Carworkshop.Models;
using Carworkshop.Services;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Carworkshop.ViewModels
{
    public class SpecifyWorkViewModel : AppointmentViewModel
    {
        private readonly DatabaseService _databaseService;
        private string _searchTerm;
        private bool _isAppointmentFound;

        public SpecifyWorkViewModel()
        {
            _databaseService = new DatabaseService(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
            SearchCommand = new Command(OnSearchAppointment);
            SaveCommand = new Command(OnSaveAppointment);
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public bool IsAppointmentFound
        {
            get => _isAppointmentFound;
            set => SetProperty(ref _isAppointmentFound, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand SaveCommand { get; }

        private async void OnSearchAppointment()
        {
            var appointments = await _databaseService.GetAppointmentsAsync();
            var appointment = appointments.FirstOrDefault(a => a.LicensePlate == SearchTerm);

            if (appointment != null)
            {
                CustomerName = appointment.CustomerName;
                Address = appointment.Address;
                CarBrand = appointment.CarBrand;
                CarModel = appointment.CarModel;
                LicensePlate = appointment.LicensePlate;
                Date = appointment.Date;
                Time = appointment.Time;
                TaskDescription = appointment.TaskDescription;
                MechanicName = appointment.MechanicName;
                MaterialsUsed = appointment.MaterialsUsed;
                MaterialsCost = appointment.MaterialsCost;
                HoursWorked = appointment.HoursWorked;
                HourlyRate = appointment.HourlyRate;

                IsAppointmentFound = true;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Not Found", "No appointment found for the provided license plate.", "OK");
                IsAppointmentFound = false;
            }
        }

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
                Time = Time,
                TaskDescription = TaskDescription,
                MechanicName = MechanicName,
                MaterialsUsed = MaterialsUsed,
                MaterialsCost = MaterialsCost,
                HoursWorked = HoursWorked,
                HourlyRate = HourlyRate
            };

            await _databaseService.SaveAppointmentAsync(appointment);
            await Application.Current.MainPage.DisplayAlert("Success", "Work details saved successfully.", "OK");
        }
    }
}
