import React, { Component } from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import OldApp from './Components/OldApp';
import Registration from './Components/Registration';

export default function App() {

    return (
      <div>
        
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<OldApp />} />
          <Route path="/login" element={<Registration />} />
        </Routes>
      </BrowserRouter>
      
      </div>
    );
}
