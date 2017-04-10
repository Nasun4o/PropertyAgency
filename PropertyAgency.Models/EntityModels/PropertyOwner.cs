using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Models.EntityModels
{
    public class PropertyOwner
    {
        public PropertyOwner()
        {
            this.Properties = new List<Property>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public bool IsAcceptingAnimals { get; set; }

    }
}
