using RailwayStation.Business.Abstracts;
using RailwayStation.DataAccess.Repositories.IRepositories;
using RailwayStation.Entity.Modals;

namespace RailwayStation.Business.Concretes
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AppUser entity)
        {
            _unitOfWork.AppUser.Add(entity);
            _unitOfWork.Save();
        }

        public AppUser GetByID(int id)
        {
            return _unitOfWork.AppUser.GetByID(id);
        }

        public List<AppUser> GetList()
        {
            return _unitOfWork.AppUser.GetList();
        }

        public void Remove(AppUser entity)
        {
            _unitOfWork.AppUser.Remove(entity);
            _unitOfWork.Save();
        }

        public void Update(AppUser entity)
        {
            _unitOfWork.AppUser.Update(entity);
            _unitOfWork.Save();
        }
    }
}
