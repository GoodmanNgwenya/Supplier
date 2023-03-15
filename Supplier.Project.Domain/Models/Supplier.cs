using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Domain.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string TelephoneNo { get; set; }
    }
}
