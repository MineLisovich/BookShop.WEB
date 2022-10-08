using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFPickupRepository : IPickupRepository
    {
        private readonly Context _dbContext;
        public EFPickupRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Pickup> GetAll()
        {
            return _dbContext.Pickup;
        }
        public Pickup GetById(int Id)
        {
            return _dbContext.Pickup.FirstOrDefault(x => x.Id == Id);
        }

        public void SavePickup(Pickup entity)
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
        public void DeletePickup(int Id)
        {
            _dbContext.Pickup.Remove(new Pickup() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
