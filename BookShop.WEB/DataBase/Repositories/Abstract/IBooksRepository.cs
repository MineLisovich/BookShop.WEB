using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IBooksRepository
    {
        IQueryable<Books> GetAll();
        Books GetById(int id);
        Books GetByName(string NameBook);
        void SaveBooks(Books entity);
        void DeleteBooks(int id);
    }
}
