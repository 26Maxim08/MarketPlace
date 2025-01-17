using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Data;
using MarketPlace.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketPlace.Controllers
{
    public class orderitemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public orderitemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: orderitems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orderitems.Include(o => o.order).Include(o => o.product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: orderitems/Details/5
        public async Task<IActionResult> Details(int? orderId, int? productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }

            var orderItem = await _context.orderitems
                .Include(o => o.order)
                .Include(o => o.product)
                .FirstOrDefaultAsync(m => m.orderid == orderId && m.productid == productId);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: orderitems/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Name");
            return View();
        }

        // POST: orderitems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity")] orderitem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "OrderId", orderItem.orderid);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Name", orderItem.productid);
            return View(orderItem);
        }

        // GET: orderitems/Edit/5
        public async Task<IActionResult> Edit(int? orderId, int? productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }

            var orderItem = await _context.orderitems.FindAsync(orderId, productId);
            if (orderItem == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "OrderId", orderItem.orderid);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Name", orderItem.productid);
            return View(orderItem);
        }

        // POST: orderitems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int orderId, int productId, [Bind("OrderId,ProductId,Quantity")] orderitem orderItem)
        {
            if (orderId != orderItem.orderid || productId != orderItem.productid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.orderid, orderItem.productid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.orders, "OrderId", "OrderId", orderItem.orderid);
            ViewData["ProductId"] = new SelectList(_context.products, "ProductId", "Name", orderItem.productid);
            return View(orderItem);
        }

        // GET: orderitems/Delete/5
        public async Task<IActionResult> Delete(int? orderId, int? productId)
        {
            if (orderId == null || productId == null)
            {
                return NotFound();
            }

            var orderItem = await _context.orderitems
                .Include(o => o.order)
                .Include(o => o.product)
                .FirstOrDefaultAsync(m => m.orderid == orderId && m.productid == productId);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: orderitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int orderId, int productId)
        {
            var orderItem = await _context.orderitems.FindAsync(orderId, productId);
            _context.orderitems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int orderId, int productId)
        {
            return _context.orderitems.Any(e => e.orderid == orderId && e.productid == productId);
        }
    }
}
