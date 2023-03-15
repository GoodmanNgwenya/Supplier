using Supplier.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Core.Services
{
    public interface ISupplierService
    {
        void Add(SupplierDto supplierDto);
        List<SupplierDto> GetAll();
        List<SupplierDto> GetSupplierByName(string name);
    }
}
