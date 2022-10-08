using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFOurStoresRepository : IOurStoresRepository
    {
        private readonly Context _dbContext;
        public EFOurStoresRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<OurStores> GetAll()
        {
            return _dbContext.OurStores;
        }
        public OurStores GetById(int Id)
        {
            return _dbContext.OurStores.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveOurStores(OurStores entity)
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
        public void DeleteOurStores(int Id)
        {
            _dbContext.OurStores.Remove(new OurStores() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
