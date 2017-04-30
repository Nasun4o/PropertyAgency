﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.Enums;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;

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

        public void AddProperty(PropertyFormViewModel model)
        {
            Property property = Mapper.Map<Property>(model);
            property.Owner = this.Context.Landlords.FirstOrDefault(m => m.Id == model.LandlordId);
            this.Context.Properties.Add(property);
            this.Context.SaveChanges();
        }

        public ShowPropertiesViewModel GetProperiesForRent()
        {
            var rentProperties = this.Context.Properties.Where(p => p.Type == PropertyType.Rent).ToArray();

            foreach (var item in rentProperties)
            {
                PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                this.propertyInfo.Add(property);
            }
            model.PropertyInfoViewModels = this.propertyInfo;
            return this.model;
        }

        public ShowPropertiesViewModel GetProperiesForSale()
        {
            var saleProperties = this.Context.Properties.Where(p => p.Type == PropertyType.Sale).ToArray();


            foreach (var item in saleProperties)
            {
                PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                this.propertyInfo.Add(property);
            }
            this.model.PropertyInfoViewModels = this.propertyInfo;
            return this.model;
        }
    }
}
