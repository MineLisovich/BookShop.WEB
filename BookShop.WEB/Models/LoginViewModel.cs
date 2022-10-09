using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Укажите свой логин")]
        
        public string UserName { get; set; }
        [Required(ErrorMessage =("Укажите свой пароль"))]
        [UIHint("password")]
        public string Password { get; set; }    

        public bool RememberMe { get; set; }
    }
}
