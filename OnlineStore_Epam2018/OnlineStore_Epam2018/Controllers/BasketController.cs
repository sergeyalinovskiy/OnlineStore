namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    #endregion

    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrderService _orderService;

        public BasketController()
        {

        }

        public BasketController(IBasketService productListService, IUserService userService, IRoleService roleService, IOrderService orderService)
        {
            if (productListService == null)
            {
                throw new NullReferenceException("productListService");
            }
            if (userService == null)
            {
                throw new NullReferenceException("userService");
            }
            if (roleService == null)
            {
                throw new NullReferenceException("roleService");
            }
            _basketService = productListService;
            _userService = userService;
            _roleService = roleService;
            _orderService = orderService;
        }

        public ActionResult Delete(int Id)
        {
            _basketService.DeleteProductInBoxById(Id);
            return RedirectToAction("Index","Order");
        }
        
        public ActionResult Save(BasketViewModel model)
        {
            Basket prodInBasket = ConvertToProductListModel(model);
            _basketService.SaveProductListInBox(prodInBasket);
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var product = this.ConvertToProductViewModel(_basketService.GetProductInBox(Id));
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(BasketViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var prod = ConvertToProductListModel(model);
                    _basketService.EditProductListInBox(prod);
                   
                    return RedirectToAction("Details", new { Id = model.Id });
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
            BasketViewModel product = this.ConvertToProductViewModel(_basketService.GetProductInBox(id));
            return View(product);
        }

        public ActionResult Index()
        {
            var products = ConvertToProductListViewModelList(_basketService.GetProductListInBox());
            return View(products);
        }

       

        public BasketViewModel ConvertToProductViewModel(Basket model)
        {
            return new BasketViewModel
            {
                Id = model.Id,
                OrderId = model.Order.Id,
                ProductId = model.Product.Id,
                ProductName = model.Product.Name,
                Count = model.Count,
                Price = model.Product.Price,
                Category=model.Product.Category.CategoryName
            };
        }

        public Basket ConvertToProductListModel(BasketViewModel model)
        {
            return new Basket
            {
                Id = model.Id,
                Order= new Order()
                {
                    Id = model.OrderId,
                },
                Product= new Product()
                {
                    Id = model.ProductId,
                    Name=model.ProductName,
                    Price = model.Price,
                    Category = new Category()
                    {
                        CategoryName=model.Category
                    }
                },
                Count = model.Count
            };
        }

        public BasketViewModel ConvertToProductListViewModel(Basket model)
        {
            return new BasketViewModel
            {
                Id = model.Id,
                OrderId = model.Order.Id,
                ProductId = model.Product.Id,
                ProductName = model.Product.Name,
                Count = model.Count,
                Price = model.Product.Price,
                Picture=model.Product.Picture
            };
        }

        public List<BasketViewModel> ConvertToProductListViewModelList(IEnumerable<Basket> modelList)
        {
            List<BasketViewModel> convertProductList = new List<BasketViewModel>();

            foreach (var item in modelList)
            {
                convertProductList.Add(ConvertToProductListViewModel(item));
            }
            return convertProductList;
        }
    }
}