using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public TaskModel Creating(TaskModel taskModel)
        {
            return taskRepository.Creating(taskModel);
        }

        public List<TaskModel> GetAll()
        {
            return taskRepository.GetAll();
        }

        public TaskModel GetById(int id)
        {
            return taskRepository.GetById(id);
        }

        public TaskModel Update(TaskModel taskModel)
        {
            return taskRepository.Update(taskModel);
        }

        public void Delete(int id)
        {
            try
            {
                taskRepository.Delete(id);

            }
            catch (Exception e)
            {

            }
        }
    }
}
