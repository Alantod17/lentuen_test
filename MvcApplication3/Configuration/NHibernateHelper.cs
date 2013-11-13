using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NhibernateMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Configuration
{
    public class NHibernateHelper
    {
        public static ISessionFactory GetNhibrnateSessionFactory()
        {
            var configure = new NHibernate.Cfg.Configuration();
            configure.DataBaseIntegration(delegate(NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties dbi)
            {
                dbi.ConnectionStringName = "mvcNH";
                dbi.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
                dbi.Driver<NHibernate.Driver.Sql2008ClientDriver>();
                dbi.Timeout = 255;
            });
            configure.CurrentSessionContext<WebSessionContext>();

            configure.AddAssembly(typeof(Address).Assembly);

            return configure.BuildSessionFactory();
        }

    }
}