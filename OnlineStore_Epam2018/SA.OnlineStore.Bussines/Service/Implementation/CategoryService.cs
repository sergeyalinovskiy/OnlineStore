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
            foreach(Category item in _categoryRepository.GetCategoryList())
            {
                categoryNames.Add(item.CategoryName);
            }
            return categoryNames;
        }

        public void Create(Category model)
        {
            _categoryRepository.Save(model);
        }

        public void DeleteCategoryByCategoryId(int Id)
        {
            _categoryRepository.Delete(Id);
        }

        public void EditCategory(Category model)
        {
            throw new NotImplementedException();   //!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public Category GetCategory(int Id)
        {
            return _categoryRepository.Get(Id);
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _categoryRepository.GetCategoryList();
        }

        public void SaveCategory(Category model)
        {
            _categoryRepository.Save(model);
        }

    }
}
