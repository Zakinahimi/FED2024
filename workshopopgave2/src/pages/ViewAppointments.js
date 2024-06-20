import React, { useState } from 'react';
import '../styles/ViewAppointments.css';

const ViewAppointments = () => {
  const [date, setDate] = useState('');
  const [appointments, setAppointments] = useState([]);

  const handleSearch = () => {
    fetch(`http://localhost:3000/appointments?date=${date}`)
      .then(response => response.json())
      .then(data => setAppointments(data))
      .catch(error => console.error('Error:', error));
  };

  return (
    <div className="view-appointments">
      <h1>View Appointments</h1>
      <div className="search-bar">
        <input
          type="date"
          value={date}
          onChange={(e) => setDate(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <ul>
        {appointments.map((appointment) => (
          <li key={appointment.id}>
            <span>Customer Name:</span> {appointment.customerName} <br />
            <span>Car Model:</span> {appointment.carModel} <br />
            <span>Date:</span> {appointment.date}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ViewAppointments;
