using DITest.Data.Repositories;
using DITest.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
            Bind<IProductCategoryService>().To<ProductCategoryService>().InSingletonScope();

            //Kernel.Load(new NinjectModule());
        }
    }
}
