[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VehicleApp.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(VehicleApp.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace VehicleApp.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Service.Common;
    using Service;
    using Repository;
    using Repository.Interfaces;
    using Repository.Models;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using Service.Service.Common;
    using Service.Service;
    using Repository.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //vehicle makes
            kernel.Bind<IVehicleMakeService>().To<VehicleMakeService>().InRequestScope();
            kernel.Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>().InRequestScope();
            kernel.Bind<VehicleDbContext>().To<VehicleDbContext>().InRequestScope();

            // vehicle models
            kernel.Bind<IVehicleModelService>().To<VehicleModelService>().InRequestScope();
            kernel.Bind<IVehicleModelRepository>().To<VehicleModelRepository>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
