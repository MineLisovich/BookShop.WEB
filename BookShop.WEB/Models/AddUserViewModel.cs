using System.ComponentModel.DataAnnotations;
namespace BookShop.WEB.Models
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "Укажите свою почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = ("Укажите свой Логин"))]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Укажите свой пароль"))]
        public string Password { get; set; }
        [Required(ErrorMessage ="Укажите id роли")]
        public string RoleID { get; set; }
        [Required(ErrorMessage = "Укажите наименование роли")]
        public string Role { get; set; }
    }
}
