using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class AgentProjectService : IAgentProjectService
    {
        private readonly IAgentProjectRepository _agentProjectRepository;

        public AgentProjectService(IAgentProjectRepository agentProjectRepository)
        {
            _agentProjectRepository = agentProjectRepository;
        }

        public Agentproject Creating(Agentproject agentproject)
        {
            agentproject.StartAction = DateTime.Now;
            return _agentProjectRepository.Creating(agentproject);
        }

        public List<Agentproject> GetAll()
        {
            return _agentProjectRepository.GetAll();
        }

        public Agentproject GetById(int id)
        {
            return _agentProjectRepository.GetById(id);
        }

        public Agentproject Update(Agentproject agentProject)
        {
            return _agentProjectRepository.Update(agentProject);
        }

        public void Delete(int id)
        {
            try
            {
                _agentProjectRepository.Delete(id);

            }
            catch (Exception e)
            {

            }
        }
    }
}
