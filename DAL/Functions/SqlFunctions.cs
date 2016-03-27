using System.Linq;
using System.Text;

namespace DAL.Functions
{
    internal class SqlFunctions : IFunctions
    {
        private StoreContext _context = new StoreContext();

        public IQueryable<GetAgroProducts_Result> GetProducts(string text)
        {
            var sb = new StringBuilder("%", text.Length*2);
            sb
                .Append(text)
                .Replace(' ', '%')
                .Append('%');

            return _context.GetAgroProducts(sb.ToString());
        }

        public GetAgroProductById_Result GetProduct(int id)
        {
            var products = _context.GetAgroProductById(id).ToArray();
            var len = products.Length;
            if (len == 0) return null;

            var product = products[0];
            if (product.image_path == null)
                len = 0;
            product.Images = new string[len];
            for (int i = 0; i < len; i++)
            {
                product.Images[i] = products[i].image_path;
            }

            return product;
        }
    }
}