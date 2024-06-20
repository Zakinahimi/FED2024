using SQLite;
using System;

namespace Carworkshop.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string CarBrand { get; set; } = string.Empty;
        public string CarModel { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string TaskDescription { get; set; } = string.Empty;
        public string MechanicName { get; set; } = string.Empty;
        public string MaterialsUsed { get; set; } = string.Empty;
        public decimal MaterialsCost { get; set; } = 0;
        public int HoursWorked { get; set; } = 0;
        public decimal HourlyRate { get; set; } = 0;

        [Ignore]
        public decimal TotalCost => MaterialsCost + (HoursWorked * HourlyRate);
    }
}  