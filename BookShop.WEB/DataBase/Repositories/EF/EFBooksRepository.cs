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
    public class EFBooksRepository : IBooksRepository
    {
        private readonly Context _dbContext;
        public EFBooksRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Books> GetAll()
        {
            return _dbContext.Books;
        }
        public Books GetById(int Id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == Id);
        }
        public Books GetByName(string NameBook)
        {
            return _dbContext.Books.FirstOrDefault(x => x.NameBook == NameBook);
        }
        public void SaveBooks(Books entity)
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
        public void DeleteBooks(int Id)
        {
            _dbContext.Books.Remove(new Books() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
