
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
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
            throw new NotImplementedException();
        }

        public void DeleteCategoryByCategoryId(int Id)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryModel> GetCategoryList()
        {
            return _categoryRepository.GetCategoryList();
        }

        public void SaveCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }

    }
}
