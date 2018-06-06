namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ICategoryService
    {
        void Create(Category model);
        void DeleteCategoryByCategoryId(int Id);
        void SaveCategory(Category model);
        Category GetCategory(int Id);
        IEnumerable<Category> GetCategoryList();
        IEnumerable<string> CategoryNameList();
    }
}
