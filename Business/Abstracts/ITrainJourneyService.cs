using RailwayStation.Entity.Modals;

namespace RailwayStation.Business.Abstracts
{
    public interface ITrainJourneyService: IGenericService<TrainJourney>
    {
        public List<TrainJourney> GetTrainJourneyGetList();
    }
}
