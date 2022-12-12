using System.Security.Claims;
using LabWareTempoEDinheroFrontEnd.Models.Authorization;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _userRepository;

        public LoginService(ILoginRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsValidLogin(User user)
        {
            try
            {
                User userDb = _userRepository.FindActiveUser(user);
                return !string.IsNullOrEmpty(userDb.Password);
            }
            catch
            {
                return false;
            }
        }
    }
}
