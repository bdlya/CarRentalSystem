using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Entities.Support;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using CarRentalSystem.Presentation.Data.ViewModels.Support;

namespace CarRentalSystem.Infrastructure.Mapping.Profiles
{
    public class CarRentalSystemProfile : Profile
    {
        public CarRentalSystemProfile()
        {
            CreateEntityToModelMaps();

            CreateModelToViewModelMaps();

            CreateModelToModelMaps();
        }

        private void CreateEntityToModelMaps()
        {
            CreateMap<Car, CarModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<PointOfRental, PointOfRentalModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<AdditionalWork, AdditionalWorkModel>().ReverseMap();

            CreateMap<OrderAdditionalWork, OrderAdditionalWorkModel>()
                .ForMember(dest => dest.AdditionalWork,
                    opt => opt.MapFrom(src => src.AdditionalService))
                .ForMember(dest => dest.AdditionalWorkId,
                    opt => opt.MapFrom(src => src.AdditionalServiceId))
                .ReverseMap();
            CreateMap<RefreshToken, RefreshTokenModel>().ReverseMap();
        }

        private void CreateModelToViewModelMaps()
        {
            CreateMap<CarModel, CarViewModel>().ReverseMap();
            CreateMap<OrderModel, OrderViewModel>().ReverseMap();
            CreateMap<PointOfRentalModel, PointOfRentalViewModel>().ReverseMap();
            CreateMap<UserModel, UserViewModel>().ReverseMap();
            CreateMap<AdditionalWorkModel, AdditionalWorkViewModel>().ReverseMap();

            CreateMap<OrderAdditionalWorkModel, OrderAdditionalWorkViewModel>().ReverseMap();
            CreateMap<RefreshTokenModel, RefreshTokenViewModel>().ReverseMap();

            CreateMap<RegistrationViewModel, RegistrationModel>().ReverseMap();
            CreateMap<AuthenticationViewModel, AuthenticationModel>().ReverseMap();
            CreateMap<PointSearchViewModel, PointSearchModel>().ReverseMap();
            CreateMap<BookingDatesViewModel, BookingDatesModel>().ReverseMap();
            CreateMap<OrderSearchViewModel, OrderSearchModel>().ReverseMap();
            CreateMap<CarSearchViewModel, CarSearchModel>().ReverseMap();
            CreateMap<OrderCreationViewModel, OrderViewModel>().ReverseMap();
        }

        private void CreateModelToModelMaps()
        {
            CreateMap<RegistrationModel, UserModel>().ReverseMap();
        }
    }
}