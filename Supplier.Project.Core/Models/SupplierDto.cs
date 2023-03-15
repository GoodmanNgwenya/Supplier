using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Supplier.Project.Core.Models
{
    public class SupplierDto
    {
        public int Id { get; set; }
        [Display(Name = "Code")]
        [Required(ErrorMessage = "Code is required")]
        public int Code { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string Name { get; set; }
        [Display(Name = "Telephone Number")]
        [Required(ErrorMessage = "Telephone Number is required")]
        public string TelephoneNo { get; set; }
    }
}
