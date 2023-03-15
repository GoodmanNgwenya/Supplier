import { useNavigate } from "react-router-dom";
import React, { useState, useEffect, ChangeEvent } from "react";
import SupplierDataService from "../services/SupplierService";
import ISupplierData from '../types/Supplier';

const SuppliersList: React.FC = () => {
  const [Suppliers, setSuppliers] = useState<Array<ISupplierData>>([]);
  const [searchName, setSearchName] = useState<string>("");

  useEffect(() => {
    retrieveSuppliers();
  }, []);

  const onChangeSearchName = (e: ChangeEvent<HTMLInputElement>) => {
    const searchSupplier = e.target.value;
    setSearchName(searchSupplier);
  };

  const retrieveSuppliers = () => {
    SupplierDataService.getAll()
      .then((response: any) => {
        setSuppliers(response.data);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };

  const navigate = useNavigate();

    const navigateToAddSupplier = () => {
      // 👇️ navigate to /AddSupplier
      navigate('/addSupplier');
    };

  return (
    <div className="justify-content-center p-5">
      <div className="row">
      <div className="col-md-6">
        <div className="input-group mb-4">
          <input
            type="text"
            className="form-control"
            placeholder="Search by company name"
            value={searchName}
            onChange={onChangeSearchName}
          />
        </div>
      </div>
      <div className="col-md-6 text-right">
        <button onClick={navigateToAddSupplier} className="btn btn-primary">
            Add Supplier
          </button>
      </div>
      </div>
      <div className="col-md-12">
        <h2>Suppliers List</h2>
             <table className="table">
                {searchName==='' ?
                <thead className="thead-dark">
                    <tr>
                    <th scope="col">Code</th>
                    <th scope="col">Name</th>
                    <th scope="col">Telephone No</th>
                    </tr>
                </thead>:<thead className="thead-dark">
                    <tr>
                    <th scope="col">Telephone No</th>
                    </tr>
                </thead>}
                {Suppliers.filter(Supplier=>{
                    if(searchName===''){
                        return Supplier
                    }else if(Supplier.name.toLocaleLowerCase().includes(searchName.toLocaleLowerCase())){
                        return Supplier
                    }
                }).map((Supplier, index) => {
                    return (
                searchName===''?
                <tbody>
                    <tr key={index}>
                      <td>{Supplier.code}</td>
                      <td>{Supplier.name}</td>
                      <td>{Supplier.telephoneNo}</td>
                    </tr>
                </tbody>:
                    <tbody>
                    <tr key={index}>
                      <td>{Supplier.telephoneNo}</td>
                    </tr>
                </tbody>
                )})}
            </table>

      </div>
    </div>
  );
};

export default SuppliersList;