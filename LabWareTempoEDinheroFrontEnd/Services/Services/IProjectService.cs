using LabWareTempoEDinheroFrontEnd.Models.DbModels;

namespace LabWareTempoEDinheroFrontEnd.Services.Services
{
    public interface IProjectService
    {
        Project Creating(Project project);
        List<Project> GetAll();
        Project GetById(int id);
        Project Update(Project project);
        void Delete(int id);
    }
}
