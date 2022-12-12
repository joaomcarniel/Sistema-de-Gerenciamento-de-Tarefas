using LabWareTempoEDinheroFrontEnd.Reports.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers.ReportControllers
{
    public class AgentProjectReportController : Controller
    {
        private readonly IAgentProjectReportService reportService;

        public AgentProjectReportController(IAgentProjectReportService reportService)
        {
            this.reportService = reportService;
        }

        public IActionResult Index()
        {
            var report = reportService.GetAgentProjectReport();
            return View(report);
        }

        public IActionResult GeneratePDF()
        {
            var report = reportService.GetAgentProjectReport();
            reportService.GeneratePDF(report);
            return RedirectToAction("Index");
        }
    }
}
