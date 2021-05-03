using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Models.Base;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
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