using System.Security.Claims;
using HCL_Hackathon_WebAPIators.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCL_Hackathon_WebAPIators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AnalyticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnalyticsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _context.Orders
                .AsNoTracking()
                .GroupBy(o => o.Status)
                .Select(group => new
                {
                    Status = group.Key,
                    Count = group.Count(),
                    Total = group.Sum(o => o.Amount)
                })
                .ToListAsync();

            return Ok(summary);
        }

        [HttpGet("my-stats")]
        public async Task<IActionResult> GetMyStats()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var stats = await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .GroupBy(o => o.Status)
                .Select(group => new
                {
                    Status = group.Key,
                    Count = group.Count(),
                    Total = group.Sum(o => o.Amount)
                })
                .ToListAsync();

            return Ok(stats);
        }
    }
}