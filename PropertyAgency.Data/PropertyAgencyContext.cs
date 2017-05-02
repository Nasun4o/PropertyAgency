namespace PropertyAgency.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PropertyAgency.Models.EntityModels;

    public class PropertyAgencyContext : IdentityDbContext<User>
    {
        public PropertyAgencyContext()
            : base("PropertyAgencyContext", throwIfV1Schema:false)
        {
        }

        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Landlord> Landlords { get; set; }
        public virtual DbSet<Property> Properties { get; set; }


        public static PropertyAgencyContext Create()
        {
            return new PropertyAgencyContext();
        }

       
    }
}



