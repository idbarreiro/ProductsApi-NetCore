using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Interfaces;
using Products.Domain.Entities;
using System.Net;

namespace Products.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IManagerProduct _managerProduct;

        public ProductController(IManagerProduct managerProduct)
        {
            this._managerProduct = managerProduct;
        }

        [HttpPost]
        public async Task<ActionResult> InsertProduct([FromBody] Product product)
        {
            var response = new Product();

            if (product == null)
            {
                return BadRequest("El producto no puede venir nulo, revise los campos enviados");
            }

            try
            {
                response.Id = await this._managerProduct.InsertProductAsync(product);
                return Ok(response.Id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Entrada Invalida: " + ex.Message);   
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetProductById([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("El Id que ingreso no es valido");
            }

            try
            {
                var response = await this._managerProduct.GetProductByIdAsync(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound("Producto no encontrado o Id invalido");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            try
            {
                var response = await this._managerProduct.GetAllProductsAsync();
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound("No hay elementos en la tabla producto");
            }
        }
    }
}
