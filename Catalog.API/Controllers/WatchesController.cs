using Catalog.API.Data;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchesController : ControllerBase
{
    private readonly CatalogDbContext _context;

    public WatchesController(CatalogDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
    {
        return await _context.Watches.ToListAsync();
    }
}
