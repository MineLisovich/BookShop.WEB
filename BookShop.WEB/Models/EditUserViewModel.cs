using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Введите Логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите Email")]
        public string Email { get; set; }
    }
}
