using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.EntityModels
{
    public class Tenant
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}
