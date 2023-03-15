using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Supplier.Project.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Supplier.Project.Persistence.Seed
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Supplier
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Domain.Models.Supplier>()
                    {
                        new Domain.Models.Supplier()
                        {
                            Code= 234,Name="Eskom Holdings Limited",TelephoneNo="086 0037566"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=939,Name="Focus Rooms (Pty) Ltd",TelephoneNo="0820776910"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=34,Name="GSM Electro",TelephoneNo= "0128110069"
                        },
                        new Domain.Models.Supplier()
                        {
                             Code=1264,Name="Jody and Herman Investments CC",TelephoneNo="0118864227",
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=5667,Name="Johan Le Roux Ingenieurswerke",TelephoneNo="0233423390"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=667,Name="L. J. Ross t/a Petite Cafe'",TelephoneNo="0117868101"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=45,Name="L.A Auto Center  CC t/a LA Body Works",TelephoneNo="0219488412"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=1351,Name="LG Tow-In CC",TelephoneNo="0828044026"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=1352,Name="LM Greyling t/aThe Electric Advertiser",TelephoneNo="0119545972"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=1437,Name="M.H Cloete Enterprises (Pty) Ltd  t/a  Rola Motors",TelephoneNo="0218418300"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=67,Name="M.M Hydraulics CC",TelephoneNo="0114256578"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=1980,Name="Phulo Human Capital (Pty) Ltd",TelephoneNo="0114755934"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=345,Name="Picaro 115 CC t/a H2O CT Services",TelephoneNo="0216745710"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=2279,Name="Safetygrip CC",TelephoneNo="0117086660"
                        },

                        new Domain.Models.Supplier()
                        {
                            Code=876,Name="Safic (Pty) Ltd",TelephoneNo="0114064000"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=2549,Name="The Financial Planning Institute Of Southern Africa",TelephoneNo="0861000374"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=935,Name="The Fitment Zone  CC",TelephoneNo="0118234181"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=2693,Name="Turnweld Engineering CC",TelephoneNo="0115468790"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=6,Name="Tutuka Motor Holdings Pty Ltd t/a Tutuka Motor Lab",TelephoneNo="0117044324"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=134,Name="WP Exhaust Brake & Clutch t/a In Focus Fleet Services",TelephoneNo="0219055028"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=3277,Name="WP Sekuriteit",TelephoneNo="0233421732"
                        },
                        new Domain.Models.Supplier()
                        {
                            Code=53,Name="Brietta Trading (Pty) Ltd",TelephoneNo="0115526000"
                        },

                        new Domain.Models.Supplier()
                        {
                            Code=392 ,Name="C.N. Braam t/a CNB Electrical Services",TelephoneNo="0832835399"
                        },

                        new Domain.Models.Supplier()
                        {
                            Code=625 ,Name="Creative Crew (Pty) Ltd",TelephoneNo="0120040218"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
