using AutoMapper;
using Microsoft.Extensions.Logging;
using Supplier.Project.Core.Models;
using Supplier.Project.Persistence.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<SupplierService> _logger;
        public SupplierService(ISupplierRepository supplierRepo, IMapper mapper, ILogger<SupplierService> logger)
        {
            _supplierRepo = supplierRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public void Add(SupplierDto supplierDto)
        {
            try
            {
                var supplier=_mapper.Map<Domain.Models.Supplier>(supplierDto);
                _supplierRepo.AddSupplier(supplier);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(SupplierService)}.{nameof(Add)}]: Something went wrong while trying to save [{nameof(SupplierDto)}] to the database.[{exception.Message}]", exception);
                throw;
            }
        }

        public List<SupplierDto> GetAll()
        {
            try
            {
                var suppliers=_supplierRepo.GetAll();
                return _mapper.Map<List<SupplierDto>>(suppliers);
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(SupplierService)}.{nameof(GetAll)}]: Something went wrong while trying to retrieve [{nameof(SupplierDto)}] from database.[{exception.Message}]", exception);
                throw;
            }
        }

        public List<SupplierDto> GetSupplierByName(string name)
        {
            try
            {
                var suppliers = _supplierRepo.GetAll();
               return suppliers.Select(n => _mapper.Map<SupplierDto>(n)).Where(s => s.Name == name).ToList(); 
            }
            catch (Exception exception)
            {
                _logger.LogError($"[{nameof(SupplierService)}.{nameof(GetSupplierByName)}]: Something went wrong while trying to retrieve [{nameof(SupplierDto)}] from database.[{exception.Message}]", exception);
                throw;
            }
        }

    }
}
