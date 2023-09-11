using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.DataTransfer
{
    public class UserTransfer
    {
        [Required(ErrorMessage = "O e-mail não foi inserido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha não foi inserida!")]
        public string Password { get; set; }
    }
}
