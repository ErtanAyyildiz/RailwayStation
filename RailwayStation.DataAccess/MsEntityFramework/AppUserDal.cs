using RailwayStation.DataAccess.Abstracts;
using RailwayStation.DataAccess.Database;
using RailwayStation.DataAccess.Repositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.DataAccess.MsEntityFramework
{
    public class AppUserDal : Repository<AppUser>, IAppUserDal
    {
        private readonly RailwayStationContext _db;
        public AppUserDal(RailwayStationContext db) : base(db)
        {
            _db = db;
        }
    }
}
