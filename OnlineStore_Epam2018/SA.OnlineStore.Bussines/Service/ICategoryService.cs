using SA.OnlineStore.Bussines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface ICategoryService
    {
        void Create(Category model);
        void DeleteCategoryByCategoryId(int Id);
        void SaveCategory(Category model);
        void EditCategory(Category model);
        Category GetCategory(int Id);
        IEnumerable<Category> GetCategoryList();
        IEnumerable<string> CategoryNameList();
    }
}
