using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace WebAPI.Business
{
    public class NHibernateManager
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CreateSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder =>
                {
                    builder.Database("drake_mnt");
                    builder.Server(".");
                    builder.TrustedConnection();
                }
                )).Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<NHibernateManager>()
                )
                .BuildSessionFactory();
            }

            return _sessionFactory;
        }
    }
}