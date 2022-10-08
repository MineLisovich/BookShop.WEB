using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IBindingRepository
    {
        IQueryable<Binding> GetAll();
        Binding GetById(int id);
        Binding GetByName(string NameBinding);
        void SaveBinding(Binding entity);
        void DeleteBinding(int id);
    }
}
