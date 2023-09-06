using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// This class is for the representation of user type in database
    /// </summary>
    public class UserTypeDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do tipo de usuário é obrigatório!")]
        public string TypeName { get; set; }
    }
}
