using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTest1.Builder
{
    class Join
    {
        public string Table { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }

        public Join(string table, string field1, string field2)
        {
            Table = table;
            Field1 = field1;
            Field2 = field2;
        }

        public override string ToString()
        {
            return $"JOIN {Table} ON {Table}.{Field1} = {Field2}\n";
        }
    }
}
