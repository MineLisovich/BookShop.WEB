using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFPublisherRepository: IPublisherRepository
    {
        private readonly Context _dbContext;
        public EFPublisherRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Publisher> GetAll()
        {
            return _dbContext.Publisher;
        }
        public Publisher GetById(int Id)
        {
            return _dbContext.Publisher.FirstOrDefault(x => x.Id == Id);
        }
        public Publisher GetByName(string ShortNamePublisher)
        {
            return _dbContext.Publisher.FirstOrDefault(x => x.ShortNamePublisher == ShortNamePublisher);
        }
        public void SavePublisher(Publisher entity)
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
        public void DeletePublisher(int Id)
        {
            _dbContext.Publisher.Remove(new Publisher() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
