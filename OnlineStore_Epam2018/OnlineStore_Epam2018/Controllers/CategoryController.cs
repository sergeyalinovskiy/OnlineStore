namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using OnlineStore_Epam2018.RoleAttribut;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    #endregion
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
        }
        public CategoryController(ICategoryService categoryService, ICommonLogger commonLogger)
        {
            if (categoryService == null)
            {
                throw new NullReferenceException("categoryService");
            }
            _categoryService = categoryService;
        }
        
        [Editor]
        public ActionResult Index()
        {
            var listCategory = _categoryService.GetCategoryList();
            var viewModel = ConvertToListViewModel(listCategory);
            return View(viewModel);
        }


        [Editor]
        public ActionResult CreateNewCategory()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCategory(CategoryViewModel model)
        {
            if (model.CategoryName!= null)
            {
                model.CategoryId = 0;
                model.ParentId = 0;
                
                var category = ConvertToBussinesModelNewCategory(model);
                _categoryService.SaveCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            model.CategoryList = _categoryService.GetCategoryList();
            return View(model);
        }

        [Editor]
        public ActionResult Create()
        {

            var viewModel = new CategoryViewModel()
            {
                CategoryList = _categoryService.GetCategoryList()
            };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
    {
            if (model.NewCategoryName!=null && model.CategoryName!=null)
            { 
                var category = ConvertToNewBussinesModel(model);
                _categoryService.SaveCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            model.CategoryList = _categoryService.GetCategoryList();
            return View(model);
        }
        [Editor]
        public ActionResult Details(int id)
        {
            var categorybussiness = _categoryService.GetCategory(id);
            CategoryViewModel category = ConvertToViewModel(categorybussiness);
            return View(category);
        }
       
        [Editor]
        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategoryByCategoryId(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var categoryBussiness = _categoryService.GetCategory(Id);
            var category = ConvertToViewModel(categoryBussiness);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            try
            {
                var category = ConvertToBussinesModel(model);
                _categoryService.SaveCategory(category);
                return RedirectToAction("Details", new { Id = model.CategoryId });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
        return View();
        }

        public List<CategoryViewModel> ConvertToListViewModel(IEnumerable<Category> modelList)
        {
            List<CategoryViewModel> resultList = new List<CategoryViewModel>();
            foreach(Category item in modelList)
            {
                resultList.Add(ConvertToViewModel(item));
            }
            return resultList;
        }

        public CategoryViewModel ConvertToViewModel(Category model)
        {
            var category = _categoryService.GetCategoryList();
            if (model.ParentId != 0)
            {
                return new CategoryViewModel()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    ParentId = model.ParentId,
                    ParentCategoryName = category.Where(m => m.CategoryId == model.ParentId).Select(m => m.CategoryName).FirstOrDefault()
                };
            }
            else
            {
                return new CategoryViewModel()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    ParentId = model.ParentId,
                    ParentCategoryName = "------"
                };
            }
        }

        public Category ConvertToBussinesModel(CategoryViewModel model)
        {
            var categoryLIst = _categoryService.GetCategoryList();
            var category = categoryLIst.Where(m => m.CategoryName == model.CategoryName).FirstOrDefault();
            return new Category()
            {
                CategoryId=model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = category.ParentId
            };
        }


        public Category ConvertToBussinesModelNewCategory(CategoryViewModel model)
        {
           
            return new Category()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = model.ParentId
            };
        }


        public Category ConvertToNewBussinesModel(CategoryViewModel model)
        {
            var categoryLIst = _categoryService.GetCategoryList();
            var category = categoryLIst.Where(m => m.CategoryName == model.CategoryName).FirstOrDefault();
            return new Category()
            {
                CategoryName= model.NewCategoryName ,
                ParentId = category.CategoryId
            };
        }
    }
}