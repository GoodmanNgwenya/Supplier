import React, { useState, ChangeEvent } from "react";
import { useNavigate } from "react-router-dom";
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from 'yup';
import SupplierDataService from "../services/SupplierService";
import ISupplierData from '../types/Supplier';

const AddSupplier: React.FC = () => {
  const [submitted, setSubmitted] = useState<boolean>(false);

  const validationSchema = Yup.object().shape({
    code: Yup.string().required('Code is required'),
    name: Yup.string()
      .required('Company Name is required'),
      telephoneNo: Yup.string()
      .required('Telephone Number is required'),
  });

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors }
  } = useForm<ISupplierData>({
    resolver: yupResolver(validationSchema)
  });

  const onSubmit = (data: ISupplierData) => {
    console.log(JSON.stringify(data, null, 2));
    
    SupplierDataService.create(data)
    .then((response: any) => {
      setSubmitted(true);
      console.log(response.data);
    })
    .catch((e: Error) => {
      console.log(e);
    });
  };

  const newSupplier = () => {
    setSubmitted(false);
  };
  const navigate = useNavigate();

    const navigateToSuppliers = () => {
      navigate('/suppliers');
    };

  return (
    <div className="submit-form col-md-6 p-5 mt-5 border">
      <form onSubmit={handleSubmit(onSubmit)}>
      {submitted ? (
        <div>
          <h4>You submitted successfully!</h4>
          <button className="btn btn-success" onClick={newSupplier}>
            Add
          </button>
        </div>
      ) : (
        <div>
        <div className="form-group">
          <label>Code</label>
          <input
            type="text"
            {...register('code')}
            className={`form-control ${errors.code ? 'is-invalid' : ''}`}
          />
          <div className="invalid-feedback">{errors.code?.message}</div>
        </div>

        <div className="form-group">
          <label>Company Name</label>
          <input
            type="text"
            {...register('name')}
            className={`form-control ${errors.name ? 'is-invalid' : ''}`}
          />
          <div className="invalid-feedback">{errors.name?.message}</div>
        </div>

        <div className="form-group">
          <label>Telephone Number</label>
          <input
            type="text"
            {...register('telephoneNo')}
            className={`form-control ${errors.telephoneNo ? 'is-invalid' : ''}`}
          />
          <div className="invalid-feedback">{errors.telephoneNo?.message}</div>
        </div>

        <div className="form-group">
          <button type="submit" className="btn btn-primary">
            Register
          </button>
          <button
            type="button"
            onClick={() => reset()}
            className="btn btn-warning float-right"
          >
            Reset
          </button>
        </div>
        <div className="text-center">
        <a onClick={navigateToSuppliers} className="justify-content-center">Back to suppliers</a>
      </div>
        </div>)}
      </form>
    </div>
  );
};

export default AddSupplier;