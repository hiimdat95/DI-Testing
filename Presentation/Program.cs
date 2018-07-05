using DITest.Data.Repositories;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace Presentation
{
    internal static class Program
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
            Application.Run(new Form1());
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