using System.Collections.Generic;

namespace eMail
{
    public interface IDao<T> where T : IBaseClass
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Delete(T element);
    }
}