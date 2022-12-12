using LabWareTempoEDinheroFrontEnd.Models.DbModels;
using LabWareTempoEDinheroFrontEnd.Services;
using LabWareTempoEDinheroFrontEnd.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabWareTempoEDinheroFrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var response = _customerService.GetAll();
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateOnDatabase(Customer customer)
        {

            if (ModelState.IsValid)
            {
                _customerService.Creating(customer);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var response = _customerService.GetById(id);
            return View(response);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var response = _customerService.GetById(id);
            return View(response);
        }

        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }
    }
}
