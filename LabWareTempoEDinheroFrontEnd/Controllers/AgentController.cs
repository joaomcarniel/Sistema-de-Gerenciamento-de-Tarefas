using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }

        public IActionResult Index()
        {
            var response = agentService.GetAll();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateOnDatabase(Agent agent)
        {

            if (ModelState.IsValid)
            {
                agentService.Creating(agent);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var response = agentService.GetById(id);
            return View(response);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var response = agentService.GetById(id);
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            agentService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Agent agent)
        {
            if (ModelState.IsValid)
            {
                agentService.Update(agent);
                return RedirectToAction("Index");
            }

            return View(agent);
        }
    }
}
