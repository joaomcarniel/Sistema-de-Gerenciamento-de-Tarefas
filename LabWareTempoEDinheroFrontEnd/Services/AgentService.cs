using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository agentRepository;

        public AgentService(IAgentRepository agentRepository)
        {
            this.agentRepository = agentRepository;
        }

        public Agent Creating(Agent agent)
        {
            return agentRepository.Creating(agent);
        }

        public List<Agent> GetAll()
        {
            return agentRepository.GetAll();
        }

        public Agent GetById(int id)
        {
            return agentRepository.GetById(id);
        }

        public Agent Update(Agent agent)
        {
            return agentRepository.Update(agent);
        }

        public void Delete(int id)
        {
            try
            {
                agentRepository.Delete(id);

            }
            catch (Exception e)
            {

            }
        }
    }
}
