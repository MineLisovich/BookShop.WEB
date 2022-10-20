using System.ComponentModel.DataAnnotations;

namespace BookShop.WEB.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
