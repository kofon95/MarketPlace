using System.Linq;

namespace DAL.Functions
{
    public interface IFunctions
    {
        IQueryable<GetAgroProducts_Result> GetProducts(string text);
        GetAgroProductById_Result GetProduct(int id);
    }
}
