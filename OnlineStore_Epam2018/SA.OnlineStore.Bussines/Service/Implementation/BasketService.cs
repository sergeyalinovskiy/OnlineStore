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

        public void DeleteProductInBoxById(int Id)         
        {
            if (Id > 0)
            {
                _basketRepository.Delete(Id);
            }
        }

        public void SaveProductListInBox(Basket model)   
        {
            if (model != null)
            {
                _basketRepository.Create(model);
            }
            
        }
             

        public void EditProductListInBox(Basket model)
        {
            if (model != null)
            {
                _basketRepository.Update(model);
            }
        }

        public Basket GetProductInBox(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            return _basketRepository.GetById(Id);
        }

        public void AddNewItemInBox(Basket product)
        {
            if (product != null)
            {
                _basketRepository.Create(product);
            }
        }

        public IEnumerable<Basket> GetProductListInBox()
        {
            return _basketRepository.GetAll();
        }

    }
}