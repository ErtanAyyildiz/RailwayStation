using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.Business.Abstracts
{
    public interface IGenericService<T> where T: class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        List<T> GetList();
        T GetByID(int id);
    }
}
