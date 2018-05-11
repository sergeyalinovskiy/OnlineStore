
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
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
