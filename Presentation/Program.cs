using Autofac;
using Autofac.Features.ResolveAnything;
using DITest.Data;
using DITest.Data.Infrastructure;
using DITest.Data.Repositories;
using DITest.Service;
using SimpleInjector;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace Presentation
{
    internal class Program
    {
        private static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


      
        #region Autofac
        private static void Main()
        {

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerDependency();
            builder.RegisterType<DITestDbContext>().AsSelf().InstancePerDependency();
            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

            // Services
            builder.RegisterAssemblyTypes(typeof(ProductCategoryService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerDependency();
            Autofac.IContainer container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<Form1>());
            
        }

        #endregion Autofac













        //private static void Main()
        //{

        //        IUnityContainer container = new UnityContainer();
        //    //container.AddNewExtensionIfNotPresent<EnterpriseLibraryCoreExtension>();
        //    container.RegisterType<IUnitOfWork, UnitOfWork>();
        //        container.RegisterType<IDbFactory, DbFactory>();
        //        container.RegisterType<IProductCategoryRepository, ProductCategoryRepository>();
        //        container.RegisterType<IProductCategoryService, ProductCategoryService>();

        //        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        //        Application.Run(container.Resolve<Form1>());
        //}
        //private  void ConfigAutofac(/*IAppBuilder app*/)
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
        //    // Register your Web API controllers.
        //    //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        //    builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

        //    builder.RegisterType<DITestDbContext>().AsSelf().InstancePerRequest();
        //    //builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

        //    // Repositories
        //    builder.RegisterAssemblyTypes(typeof(ProductCategoryRepository).Assembly)
        //        .Where(t => t.Name.EndsWith("Repository"))
        //        .AsImplementedInterfaces().InstancePerRequest();

        //    // Services
        //    builder.RegisterAssemblyTypes(typeof(ProductCategoryService).Assembly)
        //       .Where(t => t.Name.EndsWith("Service"))
        //       .AsImplementedInterfaces().InstancePerRequest();

        //    Autofac.IContainer container = builder.Build();
        //    //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        //    ////Set the WebApi DependencyResolver
        //    //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        //}
        //public  void RegisterAllModules(this ContainerBuilder builder)
        //{
        //    var moduleType = typeof(Autofac.Module);
        //    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic))
        //    {
        //        foreach (var type in assembly.GetTypes().Where(moduleType.IsAssignableFrom))
        //        {
        //            var module = (Autofac.Module)Activator.CreateInstance(type);
        //            builder.RegisterModule(module);
        //        }
        //    }
        //}

        #region NInject

        //private static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    using (var kernel = new StandardKernel())
        //    {
        //        kernel.Bind(x => x.FromAssembliesMatching("DITest.*")
        //                            .SelectAllClasses()
        //                            .BindAllInterfaces());
        //        //kernel.Bind<IProductCategoryRepository>().To<ProductCategoryRepository>();
        //        //kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
        //        //kernel.Bind<IProductCategoryService>().To<ProductCategoryService>();
        //        kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        //        //.WithConstructorArgument("context", f => new DbContext("DITestConnection"));

        //        kernel.Bind(x => x.FromThisAssembly()
        //                            .SelectAllInterfaces()
        //                            .EndingWith("Factory")
        //                            .BindToFactory()
        //                            .Configure(c => c.InSingletonScope()));

        //        var mainForm = kernel.Get<Form1>();
        //        Application.Run(mainForm);
        //    }
        //}

        #endregion NInject

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