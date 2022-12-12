using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public IActionResult Index()
        {
            var response = taskService.GetAll();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateOnDatabase(TaskModel taskModel)
        {

            if (ModelState.IsValid)
            {
                taskService.Creating(taskModel);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var response = taskService.GetById(id);
            return View(response);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var response = taskService.GetById(id);
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            taskService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(TaskModel taskModel)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(taskModel);
                return RedirectToAction("Index");
            }

            return View(taskModel);
        }
    }
}
