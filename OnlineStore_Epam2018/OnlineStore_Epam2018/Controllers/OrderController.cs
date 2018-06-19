namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using OnlineStore_Epam2018.RoleAttribut;
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
            if (roleService == null)
            {
                throw new NullReferenceException("roleService");
            }
            if (basketService == null)
            {
                throw new NullReferenceException("basketService");
            }
            _orderService = orderService;
            _userService = userService;
            _roleService = roleService;
            _basketService = basketService;
        }

        public OrderController()
        {
           
        }

        [UserFilter]
        public ActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            int userId = _userService.GetUserByLogin(user).UserId;
            var orders = _orderService.GetOrderList();
            var ordersList = orders.Select(m => this.ConvertToViewModel(m)).Where(m=>m.UserId==userId);
            return View(ordersList);
        }
        [Editor]
        public ActionResult GetAllOrders()
        {
            var ordersLIst = _orderService.GetOrderList();
            var ordersList = ConvertToViewModelList(ordersLIst);
            return View(ordersList);
        }
        [UserFilter]
        public ActionResult Details(int Id)
        {
            var orderBussines = _orderService.GetOrder(Id);
            var order = this.ConvertToViewModel(orderBussines);
            return View(order);
        }

        [UserFilter]
        public ActionResult OrderDetails(int id)
        {
            var productsBussiness = _basketService.GetProductListInBox();
            var productsSearch = productsBussiness.Where(m => m.Order.Id == id);
            var products = ConvertToProductListViewModelList(productsSearch);

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
                Price = model.Product.Price * model.Count,
                Picture = model.Product.Picture,
                Category=model.Category.CategoryName,
                Status=_orderService.GetOrderList().Where(m=>m.Id==model.Order.Id).Select(m=>m.StatusOrder.StatusOrderName).FirstOrDefault()
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
        [UserFilter]
        public ActionResult OrderInfo(int id)
        {
            var orderBussiness = _orderService.GetOrder(id);
            var order = ConvertToViewModel(orderBussiness);
            return PartialView(order);
        }
        [UserFilter]
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var order = this.ConvertToBusinesModel(model);
                    _orderService.SaveOrder(order);
                    
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Internal Errors");
                }
            }
            return View();
        }

        [UserFilter]

        public ActionResult Edit(int Id)
        {
            var order = this.ConvertToViewModel(this._orderService.GetOrder(Id));
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var order = this.ConvertToBusinesModel(model);
                    this._orderService.SaveOrder(order);
                    return RedirectToAction("GetAllOrders");
                }
                catch(Exception)
                {
                    this.ModelState.AddModelError("", "Internal Errors");
                }
            }
            return View();
        }

        [UserFilter]

        public ActionResult EditUserOrder(int Id)
        {
            var orderBussiess = _orderService.GetOrder(Id);
            var order = this.ConvertToViewModel(orderBussiess);
            
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserOrder(OrderViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    model.Status.Id = 2;
                    model.DateOrder = DateTime.Now;
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

        [UserFilter]

        public ActionResult Delete(int Id)
        {
            _orderService.DeleteOrderByOrderId(Id);
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
                    Id= model.Status.Id
                }, 
                DateOrder = model.DateOrder
            };
        }

        private OrderViewModel ConvertToViewModel(Order model)
        {
            var orderStatuses = _orderService.GetStatusOrders();
            return new OrderViewModel()
            {
                Id = model.Id,
                UserId = model.User.UserId,
                Address = model.Address,
                Status = new StatusOrder()
                {
                    Id = model.StatusOrder.Id,
                    StatusOrderName = model.StatusOrder.StatusOrderName
                },
                DateOrder = model.DateOrder,
                StatusOrders = ConvertToViewModelList(orderStatuses)
            };
        }

        private List<StatusOrder> ConvertToViewModelList(IEnumerable<StatusOrder> list)
        {
            List<StatusOrder> statuses = new List<StatusOrder>();
            foreach (StatusOrder item in list)
            {
                statuses.Add(item);
            }
            return statuses;
        }

        private List<OrderViewModel> ConvertToViewModelList(IEnumerable<Order> list)
        {
            List<OrderViewModel> orders = new List<OrderViewModel>();
            foreach (Order item in list)
            {
                orders.Add(ConvertToViewModel(item));
            }
            return orders;
        }
    }
}