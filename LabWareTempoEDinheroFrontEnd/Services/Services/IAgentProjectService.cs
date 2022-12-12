using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface IAgentProjectService
    {
        Agentproject Creating(Agentproject agentproject);
        List<Agentproject> GetAll();
        Agentproject GetById(int id);
        Agentproject Update(Agentproject agentProject);
        void Delete(int id);
    }
}
