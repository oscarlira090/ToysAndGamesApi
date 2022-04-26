using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
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
        [HttpGet("{id}")]
        public ActionResult<List<string>> Get(int id)
        {
            try
            {
                return _proIma.GetImages(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("display/{url}")]
        public ActionResult GetImages(string url)
        {
            try
            {
                string urlfinal = _proIma.getBasePath() + WebUtility.UrlDecode(url);
                string ?contentType = "";
                if (!System.IO.File.Exists(urlfinal)) return BadRequest("URL NOT FOUND");

                new FileExtensionContentTypeProvider().TryGetContentType(urlfinal, out contentType);
                return File(System.IO.File.OpenRead(urlfinal), contentType);
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
