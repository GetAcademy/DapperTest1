using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace DapperTest1
{
    public class PersonRepository2 : Repository<Person>
    {
        public PersonRepository2(SqlConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Person>> ReadYoungerThan(int birthYearMin)
        {
            var sql = @"SELECT Id, FirstName, LastName, BirthYear
                        FROM Person WHERE BirthYear > @BirthYearMin";
            return await _connection.QueryAsync<Person>(sql, new { BirthYearMin = birthYearMin });
        }
    }
}
