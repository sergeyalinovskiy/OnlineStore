namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.Common.Logger;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    #endregion
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        //private readonly ICommonLogger _myLoger;
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

        public ActionResult Index()
        {
            var viewModel= ConvertToListViewModel(_categoryService.GetCategoryList());
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
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

        public ActionResult Details(int id)
        {
            CategoryViewModel category = ConvertToViewModel(_categoryService.GetCategory(id));
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            _categoryService.DeleteCategoryByCategoryId(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var category = this.ConvertToViewModel(this._categoryService.GetCategory(Id));
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
            return new CategoryViewModel()
            {
                CategoryId= model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId= model.ParentId
            };
        }

        public Category ConvertToBussinesModel(CategoryViewModel model)
        {
            return new Category()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = model.ParentId
            };
        }
    }
}