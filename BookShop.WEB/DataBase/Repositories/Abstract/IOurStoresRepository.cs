using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IOurStoresRepository
    {
        IQueryable<OurStores> GetAll();
        OurStores GetById(int id);
        void SaveOurStores(OurStores entity);
        void DeleteOurStores(int id);
    }
}
