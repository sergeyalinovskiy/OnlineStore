﻿using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders = new List<Order>() {
            new Order() {Id=1,
                         UserId =1,
                         ProductListId=1,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            } ,
            new Order() {Id=1,
                         UserId =2,
                         ProductListId=3,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            } ,
            new Order() {Id=1,
                         UserId =3,
                         ProductListId=2,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            }};

        public void DeleteOrderByOrderId(int Id)
        {
            _orders.RemoveAt(Id);
        }

        public Order GetOrder(int Id)
        {
            return _orders.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrderList()
        {
            return _orders;
        }

        public void SaveOrder(Order model)
        {
            _orders.Add(new Order
            {
                Id = model.Id,
                UserId=model.UserId,
                StatusId=model.StatusId,
                ProductListId=model.ProductListId,
                Address=model.Address,
                DateOrder=model.DateOrder
            });
        }

        public void EditOrder(Order model)
        {
            _orders[model.Id].StatusId = model.StatusId;
            _orders[model.Id].ProductListId = model.ProductListId;
            _orders[model.Id].Address = model.Address;
            _orders[model.Id].DateOrder = model.DateOrder;
            _orders[model.Id].UserId = model.UserId;
        }
    }
}