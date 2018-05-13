namespace SA.OnlineStore.DataAccess.Service
{ 
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ICategoryRepository
    {
        void Delete(int Id);
        void Save(CategoryModel model);
        CategoryModel Get(int Id);
        List<CategoryModel> GetCategoryList();
    }
}
