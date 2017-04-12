namespace PropertyAgency.Services
{
    using PropertyAgency.Data;

    public abstract class Service
    {
       protected Service()
        {
            this.Context = Data.Context;
        }
        public PropertyAgencyContext Context { get; set; }
    }
}
