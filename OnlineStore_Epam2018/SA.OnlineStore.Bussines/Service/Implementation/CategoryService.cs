namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    #endregion
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        
        public CategoryService( IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    
        public IEnumerable<string> CategoryNameList()
        {
            List<string> categoryNames = new List<string>();
            foreach(Category item in _categoryRepository.GetAll())
            {
                if (item.ParentId != 0)
                {
                    categoryNames.Add(item.CategoryName);
                }
            }
            return categoryNames;
        }

        public void Create(Category model)
        {
            _categoryRepository.Create(model);
        }

        public void DeleteCategoryByCategoryId(int Id)
        {
            _categoryRepository.Delete(Id);
        }

        public Category GetCategory(int Id)
        {
            return _categoryRepository.GetById(Id);
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _categoryRepository.GetAll();
        }

        public void SaveCategory(Category model)
        {
            _categoryRepository.Update(model);
        }

    }
}
