using Unity;
using System.Web.Mvc;
using Unity.Mvc5;
using Company.Services.IServices;
using Company.Repository.IMP_Repository;
using Company.Services.IMP_Services;
using Company.Repository;
using Company.Repository.IRepository;

namespace Company.App_Start
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICompany, CompanyConcrete>();
            container.RegisterType<IDept, DeptConcrete>();
            container.RegisterType<OurdbContext, OurdbContext>();
            container.RegisterType<ICompanyService, CompanyServiceConcrete>();
            container.RegisterType<OurdbContext, OurdbContext>();
            RegisterTypes(container);

            return container;
        }
    }
}