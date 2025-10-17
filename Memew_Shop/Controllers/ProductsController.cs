using Memeo.Repository.Abstractions;
using Memew.BO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Memew_Shop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet("getAll")] 
    public Task<List<ProductDTO>> GetAll() => service.GetAllAsync();

    [HttpGet("getById")]
    public async Task<ActionResult<ProductDTO>> Get(Guid productId)
        => (await service.GetAsync(productId)) is { } dto ? dto : NotFound();

    public record CreateProductReq(
        string Name,
        string? Description,
        string? Type,
        string Status = "Active",
        string? Images = null
    );

    [HttpPost("newProduct")]
    public async Task<ActionResult<ProductDTO>> Create(CreateProductReq req)
    {
        var dto = await service.CreateAsync(req.Name, req.Description, req.Type, req.Status, req.Images);
        return CreatedAtAction(nameof(Get), new { productId = dto.ProductID }, dto);
    }

    // GET api/products/search?name=abc
    [HttpGet("searchName")]
    public Task<List<ProductDTO>> Search([FromQuery] string name)
        => service.GetByNameAsync(name);

    [HttpPut("changeNameById")]
    public async Task<IActionResult> Rename(Guid productId, [FromBody] string name)
    { 
        await service.UpdateNameAsync(productId, name); 
        return NoContent(); 
    }

    [HttpDelete("deleteById")]
    public Task Delete(Guid productId) => service.DeleteAsync(productId);
}
