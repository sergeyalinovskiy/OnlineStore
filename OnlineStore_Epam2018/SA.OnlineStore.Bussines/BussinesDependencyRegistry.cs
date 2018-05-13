﻿using SA.OnlineStore.Bussines.Components;
using SA.OnlineStore.Bussines.Service;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines
{
     public class BussinesDependencyRegistry : Registry 
    {
        public BussinesDependencyRegistry()
        {
            For<IProductService>().Use<ProductService>();
            For<IOrderService>().Use<OrderService>();
            For<ICategoryService>().Use<CategoryService>();
            For<ISeasonService>().Use<SeasonService>();
            For<ISearchService>().Use<SearchSeervice>();
            For<IProductListService>().Use<ProductListService>();
        }
    }
}