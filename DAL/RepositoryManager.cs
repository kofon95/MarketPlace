using DAL.Repository;

namespace DAL
{
    public class RepositoryManager
    {
        StoreContext _context = new StoreContext();

        private RepositoryManager()
        { }

        public static RepositoryManager Manager => new RepositoryManager();

        #region Lazy load

        private IRepository<AgroCategory, int> _agroCategory;
        public IRepository<AgroCategory, int> Category => _agroCategory ?? (_agroCategory = new SqlRepository<AgroCategory>(_context.AgroCategories, _context));

        private IRepository<Product, int> _product;
        public IRepository<Product, int> Product => _product ?? (_product = new SqlRepository<Product>(_context.Products, _context));

        private IRepository<Guest, int> _guest;
        public IRepository<Guest, int> Guest => _guest ?? (_guest = new SqlRepository<Guest>(_context.Guests, _context));

        private IRepository<ProductView, int> _productViews;
        public IRepository<ProductView, int> ProductView => _productViews ?? (_productViews = new SqlRepository<ProductView>(_context.ProductViews, _context));

        #endregion
    }
}
