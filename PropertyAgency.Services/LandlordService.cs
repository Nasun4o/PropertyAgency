namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using PropertyAgency.Models.PaginationModels;
    using PropertyAgency.Models.ViewModels.Property;

    public class LandlordService : Service
    {
        private const int NumberOfItemsInPage = 20;
        public void AddLandlord(LandlordsBindingModel landlordBindingModel)
        {
            Landlord landlord = Mapper.Map<Landlord>(landlordBindingModel);
            this.Context.Landlords.Add(landlord);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// This is the logic which will Display All Landlords and will separate them in pages and each page will show 20 items.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public LandlordsViewModel GetAllLandlords(int? page)
        {
            LandlordsViewModel model = new LandlordsViewModel();
            List<LandlordViewModel> landlordsList = new List<LandlordViewModel>();

            var lords = this.Context.Landlords.OrderBy(m => m.Id).ToArray();

            if (page == null)
            {
                model.Pager = new Pager(lords.Count(), 1, NumberOfItemsInPage);

                foreach (var item in lords.Take(20))
                {
                    LandlordViewModel landlord = Mapper.Map<Landlord, LandlordViewModel>(item);
                    landlordsList.Add(landlord);
                }
                model.Landlords = landlordsList;
            }
            else
            {
                model.Pager = new Pager(lords.Count(), (int)page, NumberOfItemsInPage);

                model.Landlords = Mapper.Instance.Map<IEnumerable<Landlord>, IEnumerable<LandlordViewModel>>(
                    lords.Skip((model.Pager.CurrentPage - 1) * model.Pager.PageSize).Take(model.Pager.PageSize));
            }
            return model;
        }

        public void Delete(int? id)
        {
            var landlord = this.Context.Landlords.Find(id);
            if (landlord == null)
            {
                return;
            }
            this.Context.Landlords.Remove(landlord);
            this.Context.SaveChanges();
        }
    }
}
