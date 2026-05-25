using System.Security.Claims;
using HCL_Hackathon_WebAPIators.Data;
using HCL_Hackathon_WebAPIators.DTOs;
using HCL_Hackathon_WebAPIators.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCL_Hackathon_WebAPIators.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            IQueryable<Order> query = _context.Orders
                .AsNoTracking()
                .Include(o => o.User);

            if (userRole != "Manager")
            {
                query = query.Where(o => o.UserId == userId);
            }

            var orders = await query.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var order = await _context.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            if (userRole != "Manager" && order.UserId != userId)
            {
                return Forbid();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var autoApproveThreshold = 500m;

            var status = dto.Amount <= autoApproveThreshold
                ? "AutoApproved"
                : "Pending";

            var order = new Order
            {
                ItemName = dto.ItemName,
                Category = dto.Category,
                Amount = dto.Amount,
                Status = status,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Approve(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            order.Status = "Approved";

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Order approved successfully"
            });
        }

        [HttpPut("{id}/reject")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Reject(int id, UpdateOrderStatusDto dto)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            order.Status = "Rejected";

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Order rejected successfully",
                comment = dto.Comment
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Order deleted successfully"
            });
        }
    }
}