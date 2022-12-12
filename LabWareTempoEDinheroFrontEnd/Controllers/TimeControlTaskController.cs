using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class TimeControlTaskController : Controller
    {
        private readonly ITimeControlTaskService timeControlTaskService;

        public TimeControlTaskController(ITimeControlTaskService timeControlTaskService)
        {
            this.timeControlTaskService = timeControlTaskService;
        }

        public IActionResult Index()
        {
            var response = timeControlTaskService.GetAll();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateOnDatabase(Timecontroltask timecontroltask)
        {

            if (ModelState.IsValid)
            {
                timeControlTaskService.Creating(timecontroltask);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var response = timeControlTaskService.GetById(id);
            return View(response);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var response = timeControlTaskService.GetById(id);
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            timeControlTaskService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Timecontroltask timeControlTask)
        {
            if (ModelState.IsValid)
            {
                timeControlTaskService.Update(timeControlTask);
                return RedirectToAction("Index");
            }

            return View(timeControlTask);
        }
    }
}
