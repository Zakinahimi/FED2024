using Microsoft.Maui.Controls;
using Carworkshop.Models;
using Carworkshop.Services;
using System;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carworkshop.Pages
{
    public partial class SpecifyWorkPage : ContentPage, INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private Appointment _appointment;

        private string _searchTerm;
        private bool _isAppointmentFound;

        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                OnPropertyChanged();
            }
        }

        public bool IsAppointmentFound
        {
            get => _isAppointmentFound;
            set
            {
                _isAppointmentFound = value;
                OnPropertyChanged();
            }
        }

        public SpecifyWorkPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
            BindingContext = this;
            IsAppointmentFound = false;
        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            var appointments = await _databaseService.GetAppointmentsAsync();
            _appointment = appointments.FirstOrDefault(a => a.LicensePlate == SearchTerm);
            if (_appointment != null)
            {
                BindingContext = _appointment;
                IsAppointmentFound = true;
            }
            else
            {
                await DisplayAlert("Not Found", "No appointment found for the provided license plate.", "OK");
                IsAppointmentFound = false;
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            await _databaseService.SaveAppointmentAsync(_appointment);
            await DisplayAlert("Success", "Work details saved successfully.", "OK");
        }

        public new event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
