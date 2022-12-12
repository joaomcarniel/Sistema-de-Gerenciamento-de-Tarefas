using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using LabWareTempoEDinheroFrontEnd.Services.Services;

namespace LabWareTempoEDinheroFrontEnd.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public Project Creating(Project project)
        {
            return projectRepository.Creating(project);
        }

        public List<Project> GetAll()
        {
            return projectRepository.GetAll();
        }

        public Project GetById(int id)
        {
            return projectRepository.GetById(id);
        }

        public Project Update(Project project)
        {
            return projectRepository.Update(project);
        }

        public void Delete(int id)
        {
            try
            {
                projectRepository.Delete(id);

            }
            catch (Exception e)
            {

            }
        }
    }
}
