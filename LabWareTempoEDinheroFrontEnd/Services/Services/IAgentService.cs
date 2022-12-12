using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface IAgentService
    {
        Agent Creating(Agent agent);
        List<Agent> GetAll();
        Agent GetById(int id);
        Agent Update(Agent agent);
        void Delete(int id);
    }
}