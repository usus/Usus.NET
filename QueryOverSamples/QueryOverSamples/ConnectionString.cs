using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Data.SqlServerCe;
using System.IO;

namespace QueryOverSamples
{
    public class ConnectionString
    {
        public string DatebasePath { get; private set; }

        public ConnectionString(string databasePath)
        {
            DatebasePath = databasePath;
        }

        public override string ToString()
        {
            return "Data Source=" + DatebasePath;
        }
    }

    public static class ConnectionStringExtensions
    {
        public static void CreateDatabase(this ConnectionString connectionString, Configuration config)
        {
            if (File.Exists(connectionString.DatebasePath))
                File.Delete(connectionString.DatebasePath);

            using (var engine = new SqlCeEngine(connectionString.ToString()))
                engine.CreateDatabase();

            var schemaExport = new SchemaExport(config);
            schemaExport.Execute(false, true, false);
        }
    }
}
