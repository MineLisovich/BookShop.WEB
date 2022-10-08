using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFGanresRepository : IGanresRepository
    {
        private readonly Context _dbContext;
        public EFGanresRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Ganres> GetAll()
        {
            return _dbContext.Ganres;
        }
        public Ganres GetById(int Id)
        {
            return _dbContext.Ganres.FirstOrDefault(x => x.Id == Id);
        }
        public Ganres GetByName(string NameGanre)
        {
            return _dbContext.Ganres.FirstOrDefault(x => x.NameGanre == NameGanre);
        }
        public void SaveGanres(Ganres entity)
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
        public void DeleteGanres(int Id)
        {
            _dbContext.Ganres.Remove(new Ganres() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
