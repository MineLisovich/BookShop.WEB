using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.WEB.DataBase.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.DataBase.Repositories.Abstract
{
    public interface IImporterRepository
    {
        IQueryable<Importer> GetAll();
        Importer GetById(int id);
        Importer GetByName(string FullNameImporter);
        void SaveImporter(Importer entity);
        void DeleteImporter(int id);
    }
}
