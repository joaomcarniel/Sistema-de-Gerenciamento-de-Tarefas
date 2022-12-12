using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Repository.Interfaces
{
    public interface IAgentProjectRepository
    {
        Agentproject Creating(Agentproject agentProject);
        List<Agentproject> GetAll();
        Agentproject GetById(int id);
        Agentproject Update(Agentproject agentProject);
        bool Delete(int id);
    }
}
