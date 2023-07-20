using RailwayStation.Business.Abstracts;
using RailwayStation.DataAccess.Repositories.IRepositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.Business.Concretes
{
    public class TrainJourneyService : ITrainJourneyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainJourneyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TrainJourney entity)
        {
            _unitOfWork.TrainJourney.Add(entity);
            _unitOfWork.Save();
        }

        public TrainJourney GetByID(int id)
        {
            return _unitOfWork.TrainJourney.GetByID(id);
        }

        public List<TrainJourney> GetList()
        {
            return _unitOfWork.TrainJourney.GetList();
        }

        public List<TrainJourney> GetTrainJourneyGetList()
        {
            return _unitOfWork.TrainJourney.GetTrainJourneyGetList();
        }

        public void Remove(TrainJourney entity)
        {
            _unitOfWork.TrainJourney.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(TrainJourney entity)
        {
            _unitOfWork.TrainJourney.Update(entity);
            _unitOfWork.Save();
        }
    }
}
