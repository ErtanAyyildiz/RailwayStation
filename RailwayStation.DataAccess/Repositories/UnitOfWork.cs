using RailwayStation.DataAccess.Abstracts;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.MsEntityFramework;
using RailwayStation.DataAccess.Repositories.IRepositories;

namespace RailwayStation.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RailwayStationContext _db;

        public UnitOfWork(RailwayStationContext db)
        {
            _db = db;
            AppUser =new AppUserDal(_db);
            TrainJourney =new TrainJourneyDal(_db);
            TrainStation =new TrainStationDal(_db);
        }

        public IAppUserDal AppUser { get; private set; }
        public ITrainJourneyDal TrainJourney { get; private set; }
        public ITrainStationDal TrainStation { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
