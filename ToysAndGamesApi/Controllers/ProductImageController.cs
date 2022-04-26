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
                if (!productoId.HasValue) {
                    return BadRequest("ProductId Cannot be null");
                }
                return _proIma.GetImages(productoId);
            }
            catch (Exception ex)
            {
                //TODO: If GetImages throw an exception, this line is returning a 400 Bad Request, instead of a 500 Internal Server Error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                //400 Client Error
                //500 Server / Backend Error
            }
        }
    }
}
