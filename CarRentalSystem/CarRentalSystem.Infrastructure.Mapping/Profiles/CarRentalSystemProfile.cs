﻿using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.View.ViewModels;
using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.Infrastructure.Mapping.Profiles
{
    public class CarRentalSystemProfile : Profile
    {
        public CarRentalSystemProfile()
        {
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<PointOfRental, PointOfRentalModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<OrderAdditionalService, OrderAdditionalServiceModel>().ReverseMap();
            CreateMap<AdditionalService, AdditionalServiceModel>().ReverseMap();

            CreateMap<CarModel, CarViewModel>().ReverseMap();
            CreateMap<OrderModel, OrderViewModel>().ReverseMap();
            CreateMap<PointOfRentalModel, PointOfRentalViewModel>().ReverseMap();
            CreateMap<UserModel, UserViewModel>().ReverseMap();
            CreateMap<OrderAdditionalServiceModel, OrderAdditionalServiceViewModel>().ReverseMap();
            CreateMap<AdditionalServiceModel, AdditionalServiceViewModel>().ReverseMap();

            CreateMap<RegistrationViewModel, UserModel>();
        }
    }
}