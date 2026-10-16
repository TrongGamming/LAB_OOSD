using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyBenhAn
{
    internal static class Db
    {
        internal static string ConnectionString
        {
            get
            {
                string test = Environment.GetEnvironmentVariable("LAB06_CONNECTION");
                return string.IsNullOrWhiteSpace(test) ? ConfigurationManager.ConnectionStrings["BenhAnDb"].ConnectionString : test;
            }
        }

        internal static OracleParameter P(string name, object value)
        {
            return new OracleParameter(name, value ?? DBNull.Value);
        }

        internal static OracleConnection Open()
        {
            var connection = new OracleConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        internal static OracleCommand Command(OracleConnection connection, OracleTransaction transaction, string sql, params OracleParameter[] parameters)
        {
            var command = new OracleCommand(sql, connection) { BindByName = true, Transaction = transaction };
            command.Parameters.AddRange(parameters);
            return command;
        }

        internal static DataTable Query(string sql, params OracleParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = Command(connection, null, sql, parameters))
            using (var adapter = new OracleDataAdapter(command))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal static object Scalar(string sql, params OracleParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = Command(connection, null, sql, parameters))
                return command.ExecuteScalar();
        }

        internal static string Id(OracleConnection connection, OracleTransaction transaction, string sequence, string prefix)
        {
            using (var command = Command(connection, transaction, "SELECT " + sequence + ".NEXTVAL FROM dual"))
                return prefix + Convert.ToInt64(command.ExecuteScalar()).ToString("000000");
        }

        internal static void Exec(OracleConnection connection, OracleTransaction transaction, string sql, params OracleParameter[] parameters)
        {
            using (var command = Command(connection, transaction, sql, parameters)) command.ExecuteNonQuery();
        }

        internal static T Atomic<T>(Func<OracleConnection, OracleTransaction, T> action)
        {
            using (var connection = Open())
            using (var transaction = connection.BeginTransaction())
            {
                try { T value = action(connection, transaction); transaction.Commit(); return value; }
                catch { transaction.Rollback(); throw; }
            }
        }
    }
}
