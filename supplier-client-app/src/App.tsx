import React from 'react';
import {Routes,Route,Link} from "react-router-dom"

import './App.css';
import "bootstrap/dist/css/bootstrap.min.css";
import SuppliersList from './components/SuppliersList';
import AddSupplier from './components/AddSupplier';
import Footer from './components/footer';

const App:React.FC=()=> {
  return (
   <div>  
      <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
          <div className="container-fluid">
              <a className="navbar-brand" href="/suppliers">SuppliersApp</a>
              <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                  <span className="navbar-toggler-icon"></span>
              </button>
              <div className="collapse navbar-collapse" id="navbarCollapse">
                  <ul className="navbar-nav mr-auto mb-2 mb-md-0">              
                      <li className="nav-item">
                        <Link to={"/suppliers"} className="nav-link">
                          Suppliers
                        </Link>
                      </li>
                  </ul>
              </div>
          </div>
      </nav>

      <div className="container mt-3 p-5">
        <Routes>
          <Route path="/" element={<SuppliersList/>} />
          <Route path="/suppliers" element={<SuppliersList/>} />
          <Route path="/addSupplier" element={<AddSupplier/>} />
        </Routes>
      </div>
      <Footer/>
   </div>
  );
}

export default App;
