using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private string connectionString = "Data Source = NOTE17-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public void Create(StudioDomain studio)
        {
            throw new NotImplementedException();
        }

        public List<StudioDomain> ListAll()
        {
            List<StudioDomain> studios = new List<StudioDomain>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Studio";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StudioDomain studio = new StudioDomain()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };

                        studios.Add(studio);
                    }
                }
            }

            return studios;
        }
    }
}
