using OnlineStore_Epam2018.Models;
using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStore_Epam2018.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public OrderController()
        {
           
        }
        // GET: Order
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
                UserId = model.UserId,
                ProductListId = model.ProductListId,
                Address = model.Address,
                StatusId = model.StatusId,
                DateOrder = model.DateOrder
            };
        }

        private OrderViewModel ConvertToViewModel(Order model)
        {
            return new OrderViewModel()
            {
                Id = model.Id,
                UserId=model.UserId,
                ProductListId=model.ProductListId,
                Address=model.Address,
                StatusId=model.StatusId,
                DateOrder=model.DateOrder
            };
        }
    }
}