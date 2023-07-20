using RailwayStation.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.DataAccess.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IAppUserDal AppUser { get; }
        ITrainJourneyDal TrainJourney { get; }
        ITrainStationDal TrainStation { get; }

        void Save();    
    
    }
}
