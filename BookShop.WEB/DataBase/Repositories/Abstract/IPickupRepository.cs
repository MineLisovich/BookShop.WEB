using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IPickupRepository
    {
        IQueryable<Pickup> GetAll();
        Pickup GetById(int id);
        void SavePickup(Pickup entity);
        void DeletePickup(int id);
    }
}
