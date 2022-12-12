using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class AgentProjectController : Controller
    {
        private readonly IAgentProjectService agentProjectService;

        public AgentProjectController(IAgentProjectService agentProjectService)
        {
            this.agentProjectService = agentProjectService;
        }

        public IActionResult Index()
        {
            var response = agentProjectService.GetAll();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateOnDatabase(Agentproject agentProject)
        {

            if (ModelState.IsValid)
            {
                agentProjectService.Creating(agentProject);
                return RedirectToAction("Create");
            }

            return View(agentProject);
        }

        public IActionResult Update(int id)
        {
            var response = agentProjectService.GetById(id);
            return View(response);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var response = agentProjectService.GetById(id);
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            agentProjectService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Agentproject agentProject)
        {
            if (ModelState.IsValid)
            {
                agentProjectService.Update(agentProject);
                return RedirectToAction("Index");
            }

            return View(agentProject);
        }
    }
}
