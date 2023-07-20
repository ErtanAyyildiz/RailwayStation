using Microsoft.AspNetCore.Mvc;
using RailwayStation.Business.Abstracts;
using RailwayStation.Entity.Modals;

namespace RailwayStation.UI.Controllers
{
    public class TrainStationController : Controller
    {
        private readonly ITrainStationService _trainStationService;

        public TrainStationController(ITrainStationService trainStationService)
        {
            _trainStationService = trainStationService;
        }

        public IActionResult Index()
        {
            var stations = _trainStationService.GetList();
            return View(stations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrainStation station)
        {
            if (ModelState.IsValid)
            {
                _trainStationService.Add(station);

                return RedirectToAction("Index");
            }
            return View(station);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var station = _trainStationService.GetByID(id);
            return View(station);
        }

        [HttpPost]
        public IActionResult Edit(TrainStation station)
        {
            if (ModelState.IsValid)
            {
                _trainStationService.Update(station);

                return RedirectToAction("Index");
            }
            return View(station);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var station = _trainStationService.GetByID(id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var station = _trainStationService.GetByID(id);
            if (station == null)
            {
                return NotFound();
            }

            _trainStationService.Remove(station);
            return RedirectToAction("Index");
        }
    }
}
