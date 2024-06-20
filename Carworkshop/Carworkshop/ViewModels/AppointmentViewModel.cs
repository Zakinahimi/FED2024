using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carworkshop.ViewModels
{
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        private string _customerName = string.Empty;
        private string _address = string.Empty;
        private string _carBrand = string.Empty;
        private string _carModel = string.Empty;
        private string _licensePlate = string.Empty;
        private DateTime _date = DateTime.Now;
        private string _taskDescription = string.Empty;
        private string _mechanicName = string.Empty;
        private string _materialsUsed = string.Empty;
        private decimal _materialsCost = 0;
        private int _hoursWorked = 0;
        private decimal _hourlyRate = 0;

        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public string CarBrand
        {
            get => _carBrand;
            set => SetProperty(ref _carBrand, value);
        }

        public string CarModel
        {
            get => _carModel;
            set => SetProperty(ref _carModel, value);
        }

        public string LicensePlate
        {
            get => _licensePlate;
            set => SetProperty(ref _licensePlate, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public string TaskDescription
        {
            get => _taskDescription;
            set => SetProperty(ref _taskDescription, value);
        }

        public string MechanicName
        {
            get => _mechanicName;
            set => SetProperty(ref _mechanicName, value);
        }

        public string MaterialsUsed
        {
            get => _materialsUsed;
            set => SetProperty(ref _materialsUsed, value);
        }

        public decimal MaterialsCost
        {
            get => _materialsCost;
            set => SetProperty(ref _materialsCost, value);
        }

        public int HoursWorked
        {
            get => _hoursWorked;
            set => SetProperty(ref _hoursWorked, value);
        }

        public decimal HourlyRate
        {
            get => _hourlyRate;
            set => SetProperty(ref _hourlyRate, value);
        }

        public decimal TotalCost => MaterialsCost + (HoursWorked * HourlyRate);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(storage, value))
            {
                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
