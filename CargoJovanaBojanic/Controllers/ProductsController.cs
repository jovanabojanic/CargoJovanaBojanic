using Core.Common;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DbContexts;
using Core.UnitOfWork;
using Abp.Domain.Repositories;

namespace CargoJovanaBojanic.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository _repository;

        public ProductsController(IGenericRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Vraća listu svih proizvoda iz baze podataka.
        /// </summary>
        /// <returns>Lista proizvoda.</returns>
        [HttpGet("products/getAll")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _repository.GetAll<Product>();

                var productDTOs = products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity
                }).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Vraća listu svih kategorija iz baze podataka.
        /// </summary>
        /// <returns>Lista kategorija.</returns>
        [HttpGet("category/getAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var products = await _repository.GetAll<Category>();

                var productDTOs = products.Select(c => new CategoryDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                }).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Vraća listu proizvoda za određenu kategoriju iz baze podataka.
        /// </summary>
        /// <param name="categoryId">ID kategorije za koju se traže proizvodi.</param>
        /// <returns>Lista proizvoda za datu kategoriju.</returns>
        [HttpGet("products/getByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                var products = await _repository.GetProductsByCategoryIdAsync(categoryId);

                if (products == null || !products.Any())
                {
                    return NotFound("Nema proizvoda za odabranu kategoriju.");
                }

                var productDTOs = products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity
                }).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Vraća proizvod na osnovu njegovog ID-a.
        /// </summary>
        /// <param name="productId">ID proizvoda koji se traži.</param>
        /// <returns>Proizvod sa zadatim ID-em.</returns>
        [HttpGet("products/getOne/{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await _repository.GetById<Product>(productId);

                if (product == null)
                {
                    return NotFound("Proizvod nije pronađen.");
                }

                var productDTO = new ProductDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Description = product.Description,
                    StockQuantity = product.StockQuantity
                };

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Traži proizvod na osnovu imena proizvoda.
        /// </summary>
        /// <param name="productName">Ime proizvoda koji se traži.</param>
        /// <returns>Lista proizvoda sa traženim imenom.</returns>
        [HttpGet("products/getByName")]
        public async Task<IActionResult> GetProductByName([FromQuery] string productName)
        {
            try
            {
                var products = await _repository.GetByFilter<Product>(p => p.ProductName == productName);

                if (products == null || !products.Any())
                {
                    return NotFound("Proizvod sa traženim imenom nije pronađen.");
                }

                var productDTOs = products.Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity
                }).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Kreira novi proizvod.
        /// </summary>
        /// <param name="productDTO">DTO objekat proizvoda koji se kreira.</param>
        /// <returns>Poruka o uspešnosti kreiranja proizvoda.</returns>
        [HttpPost("products/create")]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            try
            {
                var product = new Product
                {
                    ProductName = productDTO.ProductName,
                    Price = productDTO.Price,
                    Description = productDTO.Description,
                    StockQuantity = productDTO.StockQuantity,
                    CreatedAt = DateTime.Now,
                };

                await _repository.CreateOne(product);
                await _repository.SaveChanges();

                return Ok("Proizvod je uspešno kreiran.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Briše selektovani proizvod na osnovu njegovog ID-a.
        /// </summary>
        /// <param name="id">ID proizvoda koji se briše.</param>
        /// <returns>Poruka o rezultatu brisanja.</returns>
        [HttpDelete("products/delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _repository.GetById<Product>(id);
                if (product == null)
                {
                    return NotFound("Proizvod nije pronađen.");
                }

                await _repository.DeleteById<Product>(id);
                await _repository.SaveChanges();

                return Ok("Proizvod je uspešno obrisan.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Ažurira informacije o izabranom proizvodu.
        /// </summary>
        /// <param name="id">ID proizvoda koji se ažurira.</param>
        /// <param name="productDto">DTO objekat sa novim informacijama o proizvodu.</param>
        /// <returns>Poruka o uspešnosti ažuriranja.</returns>
        [HttpPut("products/update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            try
            {
                var existingProduct = await _repository.GetById<Product>(id);
                if (existingProduct == null)
                {
                    return NotFound("Proizvod nije pronađen.");
                }

                existingProduct.ProductName = productDto.ProductName;
                existingProduct.Price = productDto.Price;
                existingProduct.Description = productDto.Description;
                existingProduct.StockQuantity = productDto.StockQuantity;

                await _repository.SaveChanges();

                return Ok("Proizvod je uspešno ažuriran.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
