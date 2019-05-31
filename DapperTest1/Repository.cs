using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;

namespace DapperTest1
{
    public class Repository<T> where T : class
    {
        protected readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> Create(T obj)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"INSERT INTO {type.Name} ({GetParams(props)}) VALUES ({GetParams(props, true)})";
            return await _connection.ExecuteAsync(sql, obj);

        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"SELECT Id, {GetParams(props)} FROM {type.Name}";
            return await _connection.QueryAsync<T>(sql);
        }

        public async Task<IEnumerable<T>> ReadOneById(int id)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"SELECT Id, {GetParams(props)} FROM {type.Name} WHERE Id = @Id";
            return await _connection.QueryAsync<T>(sql, new { Id = id });
        }

        public async Task<int> Update(Person person)
        {
            var type = typeof(T);
            var props = type.GetProperties();
            var sql = $"UPDATE {type.Name} SET {GetSetters(props)} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, person);
        }

        public async Task<int> Delete(T obj = null, int? id = null)
        {
            var type = typeof(T);
            var sql = $"DELETE FROM {type.Name} WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, obj ?? (object)new { Id = id.Value });
        }

        private static string GetParams(PropertyInfo[] props, bool includeAt = false)
        {
            return string.Join(',', props.Where(p => p.Name != "Id").Select(p => (includeAt ? "@" : "") + p.Name));
        }
        private static string GetSetters(PropertyInfo[] props)
        {
            return string.Join(',', props.Where(p => p.Name != "Id").Select(p => p.Name + " = @" + p.Name));
        }
    }
}
