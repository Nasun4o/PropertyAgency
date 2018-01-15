namespace PropertyAgency.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.Enums;
    using PropertyAgency.Models.PaginationModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using System.Web;
    using System;

    public class PropertyService : Service
    {

        private readonly ShowPropertiesViewModel model = new ShowPropertiesViewModel();
        private readonly List<PropertyInfoViewModel> propertyInfo = new List<PropertyInfoViewModel>();

     
        public PropertyFormViewModel GeneratePropertyViewModel()
        {
            PropertyFormViewModel model = new PropertyFormViewModel();
            List<LandlordViewModel> landlordList = new List<LandlordViewModel>();

            foreach (var landlord in this.Context.Landlords)
            {
                LandlordViewModel lvm = Mapper.Map<Landlord, LandlordViewModel>(landlord);
                landlordList.Add(lvm);
            }
            model.LandlordsList = landlordList;
            return model;
        }

        /// <summary>
        /// This is the logic for Adding a new Property in our Database it's simple as it's look.
        /// </summary>
        /// <param name="model"></param>
        public void AddProperty(PropertyFormViewModel model)
        {
           

            Property property = Mapper.Map<Property>(model);

            property.Owner = this.Context.Landlords.FirstOrDefault(m => m.Id == model.LandlordId);
            this.Context.Properties.Add(property);
            this.Context.SaveChanges();
        }
        /// <summary>
        /// This is the logic that will Display our properties which are under Rent and will separate them into pages. Each page will contain 10 items.
        /// </summary>
        /// <param name="model"></param>
        public ShowPropertiesViewModel GetProperiesForRent(int? page)
        {
            var rentProperties = this.Context.Properties.Where(p => p.Type == PropertyType.Rent).ToArray();

            if (page == null)
            {

                this.model.Pager = new Pager(rentProperties.Count(), 1);

                foreach (var item in rentProperties.Take(10))
                {
                    PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                    this.propertyInfo.Add(property);
                }
                this.model.PropertyInfoViewModels = this.propertyInfo;
            }
            else
            {
                this.model.Pager = new Pager(rentProperties.Count(), (int)page);

                this.model.PropertyInfoViewModels = Mapper.Instance.Map<IEnumerable<Property>, IEnumerable<PropertyInfoViewModel>>(
                    rentProperties.Skip((model.Pager.CurrentPage - 1) * this.model.Pager.PageSize).Take(model.Pager.PageSize));
            }

            return this.model;
        }

        /// <summary>
        /// This is the logic that will Display our properties which are for Sale and will separate them into pages. Each page will contain 10 items.
        /// </summary>
        /// <param name="model"></param>
        public ShowPropertiesViewModel GetProperiesForSale(int? page)
        {
            var saleProperties = this.Context.Properties.Where(p => p.Type == PropertyType.Sale).ToArray();

            if (page == null)
            {
                this.model.Pager = new Pager(saleProperties.Count(), 1);

                foreach (var item in saleProperties.Take(10))
                {
                    PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                    this.propertyInfo.Add(property);
                }
                this.model.PropertyInfoViewModels = this.propertyInfo;
            }
            else
            {
                this.model.Pager = new Pager(saleProperties.Count(), (int)page);

                this.model.PropertyInfoViewModels = Mapper.Instance.Map<IEnumerable<Property>, IEnumerable<PropertyInfoViewModel>>(
                    saleProperties.Skip((model.Pager.CurrentPage - 1) * this.model.Pager.PageSize).Take(model.Pager.PageSize));
            }
            return this.model;
        }

        public void Delete(int? id)
        {
            var property = this.Context.Properties.Find(id);
            if (property != null)
            {
                this.Context.Properties.Remove(property);
            }
            this.Context.SaveChanges();
        }

        /// <summary>
        /// This is the logic that will Display All our properties and will separate them into pages. Each page will contain 10 items.
        /// </summary>
        /// <param name="model"></param>
        public ShowPropertiesViewModel GetProperies(int? page)
        {
            var saleProperties = this.Context.Properties.ToArray();

            if (page == null)
            {
                this.model.Pager = new Pager(saleProperties.Count(), 1);

                foreach (var item in saleProperties.Take(10))
                {
                    PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                    this.propertyInfo.Add(property);
                }
                this.model.PropertyInfoViewModels = this.propertyInfo;
            }
            else
            {
                this.model.Pager = new Pager(saleProperties.Count(), (int)page);

                this.model.PropertyInfoViewModels = Mapper.Instance.Map<IEnumerable<Property>, IEnumerable<PropertyInfoViewModel>>(
                    saleProperties.Skip((model.Pager.CurrentPage - 1) * this.model.Pager.PageSize).Take(model.Pager.PageSize));
            }
            return this.model;
        }
    }
}
