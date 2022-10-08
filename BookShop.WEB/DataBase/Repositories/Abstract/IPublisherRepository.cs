using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IPublisherRepository
    {
        IQueryable<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher GetByName(string FullNamePublisher);
        void SavePublisher(Publisher entity);
        void DeletePublisher(int id);
    }
}
