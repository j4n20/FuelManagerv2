using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace SupremeLollipopService
{
    public static class NHibernateHelper
    {
        private static ISessionFactory mSessionFactory { get; set; }
        private static string fileName = "../../Data/database.db";
        private static string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string dbPath = Path.Combine(executableLocation, fileName);
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (mSessionFactory == null)
                    InitializeSessionFactory();

                return mSessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void InitializeSessionFactory()
        {
            mSessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(dbPath).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
        }
    }
}