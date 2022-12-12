using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class TimeControlTaskService : ITimeControlTaskService
    {
        private readonly ITimeControlTaskRepository timeControlTaskRepository;

        public TimeControlTaskService(ITimeControlTaskRepository timeControlTaskRepository)
        {
            this.timeControlTaskRepository = timeControlTaskRepository;
        }

        public Timecontroltask Creating(Timecontroltask timecontroltask)
        {
            return timeControlTaskRepository.Creating(timecontroltask);
        }

        public List<Timecontroltask> GetAll()
        {
            return timeControlTaskRepository.GetAll();
        }

        public Timecontroltask GetById(int id)
        {
            return timeControlTaskRepository.GetById(id);
        }

        public Timecontroltask Update(Timecontroltask timeControlTask)
        {
            return timeControlTaskRepository.Update(timeControlTask);
        }

        public void Delete(int id)
        {
            try
            {
                timeControlTaskRepository.Delete(id);

            }
            catch (Exception e)
            {

            }
        }
    }
}
