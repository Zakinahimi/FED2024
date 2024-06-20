using SQLite;
using Carworkshop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carworkshop.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Appointment>().Wait();
        }

        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return _database.Table<Appointment>().ToListAsync();
        }

        public Task<int> SaveAppointmentAsync(Appointment appointment)
        {
            if (appointment.Id != 0)
                return _database.UpdateAsync(appointment);
            else
                return _database.InsertAsync(appointment);
        }

        public Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            return _database.DeleteAsync(appointment);
        }
    }
}