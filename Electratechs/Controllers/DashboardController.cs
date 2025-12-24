[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DashboardController(ApplicationDbContext context) => _context = context;

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
        
        var totalUsers = await _context.Users.CountAsync();
        var totalProducts = await _context.Products.CountAsync();
        return Ok(new { totalUsers, totalProducts, marketHealth = "Stable" });
    }

    [HttpGet("user-analysis")]
    public async Task<IActionResult> GetUserAnalysis()
    {
        var analysis = await _context.Users
            .GroupBy(u => u.Role)
            .Select(g => new { role = g.Key, count = g.Count() })
            .ToListAsync();
        return Ok(analysis);
    }
}