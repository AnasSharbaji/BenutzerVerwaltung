using System;
using System.Data.SqlClient;

public class DatabaseConnection : IDisposable
{
    private readonly string _connectionString;
    private SqlConnection _connection;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection OpenConnection()
    {
        if (_connection == null)
        {
           // _connection = new SqlConnection(_connectionString);
        }

        if (_connection.State == System.Data.ConnectionState.Closed)
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it, throw it to a higher level, etc.)
                Console.WriteLine($"Error opening database connection: {ex.Message}");
                throw;  // rethrowing the exception for higher-level handling
            }
        }

        return _connection;
    }

    public void CloseConnection()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

    public void Dispose()
    {
        CloseConnection();
        _connection?.Dispose();
    }
}
