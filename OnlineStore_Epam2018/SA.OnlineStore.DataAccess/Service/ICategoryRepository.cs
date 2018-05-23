namespace SA.OnlineStore.DataAccess.Service
{ 
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ICategoryRepository
    {
        void Delete(int Id);
        void Save(Category model);
        Category Get(int Id);
        List<Category> GetCategoryList();
    }
}
