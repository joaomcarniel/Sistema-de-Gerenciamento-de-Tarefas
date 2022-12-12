namespace LabWareTempoEDinheroFrontEnd.Models.ReportModels
{
    public class ProjectsAgentsWorkingReportModel
    {
        public int IdAgent { get; set; }
        public string NameAgent { get; set; }
        public int IdProject { get; set; }
        public string NameProject { get; set; }
        public string DescriptionProject { get; set; }
        public string StatusProject { get; set; }
    }
}
