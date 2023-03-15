using Microsoft.AspNetCore.Mvc;
using Supplier.Project.Core.Models;
using Supplier.Project.Core.Services;

namespace Supplier.Project.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var suppliers = _supplierService.GetAll();
            return Ok(suppliers);
        }

        [HttpGet("Search")]
        public IActionResult Search(string searchString)
        {
            var suppliers = _supplierService.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = _supplierService.GetSupplierByName(searchString);
                var telephoneResult = filteredResult.Select(n => n.TelephoneNo);
                return Ok(telephoneResult);
            }
            return Ok(suppliers);
        }

        [HttpPost]
        public IActionResult AddSupplier([FromBody] SupplierDto supplierDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _supplierService.Add(supplierDto);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
                throw;
            }
        }
    }
}
