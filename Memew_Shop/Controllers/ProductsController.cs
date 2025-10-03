using Memeo.Repository.Abstractions;
using Memew.BO.Models;
using Microsoft.AspNetCore.Mvc;

namespace Memew_Shop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet] public Task<List<ProductDTO>> GetAll() => service.GetAllAsync();

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDTO>> Get(Guid id)
        => (await service.GetAsync(id)) is { } dto ? dto : NotFound();

    public record CreateProductReq(string Name, string? Type, string Status = "Active");

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Create(CreateProductReq req)
    {
        var dto = await service.CreateAsync(req.Name, req.Type, req.Status);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:guid}/name")]
    public async Task<IActionResult> Rename(Guid id, [FromBody] string name)
    { await service.UpdateNameAsync(id, name); return NoContent(); }

    [HttpDelete("{id:guid}")]
    public Task Delete(Guid id) => service.DeleteAsync(id);
}
