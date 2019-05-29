using System.Data.SqlClient;
using Dapper;

namespace DapperTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=getit;Integrated Security=True;";
            var conn = new SqlConnection(connStr);

            var readMange = @"SELECT Id, Fornavn, Etternavn, Fødselsår
                              FROM Person";

            // DECLARE @Id int = 1001;
            var readEn = @"SELECT Id, Fornavn, Etternavn, Fødselsår
                           FROM Person
                           WHERE Id = @Id";

            var create = @"INSERT INTO Person(Fornavn, Etternavn, Fødselsår)
                        VALUES('Terje', 'Kolderup', 1975)";

            var delete = @"DELETE FROM Person WHERE Id = @Id";

            var update = @"UPDATE Person
                           SET Etternavn = 'Pettersen', Fornavn = 'Petter'
                           WHERE Id = @Id";

            conn.Query<Person>()
        }
    }
}
