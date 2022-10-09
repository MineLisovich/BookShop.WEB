using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Укажите свою почту")]
        public string Email { get; set; }
        [Required(ErrorMessage =("Укажите своё Имя"))]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Укажите свой пароль"))]
        [UIHint("password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
