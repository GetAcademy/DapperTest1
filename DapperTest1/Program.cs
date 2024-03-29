﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DapperTest1.Builder;

namespace DapperTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample.Demo1();
            return;
            TestQueries2().Wait();

            //var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=getit;Integrated Security=True;";
            //var conn = new SqlConnection(connStr);
            //var repo = new Repository<Person>(conn);
            //repo.Create(new Person() {FirstName = "Terje", LastName = "Kolderup", BirthYear = 1975}).Wait();

            //var carRepo= new CarRepository(conn);
            //var cars = carRepo.ReadAll();
        }

        static async Task TestQueries2()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TerjeTest;Integrated Security=True";
            var conn = new SqlConnection(connStr);

            var repository = new Repository<Person>(conn);
            var person = await repository.ReadOneById(1);
        }
        static async Task TestQueries()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TerjeTest;Integrated Security=True";
            var conn = new SqlConnection(connStr);

            var readMany = @"SELECT Id, FirstName, LastName, BirthYear
                             FROM Person";

            // DECLARE @Id int = 1001;
            var readOne = @"SELECT Id, FirstName, LastName, BirthYear
                            FROM Person
                            WHERE Id = @Id";

            var readOneByName = @"SELECT Id, FirstName, LastName, BirthYear
                                  FROM Person
                                  WHERE FirstName = @FirstName";

            var create = @"INSERT INTO Person (FirstName, LastName, BirthYear)
                           VALUES (@FirstName, @LastName, @BirthYear)";

            var delete = @"DELETE FROM Person WHERE Id = @Id";

            var deleteAll = @"DELETE FROM Person";

            var update = @"UPDATE Person
                           SET LastName = @LastName, FirstName = @FirstName
                           WHERE Id = @Id";

            int rowsDeleted = await conn.ExecuteAsync(deleteAll);

            int rowsInserted1 = await conn.ExecuteAsync(create, new { FirstName = "Terje", LastName = "Kolderup", BirthYear = 1975 });
            int rowsInserted2 = await conn.ExecuteAsync(create, new { FirstName = "Per", LastName = (string)null, BirthYear = 1980 });
            int rowsInserted3 = await conn.ExecuteAsync(create, new { FirstName = "Pål", LastName = (string)null, BirthYear = 1981 });

            IEnumerable<Person> persons = await conn.QueryAsync<Person>(readMany);

            Person terje = await conn.QueryFirstOrDefaultAsync<Person>(readOneByName, new { FirstName = "Terje" });

            int rowsAffected2 = await conn.ExecuteAsync(update, new { FirstName = "Petter", LastName = "Pettersen", Id = terje.Id });
            persons = await conn.QueryAsync<Person>(readMany);

            int rowsAffected3 = await conn.ExecuteAsync(delete, new { Id = terje.Id });
            persons = await conn.QueryAsync<Person>(readMany);
        }
    }
}
