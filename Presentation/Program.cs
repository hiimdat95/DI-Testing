using DITest.Data.Repositories;
using SimpleInjector;
using System;
using System.Windows.Forms;
using Ninject;

using Ninject.Extensions.Conventions;
using DITest.Data.Infrastructure;
using System.Data.Entity;
using DITest.Service;

namespace Presentation
{
    internal  class Program 
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var kernel = new StandardKernel())
            {
                kernel.Bind(x => x.FromAssembliesMatching("DITest.*")
                                    .SelectAllClasses()
                                    .BindAllInterfaces());
                //kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
                //kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
                //kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
          //.WithConstructorArgument("context", f => new DbContext("DITestConnection"));

                kernel.Bind(x => x.FromThisAssembly()
                                    .SelectAllInterfaces()
                                    .EndingWith("Factory")
                                    .BindToFactory()
                                    .Configure(c => c.InSingletonScope()));

                var mainForm = kernel.Get<Form1>();
                Application.Run(mainForm);
            }
        }
        private static void Bootstrap()
        {
            //Create the container as usual
            container = new Container();
            //Register your types, for instance
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Singleton);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Singleton);

        }
    }
}