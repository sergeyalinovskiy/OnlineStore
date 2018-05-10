
using SA.OnlineStore.Common.Logger;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SA.OnlineStore.Common
{
    public class CommonDependencyRegistry :Registry
    {
        public CommonDependencyRegistry()
        {
            ForSingletonOf<ICommonLogger>().Use<CommonLogger>();
        }
    }
}
