namespace SA.OnlineStore.DataAccess.Implements
{
    #region Usings
        using System.Collections.Generic;
    #endregion
    public interface IRepository<T>
    {
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        T GetById(int id);
        IReadOnlyCollection<T> GetAll();
    }
}