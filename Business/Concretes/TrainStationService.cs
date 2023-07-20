using RailwayStation.Business.Abstracts;
using RailwayStation.DataAccess.Repositories.IRepositories;
using RailwayStation.Entity.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.Business.Concretes
{
    public class TrainStationService : ITrainStationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainStationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(TrainStation entity)
        {
            _unitOfWork.TrainStation.Add(entity);
            _unitOfWork.Save();
        }

        public TrainStation GetByID(int id)
        {
            return _unitOfWork.TrainStation.GetByID(id);
        }

        public List<TrainStation> GetList()
        {
            return _unitOfWork.TrainStation.GetList();
        }

        public void Remove(TrainStation entity)
        {
            _unitOfWork.TrainStation.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(TrainStation entity)
        {
            _unitOfWork.TrainStation.Update(entity);
            _unitOfWork.Save();
        }
    }
}
