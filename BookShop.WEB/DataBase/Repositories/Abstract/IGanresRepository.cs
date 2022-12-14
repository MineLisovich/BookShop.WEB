using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IGanresRepository
    {
        IQueryable<Ganres> GetAll();
        Ganres GetById(int id);
        Ganres GetByName(string NameGanre);
        void SaveGanres(Ganres entity);
        void DeleteGanres(int id);
    }
}
