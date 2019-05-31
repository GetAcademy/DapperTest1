using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace DapperTest1
{
    public class PersonRepository
    {
        private readonly SqlConnection _connection;

        public PersonRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(Person person)
        {
            var sql = @"INSERT INTO Person (FirstName, LastName, BirthYear)
                        VALUES (@FirstName, @LastName, @BirthYear)";
            return await _connection.ExecuteAsync(sql, person);
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear
                        FROM Person";
            return await _connection.QueryAsync<Person>(sql);
        }

        public async Task<IEnumerable<Person>> ReadYoungerThan(int birthYearMin)
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear
                        FROM Person WHERE BirthYear > @BirthYearMin";
            return await _connection.QueryAsync<Person>(sql, new { BirthYearMin = birthYearMin });
        }

        public async Task<IEnumerable<Person>> ReadOneById(int id)
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear
                        FROM Person WHERE Id = @Id";
            return await _connection.QueryAsync<Person>(sql, new { Id = id });
        }

        public async Task<int> Update(Person person)
        {
            var sql = @"UPDATE Person
                        SET LastName = @LastName, FirstName = @FirstName, BirthYear = @BirthYear
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, person);
        }

        public async Task<int> Delete(Person person = null, int? id = null)
        {
            var sql = @"DELETE FROM Person
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, person ?? (object)new {Id=id.Value});
        }
    }
}
