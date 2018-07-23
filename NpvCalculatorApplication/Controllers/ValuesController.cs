using System.Threading.Tasks;
using System.Web.Http;
using NpvCalculatorApplication.Helper;
using NpvCalculatorApplication.Models;

namespace NpvCalculatorApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody]NpvObjectModel model)
        {
            var result = await new ComputeHelper().NpvCollectionAsync(model);
            return Ok(result);
        }
    }
}
