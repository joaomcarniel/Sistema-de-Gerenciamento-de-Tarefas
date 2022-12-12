using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface ITimeControlTaskRepository
    {
        Timecontroltask Creating(Timecontroltask timecontroltask);
        List<Timecontroltask> GetAll();
        Timecontroltask GetById(int id);
        Timecontroltask Update(Timecontroltask timecontroltask);
        bool Delete(int id);
    }
}
