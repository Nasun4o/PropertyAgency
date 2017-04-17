using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.BindingModels;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;

    public class PropertyService : Service
    {
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

        public void AddProperty(PropertyBindingModel model)
        {
            Property property = Mapper.Map<Property>(model);
            property.Owner = this.Context.Landlords.FirstOrDefault(m => m.Id == model.LandlordId);
            this.Context.Properties.Add(property);
            this.Context.SaveChanges();
        }

        public ShowPropertiesViewModel GetPropertyInfo()
        {
            ShowPropertiesViewModel model = new ShowPropertiesViewModel();
            List<PropertyInfoViewModel> propertyInfo = new List<PropertyInfoViewModel>();

            foreach (var item in this.Context.Properties)
            {
                PropertyInfoViewModel property = Mapper.Map<Property, PropertyInfoViewModel>(item);
                propertyInfo.Add(property);
            }
            model.PropertyInfoViewModels = propertyInfo;
            return model;
        }
    }
}
