using Microsoft.EntityFrameworkCore;
using RailwayStation.DataAccess.Abstracts;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.Repositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.DataAccess.MsEntityFramework
{
    public class TrainStationDal : Repository<TrainStation>, ITrainStationDal
    {
        private readonly RailwayStationContext _db;
        public TrainStationDal(RailwayStationContext db) : base(db)
        {
            _db = db;
        }

    }
}
