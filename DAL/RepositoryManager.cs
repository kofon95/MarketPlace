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

        #endregion
    }
}
