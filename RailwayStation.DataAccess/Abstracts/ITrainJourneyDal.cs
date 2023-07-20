using RailwayStation.DataAccess.Repositories.IRepositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.DataAccess.Abstracts
{
    public interface ITrainJourneyDal:IRepository<TrainJourney>
    {
        public List<TrainJourney> GetTrainJourneyGetList();
    }
}
