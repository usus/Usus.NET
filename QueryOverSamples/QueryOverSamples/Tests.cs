using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;

namespace QueryOverSamples
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Table("Person");
        }
    }

    [TestClass]
    public class Tests
    {
        private static string CreateDatabase()
        {
            string database = "..\\..\\Database.sdf";
            string connectionString = "Data Source=" + database;

            if (File.Exists(database))
                File.Delete(database);

            using (var engine = new SqlCeEngine(connectionString))
                engine.CreateDatabase();

            using (var connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                var createTablePerson = @"CREATE TABLE Person
                                        (
                                            Id int IDENTITY(1,1) NOT NULL,
                                            Name nvarchar(255),
                                            PRIMARY KEY(Id)
                                        )";
                using (var command = new SqlCeCommand(createTablePerson, connection))
                    command.ExecuteNonQuery();
            }

            return connectionString;
        }

        [TestMethod]
        public void CreateDatabaseAndConnectibility()
        {
            var connectionString = CreateDatabase();
            var config = Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>())
                .BuildConfiguration();
            var sessions = config.BuildSessionFactory();

            using (var session = sessions.OpenSession())
            {
                session.Save(new Person { Name = "Max" });

                var query = session.QueryOver<Person>();
                var persons = query.List();

                Assert.IsTrue(persons.Any(p => p.Name == "Max"));
            }
        }
    }
}
