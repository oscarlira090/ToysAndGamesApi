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
                return BadRequest(ex.Message);
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
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<string> PostOrUpdate([FromForm] Product product)
        {
            try
            {
                Product ?productResult = null;
                if (ModelState.IsValid)
                {
                   productResult = _proB.CreateOrUpdate(product);
                }
                return CreatedAtAction(nameof(Get), new { id = productResult?.Id }, productResult);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _proB.Delete(id);

                return Ok("The product has been deleted succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
