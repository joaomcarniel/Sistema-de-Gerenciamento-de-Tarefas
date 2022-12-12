using LabWareTempoEDinheroFrontEnd.Models.Authorization;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface ILoginService
    {
        bool IsValidLogin(User user);
    }
}
