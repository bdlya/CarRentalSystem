using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Owner;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using CarRentalSystem.Infrastructure.Data.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Owner
{
    public class AdminUserFunctionalityProviderService: IAdminUserFunctionalityProviderService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AdminUserFunctionalityProviderService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task CreateAdminAsync(RegistrationModel admin)
        {
            await _userService.RegisterUserAsync(_mapper.Map<UserModel>(admin), admin.Password, Policy.Administrator);
        }

        public async Task DeleteAdminAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        public async Task<IQueryable<UserModel>> GetAllAdminsAsync()
        {
            return await _userService.GetAllAdminsAsync();
        }
    }
}