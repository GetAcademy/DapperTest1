using System.Collections.Generic;

namespace DapperTest1.Builder
{
    class SqlBuilder
    {
        private List<string> _fields;
        private string _primaryTable;
        private List<Join> _joins;

        public SqlBuilder()
        {
            _fields = new List<string>();
            _joins = new List<Join>();
        }

        public SqlBuilder AddField(string name)
        {
            _fields.Add(name);
            return this;
        }

        public SqlBuilder SetPrimaryTable(string name)
        {
            _primaryTable = name;
            return this;
        }

        public SqlBuilder AddJoin(string table, string field1, string field2)
        {
            _joins.Add(new Join(table, field1, field2));
            return this;
        }

        public override string ToString()
        {
            var sql = $@"
                SELECT {string.Join(',', _fields)}
                FROM {_primaryTable}
                ";
            foreach (var join in _joins)
            {
                sql += join.ToString();
            }

            return sql;
        }

    }
}
