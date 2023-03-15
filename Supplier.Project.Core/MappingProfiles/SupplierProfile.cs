using AutoMapper;
using Supplier.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Core.MappingProfiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            // Forward map
            CreateMap<SupplierDto, Domain.Models.Supplier>();

            // Reverse map
            CreateMap<Domain.Models.Supplier, SupplierDto>();

        }
    }
}
