using BookShop.WEB.DataBase.Repositories.Abstract;

namespace BookShop.WEB.DataBase
{
    public class DataManager
    {
        public IBindingRepository Binding { get; set; }
        public IBooksRepository Books { get; set; }
        public IDeliveryRepository Delivery { get; set; }  
        public IFormatRepository Format { get; set; } 
        public IGanresRepository Ganres { get; set; } 
        public IImporterRepository Importer { get; set; } 
        public IOurStoresRepository OurStores { get; set; }   
        public IPickupRepository Pickup { get; set; }
        public IPublisherRepository Publisher { get; set; }   
        public IShoppingCartRepository ShoppingCart { get; set; } 
        public ITheAuthorsRepository TheAuthors{ get; set; }

        public DataManager (IBindingRepository binding, IBooksRepository books, IDeliveryRepository delivery, 
            IFormatRepository format, IGanresRepository ganres, IImporterRepository importer, 
            IOurStoresRepository ourStores, IPickupRepository pickup, IPublisherRepository publisher, 
            IShoppingCartRepository shoppingCart, ITheAuthorsRepository theAuthors)
        {
            Binding = binding;
            Books = books;
            Delivery = delivery;
            Format = format;
            Ganres = ganres;
            Importer = importer;
            OurStores = ourStores;
            Pickup = pickup;
            Publisher = publisher;
            ShoppingCart = shoppingCart;
            TheAuthors = theAuthors;
        }
    }
}
