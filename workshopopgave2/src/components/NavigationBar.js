import React from 'react';
import { Link } from 'react-router-dom';
import '../styles/NavigationBar.css';

const NavigationBar = () => {
  return (
    <nav className="navbar">
      <div className="nav-logo">
        <h1>Car Workshop</h1>
      </div>
      <ul>
        <li><Link to="/">Home</Link></li>
        <li><Link to="/book">Book Appointment</Link></li>
        <li><Link to="/edit">Edit Appointment</Link></li>
        <li><Link to="/view">View Appointments</Link></li>
      </ul>
    </nav>
  );
};

export default NavigationBar;
