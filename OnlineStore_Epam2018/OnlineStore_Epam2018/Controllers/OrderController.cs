﻿namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
    using OnlineStore_Epam2018.Models;
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    #endregion

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public OrderController(IOrderService orderService, IUserService userService, IRoleService roleService)
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