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

        public IQueryable<GetAgroProductById_Result> GetProduct(int id)
        {
            return _context.GetAgroProductById(id);
        }
    }
}