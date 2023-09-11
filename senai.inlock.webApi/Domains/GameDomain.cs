using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// This class is for the representation of game in database
    /// </summary>
    public class GameDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O id do estúdio é obrigatório")]
        public int IdStudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime ReleaseDate { get;  set; }
        public float Price { get; set; }

        public StudioDomain? StudioDomain { get; set; }
    }
}
