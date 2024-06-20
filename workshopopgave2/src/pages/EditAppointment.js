import React, { useState } from 'react';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import '../styles/EditAppointment.css';

const EditAppointment = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [appointment, setAppointment] = useState(null);
  const [formData, setFormData] = useState({});

  const handleSearch = () => {
    fetch(`http://localhost:3000/appointments?licensePlate=${searchTerm}`)
      .then(response => response.json())
      .then(data => {
        if (data.length) {
          setAppointment(data[0]);
          setFormData({ ...data[0], date: new Date(data[0].date) });
        } else {
          alert('No appointment found.');
        }
      })
      .catch(error => console.error('Error:', error));
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleDateChange = (date) => {
    setFormData({
      ...formData,
      date: date
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch(`http://localhost:3000/appointments/${appointment.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ ...formData, date: formData.date.toISOString().split('T')[0] })
    })
      .then(response => response.json())
      .then(data => alert('Appointment updated successfully!'))
      .catch(error => console.error('Error:', error));
  };

  return (
    <div className="edit-appointment">
      <h1>Edit Appointment</h1>
      <div className="search-bar">
        <input
          type="text"
          placeholder="Search by license plate"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      {appointment && (
        <form onSubmit={handleSubmit}>
          {Object.keys(formData).map((key) => (
            key !== 'date' ? (
              <div key={key} className="form-group">
                <label>{key.charAt(0).toUpperCase() + key.slice(1)}</label>
                <input
                  type="text"
                  name={key}
                  value={formData[key]}
                  onChange={handleChange}
                  required
                />
              </div>
            ) : (
              <div key={key} className="form-group">
                <label>Date</label>
                <DatePicker
                  selected={formData.date}
                  onChange={handleDateChange}
                  dateFormat="yyyy-MM-dd"
                  className="date-picker"
                />
              </div>
            )
          ))}
          <button type="submit">Update Appointment</button>
        </form>
      )}
    </div>
  );
};

export default EditAppointment;
