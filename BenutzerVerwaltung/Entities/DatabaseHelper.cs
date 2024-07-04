/*using System.Data.SqlClient;
namespace BenutzerVerwaltung.Entities
{
    public class DatabaseHelper
    {
        private string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }


        private void SaveUserToDatabase(User user)
        {
            using (var db = new DatabaseHelper("your_connection_string_here"))
            using (var conn = db.OpenConnection())
            {
                var command = new SqlCommand("INSERT INTO Users (FirstName, LastName, Email, Address, Password) VALUES (@FirstName, @LastName, @Email, @Address, @Password)", conn);

                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@Password", user.Password);  // You should consider hashing the password before saving!

                command.ExecuteNonQuery();

                // If you also need to save roles, permissions, and groups, you can do that here.
            }
        }
    }
}*/
