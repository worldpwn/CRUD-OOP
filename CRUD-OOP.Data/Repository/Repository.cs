using CRUD_OOP.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_OOP.Data.Repository
{
    public class Repository<T> where T : Model
    {
        private List<T> _data = new List<T>();


        public List<T> GetAll()
        {
            return _data;
        }
        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public T Get(int id)
        {
            return _data.FirstOrDefault(e => e.Id == id);
        }

        public int CreateId()
        {
            if (_data.Count == 0)
                return 1;

            var sorted =  _data.OrderBy(e=>e.Id).ToList();

            var last = sorted.Last();

            return last.Id + 1;
        }
    }
}
