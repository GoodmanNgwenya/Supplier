using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Persistence.Repositories
{
    public interface ISupplierRepository
    {
        void AddSupplier(Domain.Models.Supplier supplier);
        List<Domain.Models.Supplier> GetAll();
    }
}
