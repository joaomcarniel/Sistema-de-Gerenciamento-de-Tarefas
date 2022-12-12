using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface ITaskService
    {
        TaskModel Creating(TaskModel taskModel);
        List<TaskModel> GetAll();
        TaskModel GetById(int id);
        TaskModel Update(TaskModel taskModel);
        void Delete(int id);
    }
}
