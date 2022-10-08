using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IDeliveryRepository
    {
        IQueryable<Delivery> GetAll();
        Delivery GetById(int id);
        void SaveDelivery(Delivery entity);
        void DeleteDelivery(int id);
    }
}
