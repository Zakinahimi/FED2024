using Carworkshop.Models;
using Carworkshop.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel; 
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Carworkshop.ViewModels
{
    public class ViewAppointmentsViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private DateTime _selectedDate;

        public ViewAppointmentsViewModel()
        {
            _databaseService = new DatabaseService(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
            Appointments = new ObservableCollection<Appointment>();
            DateSelectedCommand = new Command(OnDateSelected);
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                OnDateSelected();
            }
        }

        public ObservableCollection<Appointment> Appointments { get; }

        public ICommand DateSelectedCommand { get; }

        private async void OnDateSelected()
        {
            var appointments = await _databaseService.GetAppointmentsAsync();
            var selectedDateAppointments = appointments.Where(a => a.Date.Date == SelectedDate.Date).ToList();

            Appointments.Clear();
            foreach (var appointment in selectedDateAppointments)
            {
                Appointments.Add(appointment);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}