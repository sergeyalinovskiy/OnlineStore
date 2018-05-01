using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class CategoryService : ICategoryService
    {
        private List<Category> _category = new List<Category>();
        private List<string> _nameCategory = new List<string>();

        public CategoryService()
        {
            Create(new Category
            {
                CategoryName = "Яблоня"
            });
            Create(new Category
            {
                CategoryName = "Груша"
            });
            Create(new Category
            {
                CategoryName = "Вишня"
            });
            Create(new Category
            {
                CategoryName = "Черешня"
            });
            Create(new Category
            {
                CategoryName = "Абрикос"
            });
            Create(new Category
            {
                CategoryName = "Персик"
            });
        }


        public void Create(Category model)
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

        public void EditCategory(Category model)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategoryList()
        {
            throw new NotImplementedException();
        }

        public void SaveCategory(Category model)
        {
            throw new NotImplementedException();
        }
    }
}
