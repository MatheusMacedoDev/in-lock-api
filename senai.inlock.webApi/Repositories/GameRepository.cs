using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class GameRepository : IGameRepository
    {
        private string connectionString = "Data Source = NOTE17-S14; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public List<GameDomain> FindAll()
        {
            List<GameDomain> games = new List<GameDomain>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT *, Studio.Name AS StudioName From Game INNER JOIN Studio ON Game.IdStudio = Studio.Id;";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        GameDomain game = new GameDomain
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdStudio = Convert.ToInt32(reader["IdStudio"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString()),
                            Price = float.Parse(reader["Price"].ToString()),
                            StudioDomain = new StudioDomain()
                            {
                                Id = Convert.ToInt32(reader["IdStudio"]),
                                Name = reader["StudioName"].ToString()
                            }
                        };

                        games.Add(game);
                    }
                }
            }

            return games;
        }
    }
}
