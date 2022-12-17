using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace BookShop.WEB.Models
{
    public class BooksViewModel
    {
        public IEnumerable<Books> Books { get; set; }
        public string serch { get; set; } 
        public SelectList TheAuthorstList { get; set; }
        public SelectList GanrestList { get; set; }
        public SelectList PublishertList { get; set; }
        public IdentityUser IdentityUser { get; set; }
      
        public IList<string> UserRoles { get; set; }
   
        public BooksViewModel()
        {
            
            UserRoles = new List<string>();
        }




    }
}
