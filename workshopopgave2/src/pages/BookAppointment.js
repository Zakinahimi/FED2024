import React, { useState } from 'react';
import '../styles/BookingAppointment.css'

const BookAppointment = () => {
  const [formData, setFormData] = useState({
    customerName: '',
    address: '',
    carBrand: '',
    carModel: '',
    licensePlate: '',
    date: '',
    taskDescription: ''
  });

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetch('http://localhost:3000/appointments', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(formData)
    })
      .then(response => response.json())
      .then(data => alert('Appointment booked successfully!'))
      .catch(error => console.error('Error:', error));
  };

  return (
    <div className="book-appointment">
      <h1>Book a New Appointment</h1>
      <form onSubmit={handleSubmit}>
        {Object.keys(formData).map((key) => (
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
        ))}
        <button type="submit">Book Appointment</button>
      </form>
    </div>
  );
};

export default BookAppointment;
