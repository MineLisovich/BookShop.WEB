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
    public class EFBindingRepository : IBindingRepository
    {
        private readonly Context _dbContext;
        public EFBindingRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Binding> GetAll()
        {
            return _dbContext.Binding;
        }
        public Binding GetById(int Id)
        {
            return _dbContext.Binding.FirstOrDefault(x => x.Id == Id);
        }
        public Binding GetByName(string NameBinding)
        { 
            return _dbContext.Binding.FirstOrDefault(x => x.NameBinding == NameBinding); 
        }
        public void SaveBinding(Binding entity)
        {
            if (entity.Id==default)
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }
            else 
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
        public void DeleteBinding(int Id)
        {
            _dbContext.Binding.Remove(new Binding() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
