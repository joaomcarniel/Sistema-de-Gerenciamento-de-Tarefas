using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface IAgentRepository
    {
        Agent Creating(Agent agent);
        List<Agent> GetAll();
        Agent GetById(int id);
        Agent Update(Agent agent);
        bool Delete(int id);
    }
}
