using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookShop.WEB.Models
{
    public class FeedbackViewModel
    {
        [Required (ErrorMessage ="Укажите свой Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required (ErrorMessage ="Введите ваше сообщение")]
        public string Message { get; set; }


        public IdentityUser IdentityUser { get; set; }

        public IList<string> UserRoles { get; set; }

        public FeedbackViewModel()
        {

            UserRoles = new List<string>();
        }

    }
}
