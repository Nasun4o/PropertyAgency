﻿using System;
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

            propertyToEdit.Type = model.Type;
            propertyToEdit.ApartmentSize = model.ApartmentSize;
            propertyToEdit.FullAddress = model.FullAddress;
            propertyToEdit.IsActive = model.IsActive;
            propertyToEdit.NumberOfRooms = model.NumberOfRooms;
            propertyToEdit.Price = model.Price;
            propertyToEdit.UrlPicture = model.UrlPicture;

            this.Context.SaveChanges();
        }
    }
}
