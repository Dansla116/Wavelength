[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Wavelength.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Wavelength.App_Start.NinjectWebCommon), "Stop")]

namespace Wavelength.App_Start {
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Wavelength.BLL.DIResolver;
    using Wavelength.BLL.Services;
    using Wavelength.DAL.DomainModels;
    using Wavelength.DAL.Repository;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System.Collections.Generic;

    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop() {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                var modules = new List<INinjectModule>
                {
                    new BLLModule(),
                    new DALModule()
                };

                kernel.Load(modules);
                RegisterServices(kernel);
                return kernel;
            } catch {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            kernel.Bind<IEntity>().ToSelf().InRequestScope();
        }
    }
}