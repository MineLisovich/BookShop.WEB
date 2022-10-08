using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFFormatRepository : IFormatRepository
    {
        private readonly Context _dbContext;
        public EFFormatRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Format> GetAll()
        {
            return _dbContext.Format;
        }
        public Format GetById(int Id)
        {
            return _dbContext.Format.FirstOrDefault(x => x.Id == Id);
        }
        public Format GetByName(string NameFormat)
        {
            return _dbContext.Format.FirstOrDefault(x => x.NameFormat == NameFormat);
        }
        public void SaveFormat(Format entity)
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
        public void DeleteFormat(int Id)
        {
            _dbContext.Format.Remove(new Format() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
