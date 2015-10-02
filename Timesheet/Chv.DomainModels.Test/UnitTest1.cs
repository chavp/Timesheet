using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chv.DomainModels.Test
{
    using NHibernate;
    using NHibernate.Linq;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using Chv.DomainModels.Test.Mappings;
    using System.Data.SQLite;

    [TestClass]
    public class UnitTest1
    {
        // https://www.connectionstrings.com/sqlite/

        ISessionFactory fac = null;
        [TestInitialize]
        public void setup()
        {
            fac = CreateMSSQLSessionFactory();
        }

        [TestMethod]
        public void TestMethod1()
        {
            using (var session = fac.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var newParty = new Person("AAA");

                session.Save(newParty);

                tran.Commit();
            }
        }

        [TestMethod]
        public void select_party()
        {
            using (var session = fac.OpenSession())
            {
                var parties = (from x in session.Query<Party>()
                               select x).ToList();

                foreach (var item in parties)
                {
                    Console.WriteLine("Name - {0} - {1}", item.Name, item.Children);
                }
            }
        }

        [TestMethod]
        public void create_organization_party()
        {
            using (var session = fac.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var dd = (from x in session.Query<Department>()
                          where x.Name == "DD"
                           select x).Single();

                var persons = (from x in session.Query<Person>()
                               select x).ToList();

                foreach (var item in persons)
                {
                    item.Department = dd;
                }

                tran.Commit();
            }
        }


        [TestMethod]
        public void create_department_party()
        {
            using (var session = fac.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var dd = new Department("DD");

                session.Save(dd);

                var gg = (from x in session.Query<Company>()
                          where x.Name == "GG"
                          select x).Single();

                dd.Parent = gg;

                tran.Commit();
            }
        }

        [TestMethod]
        public void set_parent()
        {
            using (var session = fac.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var aaa = (from x in session.Query<Party>()
                               where x.Name == "AAA"
                               select x).Single();

                //var bbb = (from x in session.Query<Party>()
                //           where x.Name == "BBB"
                //           select x).Single();

                //aaa.Parent = bbb;


                tran.Commit();
            }
        }

        [TestMethod]
        public void delete_party()
        {
            using (var session = fac.OpenSession())
            using (var tran = session.BeginTransaction())
            {
                var parties = (from x in session.Query<Party>()
                               select x).ToList();

                foreach (var party in parties)
                {
                    session.Delete(party);
                }

                tran.Commit();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            SQLiteConnection.ClearAllPools();

        }

        public static ISessionFactory CreateMSSQLSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .ConnectionString(c => c.FromConnectionStringWithKey("MyConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonMap>())
                .ExposeConfiguration(TreatConfiguration)
                .BuildSessionFactory();
        }

        //public static ISessionFactory CreateMSSQLSessionFactory()
        //{
        //    return Fluently.Configure()
        //        .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PartyMap>())
        //        .ExposeConfiguration(TreatConfiguration)
        //        .BuildSessionFactory();
        //}

        public static void TreatConfiguration(Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }
    }
}
