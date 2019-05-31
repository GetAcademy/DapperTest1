using System.Data.SqlClient;

namespace DapperTest1
{
    public class CarRepository : Repository<Car>
    {
        public CarRepository(SqlConnection connection) : base(connection)
        {
        }
    }
}
