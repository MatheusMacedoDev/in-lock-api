using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// This class is for the representation of studio in database
    /// </summary>
    public class StudioDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public int Name { get; set; }
    }
}
