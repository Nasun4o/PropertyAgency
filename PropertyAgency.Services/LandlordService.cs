namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using System.Collections.Generic;

    public class LandlordService : Service
    {
        public void AddLandlord(LandlordsBindingModel landlordBindingModel)
        {
            Landlord landlord = Mapper.Map<Landlord>(landlordBindingModel);
            this.Context.Landlords.Add(landlord);
            this.Context.SaveChanges();
        }

        public LandlordsViewModel GetAllLandlords()
        {
            LandlordsViewModel model = new LandlordsViewModel();
            List<LandlordViewModel> landlordsList = new List<LandlordViewModel>();

            var lords = this.Context.Landlords;

            foreach (var item in lords)
            {
                LandlordViewModel landlord = Mapper.Map<Landlord, LandlordViewModel>(item);
                landlordsList.Add(landlord);
            }
            model.Landlords = landlordsList;
            return model;
        }
    }
}
