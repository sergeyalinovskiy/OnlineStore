namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ICategoryService
    {
        void Create(CategoryModel model);
        void DeleteCategoryByCategoryId(int Id);
        void SaveCategory(CategoryModel model);
        void EditCategory(CategoryModel model);
        CategoryModel GetCategory(int Id);
        IEnumerable<CategoryModel> GetCategoryList();
        IEnumerable<string> CategoryNameList();
    }
}
