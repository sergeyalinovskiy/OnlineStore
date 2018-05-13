﻿using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface ICategoryRepository
    {
        void Delete(int Id);
        void Save(CategoryModel model);
        CategoryModel Get(int Id);
        List<CategoryModel> GetCategoryList();
    }
}
