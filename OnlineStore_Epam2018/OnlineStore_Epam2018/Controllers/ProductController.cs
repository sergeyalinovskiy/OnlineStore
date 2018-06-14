﻿namespace OnlineStore_Epam2018.Controllers
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
    using System.Web;
    using System.Web.Mvc;
    #endregion

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISeasonService _seasonService;
        private readonly IBasketService _basketService;
        private readonly ICommonLogger _myLoger;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISeasonService seasonService,
                                  IBasketService basketService,  IOrderService orderService, IUserService userService)
        {
            try
            {
                if (productService == null)
                {
                    throw new ArgumentNullException("productService");
                }
                if (basketService == null)
                {
                    throw new ArgumentNullException("basketService");
                }
                if (categoryService == null)
                {
                    throw new ArgumentNullException("categoryService");
                }
                if (seasonService == null)
                {
                    throw new ArgumentNullException("seasonService");
                }
                if (orderService == null)
                {
                    throw new ArgumentNullException("orderService");
                }
                if (userService == null)
                {
                    throw new ArgumentNullException("userService");
                }
                _productService = productService;
                _categoryService = categoryService;
                _seasonService = seasonService;
                _basketService = basketService;
                _orderService = orderService;
                _userService = userService;
            }
            catch (NullReferenceException)
            {
                View("Create");
            }
        }

        public ProductController()
        {

        }

        public ActionResult Index()
        {
            var list = _productService.GetProductLIst();

            IEnumerable<ProductViewModel> productList;
            productList = ConvertListToViewModel(list);
            if (productList == null)
            {
                return PartialView("ErrorPartialView");
            }
            return View("Index", productList);
        }

        [UserFilter]
        public ActionResult AddInBox(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index", "Error");
            }
            AddProductInBox(id);
            return View();
        }

        public ActionResult IndexSearch(int id)
        {
         IEnumerable<Product> productList = _productService.GetProductLIst();
            if (id != 0)
            {
                productList = productList.Where(m => m.Category.CategoryId == id);

                List<Product> p = new List<Product>();
                List<int> c = new List<int>();
                int n = productList.Count();
                if (n <= 1)
                {
                    foreach (Category item in _categoryService.GetCategoryList())
                    {
                        if (item.ParentId == id)
                        {
                            c.Add(item.CategoryId);
                        }
                        else
                        {
                            if (c.Count == 0)
                            {
                                c.Add(id);
                            }
                        }
                    }
                    foreach (int i in c)
                    {
                        foreach (Product item2 in _productService.GetProductLIst())
                        {
                            if (item2.Category.CategoryId == i)
                            {
                                p.Add(item2);
                            }
                        }
                    }
                    IEnumerable<ProductViewModel> list = ConvertListToViewModel(p);
                    return View("Index", list);
                }
                else
                {
                    IEnumerable<ProductViewModel> list = ConvertListToViewModel(productList);
                    return View("Index", list);
                }
            }
            IEnumerable<ProductViewModel> list2 = ConvertListToViewModel(productList);
            return View("Index", list2);
        }

        public ActionResult CategoryList()
        {
            var categorys = ConvertListToViewModel(_categoryService.GetCategoryList().Where(m=>m.ParentId==0));
            return PartialView(categorys);
        }

        public ActionResult SubCategoryList(int id)
        {
            var categorys = ConvertListToViewModel(_categoryService.GetCategoryList().Where(m => m.ParentId == id));
            return PartialView("SubCategoryList",categorys);
        }
        
        [Editor]
        public ActionResult Create()
        {
            var viewModel = new ProductViewModel()
            {
                CategoryList = _categoryService.GetCategoryList(),
                SeasonList = _seasonService.GetSeasonList()
            };
            viewModel.Picture = "picture_default.jpg";
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var product = this.ConvertToBussinesCreateModel(model);
                _productService.SaveProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            model.CategoryList = _categoryService.GetCategoryList();
            model.SeasonList = _seasonService.GetSeasonList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            if (id>0)
            {
                ProductViewModel product = ConvertToViewModel(_productService.GetProduct(id));
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
        }
      
        [Editor]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProductByProductId(id);
            return RedirectToAction("Index");
        }

        [Editor]
        public ActionResult Edit(int id)
        {
            var product = this.ConvertToViewModel(this._productService.GetProduct(id));
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            
            try
            {
                var product = this.ConvertToBussinesModel(model);
                _productService.SaveProduct(product);
                return RedirectToAction("Details", new { Id = model.Id });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Internal Exceptions");
            }
            return View();
        }

        #region Convertation
        public List<ProductViewModel> ConvertListToViewModel(IEnumerable<Product> models)
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (Product item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        } 

        public List<CategoryViewModel> ConvertListToViewModel(IEnumerable<Category> models)
        {
            List<CategoryViewModel> products = new List<CategoryViewModel>();
            foreach (Category item in models)
            {
                products.Add(ConvertToViewModel(item));
            }
            return products;
        }

        public CategoryViewModel ConvertToViewModel(Category model)
        {
            var category = _categoryService.GetCategoryList().Where(c => c.ParentId == model.CategoryId).FirstOrDefault();
            return new CategoryViewModel()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                ParentId = model.ParentId
            };
        }


        public ProductViewModel ConvertToViewModel(Product model)
        {
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonId == model.Season.SeasonId).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryId == model.Category.CategoryId).FirstOrDefault();
            return new ProductViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Category = new Category
                {
                    CategoryId = model.Category.CategoryId,
                    CategoryName = model.Category.CategoryName
                },
                SeasonName = season.SeasonName,
                Picture = model.Picture,
                Description = model.Description,
                Count = model.Count,
                Price = model.Price,
                CategoryList = _categoryService.GetCategoryList(),
                SeasonList = _seasonService.GetSeasonList()
            };
        }

        public Product ConvertToBussinesModel(ProductViewModel model)
        {
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonId == model.Season.SeasonId).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryId == model.Category.CategoryId).FirstOrDefault();
            return new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Category=new Category()
                {
                    CategoryId= category.CategoryId,
                    CategoryName=category.CategoryName,
                    ParentId=category.ParentId  
                },
                Season= new Season()
                {
                    SeasonId = season.SeasonId,
                    SeasonName=season.SeasonName
                },
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
                
            };
        }

        public Product ConvertToBussinesCreateModel(ProductViewModel model)
        {
            var season = _seasonService.GetSeasonList().Where(s => s.SeasonName == model.SeasonName).FirstOrDefault();
            var category = _categoryService.GetCategoryList().Where(c => c.CategoryName == model.CategoryName).FirstOrDefault();
            return new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Category = new Category()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    ParentId = category.ParentId
                },
                Season = new Season()
                {
                    SeasonId = season.SeasonId,
                    SeasonName = season.SeasonName
                },
                Count = model.Count,
                Picture = model.Picture,
                Price = model.Price,
                Description = model.Description
            };
        }
        #endregion

        public void AddProductInBox(int id)
        {
            var user = HttpContext.User.Identity.Name;
            User user2 = _userService.GetUserByLogin(user);
           int userId= user2.UserId;

            Product prod = new Product();
            foreach (Product item in _productService.GetProductLIst())
            {
                if (item.Id == id)
                {
                    prod = item;
                }
            }

            //int id = HttpContext.Request.Cookies["Name"].Value
            //COUNToRDERS
            int countProductInBasket = _orderService.GetOrderList().Where(m => m.User.UserId == userId).Count();
            int trigger = 0;
            foreach (Order order in _orderService.GetOrderList().Where(m => m.User.UserId == userId))
            {
                if (order.StatusOrder.Id != 1)
                {
                    trigger++;
                }
            }
            if (countProductInBasket == trigger)
            {
                _orderService.SaveDefaultOrder(userId);
            }

            int orderId = 1;

            foreach (Order order in _orderService.GetOrderList().Where(m => m.User.UserId == userId))
            {
                if (order.StatusOrder.Id == 1)
                {
                    orderId = order.Id;
                }
            }
            Basket basket = new Basket()
            {
                Id = 3,
                Product = new Product()
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = prod.Price
                },
                Order = new Order()
                {
                    Id= orderId
                },
                Count = 1
            };
            _basketService.AddNewItemInBox(basket);
        }
    }
}