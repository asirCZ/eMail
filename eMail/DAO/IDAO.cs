using System.Collections.Generic;

namespace eMail;

/// <summary>
///     Represents the interface for a Data Access Object (DAO) with basic CRUD operations for a specific type.
/// </summary>
/// <typeparam name="T">The type of the objects managed by the DAO.</typeparam>
public interface IDao<T> where T : IBaseClass
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Save(T element);
    void Delete(T element);
}