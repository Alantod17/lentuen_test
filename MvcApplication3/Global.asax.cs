using NHibernate;
using NHibernate.Context;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication3
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory NHibernateSessionFactory;
        
        
        public override void Init()
        {
            base.Init();
            this.BeginRequest += MvcApplication_BeginRequest;
            this.EndRequest += MvcApplication_EndRequest;
        }

        void MvcApplication_BeginRequest(object sender, System.EventArgs e)
        {
            var session = NHibernateSessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            //throw new System.NotImplementedException();
        }

        void MvcApplication_EndRequest(object sender, System.EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(NHibernateSessionFactory);
            session.Dispose();
            //throw new System.NotImplementedException();
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);

            NHibernateSessionFactory = Configuration.NHibernateHelper.GetNhibrnateSessionFactory();
        }
    }
}