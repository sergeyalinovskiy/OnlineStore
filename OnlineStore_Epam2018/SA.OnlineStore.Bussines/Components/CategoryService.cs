namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    #endregion
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    
        public IEnumerable<string> CategoryNameList()
        {
            List<string> categoryNames = new List<string>();
            foreach(CategoryModel item in _categoryRepository.GetCategoryList())
            {
                categoryNames.Add(item.CategoryName);
            }
            return categoryNames;
        }

        public void Create(CategoryModel model)
        {
            _categoryRepository.Save(model);
        }

        public void DeleteCategoryByCategoryId(int Id)
        {
            _categoryRepository.Delete(Id);
        }

        public void EditCategory(CategoryModel model)
        {
            throw new NotImplementedException();   //!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public CategoryModel GetCategory(int Id)
        {
            return _categoryRepository.Get(Id);
        }

        public IEnumerable<CategoryModel> GetCategoryList()
        {
            return _categoryRepository.GetCategoryList();
        }

        public void SaveCategory(CategoryModel model)
        {
            _categoryRepository.Save(model);
        }

    }
}
