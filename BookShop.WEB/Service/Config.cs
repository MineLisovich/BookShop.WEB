using Microsoft.AspNetCore.Mvc;

namespace BookShop.WEB.Service
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
    }
}
