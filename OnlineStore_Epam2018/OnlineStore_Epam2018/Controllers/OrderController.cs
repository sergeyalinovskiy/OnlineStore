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

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderService orderService, IUserService userService, IRoleService roleService, IBasketService basketService)
        {
            if (orderService == null)
            {
                throw new NullReferenceException("orderService");
            }
            if (userService == null)
            {
                throw new NullReferenceException("userService");
            }
            _orderService = orderService;
            _userService = userService;
            _roleService = roleService;
            _basketService = basketService;
        }

        public OrderController()
        {
           
        }

        public ActionResult Index()
        {
            var ordersList = this._orderService.GetOrderList().Select(o => this.ConvertToViewModel(o));
            return View(ordersList);
        }
        
        public ActionResult Details(int Id)
        {
            var order = this.ConvertToViewModel(this._orderService.GetOrder(Id));
            return View(order);
        }


        public ActionResult OrderDetails(int id)
        {
            var products = ConvertToProductListViewModelList(_basketService.GetProductListInBox().Where(m => m.Order.Id == id));

            return View(products);
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
                Picture = model.Product.Picture
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

        public ActionResult OrderInfo(int id)
        {
            var product = ConvertToViewModel(_orderService.GetOrder(id));
            return PartialView(product);
        }
        
        public ActionResult UserInfo(int id)
        {
            int userId = 0;
            foreach (var a in _orderService.GetOrderList().Where(m => m.Id == id))
            {
                userId = a.User.UserId;
            }
            var user = ConvertUserToViewModel(_userService.GetUserById(userId));
            return PartialView(user);
        }

        public UserViewModel ConvertUserToViewModel(User model)
        {
            var role = _roleService.GetRoleList().Where(c => c.RoleId == model.Role.RoleId).FirstOrDefault();
            return new UserViewModel()
            {
                UserId = model.UserId,
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                LastName = model.LastName,
                EmailAddress = model.Email.EmailAddress,
                PhoneNumber = model.Phone.PhoneNumber,
                RoleName = role.Name
            };
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var order = this.ConvertToBusinesModel(model);
                    this._orderService.SaveOrder(order);
                    
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    this.ModelState.AddModelError("", "Internal Errors");
                }
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var order = this.ConvertToViewModel(this._orderService.GetOrder(Id));
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var order = this.ConvertToBusinesModel(model);
                    this._orderService.EditOrder(order);
                    return RedirectToAction("Detail", new { Id = model.Id });
                }
                catch(Exception)
                {
                    this.ModelState.AddModelError("", "Internal Errors");
                }
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            this._orderService.DeleteOrderByOrderId(Id);
            return RedirectToAction("Index");
        }

        private Order ConvertToBusinesModel(OrderViewModel model)
        {
            return new Order()
            {
                Id = model.Id,
                User=new User()
                {
                    UserId = model.UserId
                },
                Address = model.Address,
                StatusOrder =new StatusOrder()
                {
                    Id= model.StatusId
                }, 
                DateOrder = model.DateOrder
            };
        }

        private OrderViewModel ConvertToViewModel(Order model)
        {
            return new OrderViewModel()
            {
                Id = model.Id,
                UserId=model.User.UserId,
                Address=model.Address,
                StatusId=model.StatusOrder.Id,
                DateOrder=model.DateOrder
            };
        }
    }
}