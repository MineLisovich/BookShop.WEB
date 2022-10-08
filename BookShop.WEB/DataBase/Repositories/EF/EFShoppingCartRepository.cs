using BookShop.WEB.DataBase.Entities;
using BookShop.WEB.DataBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.WEB.DataBase.Repositories.EF
{
    public class EFShoppingCartRepository : IShoppingCartRepository
    {
        private readonly Context _dbContext;
        public EFShoppingCartRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<ShoppingCart> GetAll()
        {
            return _dbContext.ShoppingCart;
        }
        public ShoppingCart GetById(int Id)
        {
            return _dbContext.ShoppingCart.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveShoppingCart(ShoppingCart entity)
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
        public void DeleteShoppingCart(int Id)
        {
            _dbContext.ShoppingCart.Remove(new ShoppingCart() { Id = Id });
            _dbContext.SaveChanges();
        }
    }
}
