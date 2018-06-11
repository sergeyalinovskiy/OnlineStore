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
            var viewModel = ConvertToListViewModel(_categoryService.GetCategoryList());
            return View(viewModel);
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
        public ActionResult Create(CategoryViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var category = this.ConvertToBussinesModel(model);
                    _categoryService.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
            }
            return View();
        }
        [Editor]
        public ActionResult Details(int id)
        {
            CategoryViewModel category = ConvertToViewModel(_categoryService.GetCategory(id));
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
            var category = ConvertToViewModel(_categoryService.GetCategory(Id));
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var category = this.ConvertToBussinesModel(model);
                    this._categoryService.SaveCategory(category);
                    return RedirectToAction("Details", new { Id = model.CategoryId });
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Exceptions");
                }
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
            var category = _categoryService.GetCategoryList().Where(m => m.ParentId == model.ParentId).FirstOrDefault();
            return new CategoryViewModel()
            {
                CategoryId= model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId= model.ParentId,
                ParentCategoryName=category.CategoryName
            };
        }

        public Category ConvertToBussinesModel(CategoryViewModel model)
        {
            var category = _categoryService.GetCategoryList().Where(m => m.CategoryName == model.CategoryName).FirstOrDefault();
            return new Category()
            {
                CategoryName = model.NewCategoryName,
                ParentId = category.CategoryId
            };
        }
    }
}