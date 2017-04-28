using System.Collections.Generic;

namespace PropertyAgency.Models.EntityModels
{
    public class Landlord
    {
        public Landlord()
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
