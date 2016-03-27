using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using DAL;

namespace WebAPI.Controllers
{
    [EnableQuery]
    public class DefaultController : ApiController
    {
        RepositoryManager _manager = RepositoryManager.Manager;

        [HttpGet]
        public IQueryable<AgroCategory> GetCategories()
        {
            return _manager.Category.GetAll();
        }

        public string GetData()
        {
            return "Hello world";
        }
    }
}
