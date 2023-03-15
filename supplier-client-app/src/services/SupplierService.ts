import http from "../http-common";
import ISupplierData from "../types/Supplier";

const getAll=()=>{
    return http.get<Array<ISupplierData>>("suppliers")
}
  
  const create = (data: ISupplierData) => {
    return http.post<ISupplierData>("/suppliers", data);
  };
  const findByName = (searchString: string) => {
    return http.get<Array<ISupplierData>>(`/suppliers/Search?searchString=${searchString}`);
  };

  const SupplierService={
    getAll,
    create,
    findByName
  };

  export default SupplierService;