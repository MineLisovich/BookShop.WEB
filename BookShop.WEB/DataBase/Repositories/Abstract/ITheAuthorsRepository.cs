using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface ITheAuthorsRepository
    {
        IQueryable<TheAuthors> GetAll();
        TheAuthors GetById(int id);
        TheAuthors GetByName(string FullName);
        void SaveTheAuthors(TheAuthors entity);
        void DeleteTheAuthors(int id);
    }
}
