using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RailwayStation.Business.Abstracts;
using RailwayStation.Entity.Modals;

namespace RailwayStation.UI.Controllers
{
    public class TrainJourneyController : Controller
    {
        private readonly ITrainJourneyService _trainJourneyService;
        private readonly ITrainStationService _trainStationService;

        public TrainJourneyController(ITrainJourneyService trainJourneyService, ITrainStationService trainStationService)
        {
            _trainJourneyService = trainJourneyService;
            _trainStationService = trainStationService;
        }

        public IActionResult Index()
        {
            var journies = _trainJourneyService.GetTrainJourneyGetList();

            return View(journies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var stations = _trainStationService.GetList();
            ViewBag.Stations = stations;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrainJourney journey)
        {
            //journey.DepartureStation = _trainStationService.GetByID(journey.DepartureStationID);
            //journey.ArrivalStation = _trainStationService.GetByID(journey.ArrivalStationID);

            _trainJourneyService.Add(journey);
            return RedirectToAction("Index");

            //var stations = _trainStationService.GetList();
            //ViewBag.Stations = stations;
            //return View(journey);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var journey = _trainJourneyService.GetByID(id);
            if (journey == null)
            {
                return NotFound();
            }
            var stations = _trainStationService.GetList();
            ViewBag.Stations = stations;
            return View(journey);
        }

        [HttpPost]
        public IActionResult Edit(int id, TrainJourney journey)
        {

            if (id != journey.JourneyID)
            {
                return NotFound();
            }

            _trainJourneyService.Update(journey);
            return RedirectToAction("Index");

            //var stations = _trainStationService.GetList();
            //ViewBag.Stations = stations;
            //return View(journey);
        }

        public IActionResult Delete(int id)
        {
            var journey = _trainJourneyService.GetByID(id);
            if (journey == null)
            {
                return NotFound();
            }
            return View(journey);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var journey = _trainJourneyService.GetByID(id);
            _trainJourneyService.Remove(journey);
            return RedirectToAction("Index");
        }
    }
}
