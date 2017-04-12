namespace PropertyAgency.Models.EntityModels
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.Tenants = new HashSet<Tenant>();
            this.Properties = new HashSet<Property>();
            this.PropertyOwners = new HashSet<Landlord>();

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public virtual ICollection<Tenant> Tenants { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Landlord> PropertyOwners { get; set; }

    }
}
