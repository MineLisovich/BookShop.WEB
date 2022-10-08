using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFImporterRepository : IImporterRepository
    {
        private readonly Context _dbContext;
        public EFImporterRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Importer> GetAll()
        {
            return _dbContext.Importer;
        }
        public Importer GetById(int Id)
        {
            return _dbContext.Importer.FirstOrDefault(x => x.Id == Id);
        }
        public Importer GetByName(string FullNameImporter)
        {
            return _dbContext.Importer.FirstOrDefault(x => x.FullNameImporter == FullNameImporter);
        }
        public void SaveImporter(Importer entity)
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
        public void DeleteImporter(int Id)
        {
            _dbContext.Importer.Remove(new Importer() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
