namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Repositorys;
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
            if (model != null)
            {
                _categoryRepository.Create(model);
            }
        }

        public void DeleteCategoryByCategoryId(int Id)
        {
            if (Id > 0)
            {
                _categoryRepository.Delete(Id);
            }
        }

        public Category GetCategory(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            return _categoryRepository.GetById(Id);
        }

        public IEnumerable<Category> GetCategoryList()
        {
            return _categoryRepository.GetAll();
        }

        public void SaveCategory(Category model)
        {
            if (model != null)
            {
                _categoryRepository.Update(model);
            }
        }

    }
}
