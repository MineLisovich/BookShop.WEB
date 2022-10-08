using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFTheAuthorsRepository : ITheAuthorsRepository
    {
        private readonly Context _dbContext;
        public EFTheAuthorsRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TheAuthors> GetAll()
        {
            return _dbContext.TheAuthors;
        }
        public TheAuthors GetById(int Id)
        {
            return _dbContext.TheAuthors.FirstOrDefault(x => x.Id == Id);
        }
        public TheAuthors GetByName(string FullName)
        {
            return _dbContext.TheAuthors.FirstOrDefault(x => x.FullName == FullName);
        }
        public void SaveTheAuthors(TheAuthors entity)
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
        public void DeleteTheAuthors(int Id)
        {
            _dbContext.TheAuthors.Remove(new TheAuthors() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
