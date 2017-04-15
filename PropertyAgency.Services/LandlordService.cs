namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;

    public class LandlordService : Service
    {
        public void AddLandlord(LandlordsBindingModel landlordBindingModel)
        {
            Landlord landlord = Mapper.Map<Landlord>(landlordBindingModel);
            this.Context.Landlords.Add(landlord);
            this.Context.SaveChanges();
        }

    }
}
