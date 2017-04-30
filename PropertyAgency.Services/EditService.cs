using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAgency.Services
{
    using AutoMapper;
    using PropertyAgency.Models.EntityModels;
    using PropertyAgency.Models.ViewModels.Landlord;
    using PropertyAgency.Models.ViewModels.Property;
    using PropertyAgency.Models.ViewModels.Tenant;

    public class EditService : Service
    {
        public PropertyFormViewModel EditPropertyById(int id)
        {
            var property = this.Context.Properties.Find(id);

            PropertyFormViewModel model = Mapper.Map<Property, PropertyFormViewModel>(property);
            List<LandlordViewModel> landlordList = new List<LandlordViewModel>();
            
           
            foreach (var landlord in this.Context.Landlords)
            {
                LandlordViewModel lvm = Mapper.Map<Landlord, LandlordViewModel>(landlord);
                landlordList.Add(lvm);
            }
            model.LandlordsList = landlordList;
            return model;
        }

        public void EditProperty(PropertyFormViewModel model)
        {
            var propertyToEdit = this.Context.Properties.Find(model.Id);

            if (propertyToEdit != null)
            {
                propertyToEdit.Type = model.Type;
                propertyToEdit.ApartmentSize = model.ApartmentSize;
                propertyToEdit.FullAddress = model.FullAddress;
                propertyToEdit.IsActive = model.IsActive;
                propertyToEdit.NumberOfRooms = model.NumberOfRooms;
                propertyToEdit.Price = model.Price;
                propertyToEdit.UrlPicture = model.UrlPicture;
            }

            this.Context.SaveChanges();
        }

        public LandlordViewModel EditLandlordById(int id)
        {
            var landlord = this.Context.Landlords.Find(id);

            LandlordViewModel model = Mapper.Map<Landlord, LandlordViewModel>(landlord);
            
            return model;
        }
        public void EditLandlordById(LandlordViewModel model)
        {
            var landlordToEdit = this.Context.Landlords.Find(model.Id);

                landlordToEdit.FullName = model.FullName;
                landlordToEdit.PhoneNumber = model.PhoneNumber;
                landlordToEdit.IsAcceptingAnimals = model.IsAcceptingAnimals;
            
            this.Context.SaveChanges();
        }


        public TenantViewModel EditTenantById(int id)
        {
            var tenant = this.Context.Tenants.Find(id);

            TenantViewModel model = Mapper.Map<Tenant, TenantViewModel>(tenant);

            return model;
        }
        public void EditTenantById(TenantViewModel model)
        {
            var tenantToEdit = this.Context.Tenants.Find(model.Id);

            tenantToEdit.FullName = model.FullName;
            tenantToEdit.PhoneNumber = model.PhoneNumber;
            tenantToEdit.Description = model.Description;

            this.Context.SaveChanges();
        }
    }
}
