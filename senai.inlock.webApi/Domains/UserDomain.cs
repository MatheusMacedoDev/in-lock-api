using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// This class is for the representation of user in database
    /// </summary>
    public class UserDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir um tipo de usuário !")]
        public int IdUserType { get; set; }

        [Required(ErrorMessage = "O usuário deve possuir e-mail!")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
