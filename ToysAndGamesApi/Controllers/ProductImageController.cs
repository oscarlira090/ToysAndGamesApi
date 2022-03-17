using Microsoft.AspNetCore.Mvc;
using ToysAndGamesBusiness;
using ToysAndGamesEntities;
using ToysAndGamesUtil;

namespace ToysAndGamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImages _proIma;
        public ProductImageController(IProductImages proIma)
        {
            _proIma = proIma;
        }

        // GET api/<ProductImageController>
        [HttpGet]
        public ActionResult<List<string>> Get(int? productoId)
        {
            try
            {
                return _proIma.GetImages(productoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
