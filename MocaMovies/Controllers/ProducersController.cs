using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MocaMovies.Data.Services;
using MocaMovies.Data.Static;
using MocaMovies.Models;

namespace MocaMovies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {

        private readonly IProducersService _Service;

        public ProducersController(IProducersService Service) { _Service = Service; }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _Service.GetAllAsync();
            return View(allProducers);
        }

        //GET: Producers/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _Service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        // Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _Service.AddAsync(producer);
            return RedirectToAction("Index");
        }


        // Get: Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetails = await _Service.GetByIdAsync(id);
            if (ProducerDetails == null)
                return View("NotFound");
            return View(ProducerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _Service.UpdateAsync(id, producer);
            return RedirectToAction("Index");
        }
        // Get: Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _Service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _Service.GetByIdAsync(id);
            if (producerDetails == null)
                return View("NotFound");

            await _Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
