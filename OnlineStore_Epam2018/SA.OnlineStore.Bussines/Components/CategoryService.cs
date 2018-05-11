
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class CategoryService : ICategoryService
    {
        private List<CategoryModel> _category = new List<CategoryModel>();
        private List<string> _nameCategory = new List<string>();

        public CategoryService()
        {
            Create(new CategoryModel
            {
                CategoryName = "Яблоня"
            });
            Create(new CategoryModel
            {
                CategoryName = "Груша"
            });
            Create(new CategoryModel
            {
                CategoryName = "Вишня"
            });
            Create(new CategoryModel
            {
                CategoryName = "Черешня"
            });
            Create(new CategoryModel
            {
                CategoryName = "Абрикос"
            });
            Create(new CategoryModel
            {
                CategoryName = "Персик"
            });
        }


        public void Create(CategoryModel model)
        {
            _category.Add(model);
        }

        public IEnumerable<string> CategoryNameList()
        {
            foreach(var item in _category)
            {
                if (_category.Count > _nameCategory.Count)  // УБРАТЬ! (когда будет база...)
                {
                    _nameCategory.Add(item.CategoryName);
                }
            }
            return _nameCategory;
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
            throw new NotImplementedException();
        }

        public void SaveCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
