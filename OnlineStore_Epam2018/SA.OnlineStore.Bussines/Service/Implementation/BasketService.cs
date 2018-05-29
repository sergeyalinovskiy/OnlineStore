namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepository;
        public BasketService(IRepository<Basket> basketRepository)
        {
            _basketRepository = basketRepository;
        }
        //public static List<Basket> productsInBox = new List<Basket>()
        //{
        //    new Basket()
        //    {
        //        Id=1,
        //        ProductId=1,
        //        ProductName="Инструкция по посадке и уходу",
        //        Count=1
        //    }
        //};

        public void DeleteProductInBoxById(int Id)         
        {
            _basketRepository.Delete(Id);
        }

        Basket p = new Basket();

        public void SaveProductListInBox(Basket model)   //dont working!!!!!!!!!!
        {
            _basketRepository.Create(model);
        }
             

        public void EditProductListInBox(Basket model)
        {
            _basketRepository.Update(model);
        }

        public Basket GetProductInBox(int Id)
        {
            return _basketRepository.GetById(Id);
        }

        public void AddNewItemInBox(Basket product)
        {
            _basketRepository.Create(product);
        }

        public IEnumerable<Basket> GetProductListInBox()
        {
            return _basketRepository.GetAll();
        }

    }
}