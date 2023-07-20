using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Abstracts;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.Repositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.DataAccess.MsEntityFramework
{
    public class TrainJourneyDal : Repository<TrainJourney>, ITrainJourneyDal
    {
        private readonly RailwayStationContext _db;
        public TrainJourneyDal(RailwayStationContext db) : base(db)
        {
            _db = db;
        }

        public List<TrainJourney> GetTrainJourneyGetList()
        {
            return _db.TrainJourneys
                .Include(s => s.DepartureStation)
                .Include(s => s.ArrivalStation)
                .ToList();
        }
    }
}
