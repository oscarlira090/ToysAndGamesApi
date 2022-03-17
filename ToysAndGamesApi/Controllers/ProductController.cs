using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagementEntities.Models;
using ToysAndGamesBusiness;
using ToysAndGamesEntities;

namespace ToysAndGamesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _proB;
        public ProductController(IProductBusiness proB)
        {
            _proB = proB;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return _proB.Get();
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            try
            {
                return _proB.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<MessageResponse> PostOrUpdate([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _proB.CreateOrUpdate(product);
                }
                return new MessageResponse { Message = "The product has been saved succesfully" };

            }
            catch (Exception ex)
            {
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
        }



        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<MessageResponse> Delete(int id)
        {
            try
            {
                _proB.Delete(id);
                return new MessageResponse { Message = "The product has been deleted succesfully" };
            }
            catch (Exception ex)
            {
                return BadRequest(new MessageResponse { Message = ex.Message });
            }
        }
    }
}
