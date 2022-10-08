using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IFormatRepository
    {
        IQueryable<Format> GetAll();
        Format GetById(int id);
        Format GetByName(string NameFormat);
        void SaveFormat(Format entity);
        void DeleteFormat(int id);
    }
}
