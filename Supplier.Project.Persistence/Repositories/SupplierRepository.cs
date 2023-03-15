using Microsoft.Extensions.Logging;
using Supplier.Project.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SupplierRepository> _logger;
        public SupplierRepository(AppDbContext context,ILogger<SupplierRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddSupplier(Domain.Models.Supplier supplier)
        {
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {

                _logger.LogError($"[{nameof(SupplierRepository)}.{nameof(AddSupplier)}]: Something went wrong while trying to save [{nameof(Domain.Models.Supplier)}] to the database.[{exception.Message}]", exception);
                throw;
            }
        }

        public List<Domain.Models.Supplier> GetAll()
        {
            try
            {
                return _context.Suppliers.ToList();
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(SupplierRepository)}.{nameof(GetAll)}]: Something went wrong while trying to retrieve [{nameof(Domain.Models.Supplier)}] from database.[{exception.Message}]", exception);
                throw;
            }
        }
    }
}
