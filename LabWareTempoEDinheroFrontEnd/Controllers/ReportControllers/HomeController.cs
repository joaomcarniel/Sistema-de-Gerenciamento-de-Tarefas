using LabWareTempoEDinheroFrontEnd.Reports.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers.ReportControllers
{
    public class HomeController : Controller
    {
        private readonly ITasksFromProjectsReportService reportService;

        public HomeController(ITasksFromProjectsReportService reportService)
        {
            this.reportService = reportService;
        }

        public IActionResult Index()
        {
            var report = reportService.GetTasksProjectReport();
            return View(report);
        }

        public IActionResult GeneratePDF()
        {
            var report = reportService.GetTasksProjectReport();
            reportService.GeneratePDF(report);
            return RedirectToAction("Index");
        }
    }
}
