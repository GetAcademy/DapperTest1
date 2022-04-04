using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTest1.Builder
{
    class Sample
    {
        public static void Demo1()
        {
            var sql = new SqlBuilder()
                    .AddField("FirstName")
                    .AddField("LastName")
                    .AddField("Age")
                    .AddField("City")
                    .SetPrimaryTable("Person")
                    .AddJoin("Cities", "Zip", "Zip")
                    .ToString()
                ;
        }
    }
}
