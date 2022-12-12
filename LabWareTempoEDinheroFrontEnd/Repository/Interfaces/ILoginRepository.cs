using LabWareTempoEDinheroFrontEnd.Models.Authorization;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface ILoginRepository
    {
        User FindActiveUser(User user);
    }
}
