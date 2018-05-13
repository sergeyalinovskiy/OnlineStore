using SA.OnlineStore.DataAccess.Components;
using SA.OnlineStore.DataAccess.Service;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess
{
    public class DataAccessDependencyRegistry :Registry
    {
        public DataAccessDependencyRegistry()
        {
            For<IPublicityRepository>().Use<PublicityRepository>();
            For<IProductRepository>().Use<ProductRepository>();
            For<ICategoryRepository>().Use<CategoryRepository>();
            For<ISeasonRepository>().Use<SeasonRepository>();
        }
    }
}
