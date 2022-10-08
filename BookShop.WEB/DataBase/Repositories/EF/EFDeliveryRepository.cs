using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFDeliveryRepository : IDeliveryRepository
    {
        private readonly Context _dbContext;
        public EFDeliveryRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Delivery> GetAll()
        {
            return _dbContext.Delivery;
        }
        public Delivery GetById(int Id)
        {
            return _dbContext.Delivery.FirstOrDefault(x => x.Id == Id);
        }
        
        public void SaveDelivery(Delivery entity)
        {
            if (entity.Id == default)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
        public void DeleteDelivery(int Id)
        {
            _dbContext.Delivery.Remove(new Delivery() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
