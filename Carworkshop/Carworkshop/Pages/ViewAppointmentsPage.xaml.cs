using Microsoft.Maui.Controls;
using Carworkshop.Models;
using Carworkshop.Services;
using System;
using System.Linq;
using System.IO;

namespace Carworkshop.Pages
{
    public partial class ViewAppointmentsPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public ViewAppointmentsPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appointments.db3"));
        }

        private async void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            var appointments = await _databaseService.GetAppointmentsAsync();
            var selectedDateAppointments = appointments.Where(a => a.Date.Date == e.NewDate.Date).ToList();
            appointmentsListView.ItemsSource = selectedDateAppointments;
        }
    }
}