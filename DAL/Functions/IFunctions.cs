using System.Linq;

namespace DAL.Functions
{
    public interface IFunctions
    {
        IQueryable<GetAgroProducts_Result> GetProducts(string text);
        IQueryable<GetAgroProductById_Result> GetProduct(int id);
    }
}
