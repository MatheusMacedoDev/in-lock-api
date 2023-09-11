using senai.inlock.webApi.DataTransfer;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string connectionString = "Data Source = NOTE17-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public UserDomain login(UserTransfer findedUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, IdUserType, Email FROM [User] WHERE Email = @Email AND [Password] = @Password";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", findedUser.Email);
                    command.Parameters.AddWithValue("@Password", findedUser.Password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UserDomain user = new UserDomain()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdUserType = Convert.ToInt32(reader["IdUserType"]),
                            Email = reader["Email"].ToString()
                        };

                        return user;
                    }
                }
            }

            return null;
        }
    }
}
