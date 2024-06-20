import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import NavigationBar from './components/NavigationBar';
import Home from './pages/Home';
import BookAppointment from './pages/BookAppointment';
import EditAppointment from './pages/EditAppointment';
import ViewAppointments from './pages/ViewAppointments';

const App = () => {
  return (
    <Router>
      <div className="container">
        <NavigationBar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/book" element={<BookAppointment />} />
          <Route path="/edit" element={<EditAppointment />} />
          <Route path="/view" element={<ViewAppointments />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
