using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface ITimeControlTaskService
    {
        Timecontroltask Creating(Timecontroltask timecontroltask);
        List<Timecontroltask> GetAll();
        Timecontroltask GetById(int id);
        Timecontroltask Update(Timecontroltask timecontroltask);
        void Delete(int id);
    }
}
