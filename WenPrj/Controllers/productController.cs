using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WenPrj.Models;

namespace WenPrj.Controllers
{
    public class productController : Controller
    {
        private readonly MDAContext _context;

        public productController(MDAContext context)
        {
            _context = context;
        }

        public IActionResult ProductChart () 
        {
            return View();
        }
        public IActionResult TestSearchKeyword(string keyword)
        {
            var product = _context.商品資料products
              .Where(p => p.商品名稱productName.Contains(keyword) ||
              p.商品介紹introduce.Contains(keyword) ||
              p.電影院編號theater.電影院名稱theaterName.Contains(keyword)
              )
              .Select(p => new {
                  p.電影院編號theater.電影院名稱theaterName,
                  p.商品名稱productName,
                  p.商品價格productPrice,
                  p.商品介紹introduce,
                  p.類別category,
                  p.商品圖片路徑imagePath
              });

            return Json(product);
        }

        public IActionResult SearchKeyword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchKeyword(string keyword)
        {
            return View();
        }
        public IActionResult Card()
        {
            return View();
        }
        public IActionResult CardProduct(int myTheaterId)
        {
            var product = _context.商品資料products
                .Where(p => p.電影院編號theaterId == myTheaterId)
                .Select(p => new
                {
                    p.商品名稱productName,
                    p.商品價格productPrice,
                    p.商品介紹introduce,
                    p.商品圖片路徑imagePath
                });
            return Json(product);
        }


        // GET: product
        public async Task<IActionResult> Index()
        {
            var mDAContext = _context.商品資料products.Include(商 => 商.電影院編號theater);
            return View(await mDAContext.ToListAsync());
        }

        // GET: product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 商品資料product = await _context.商品資料products
                .Include(商 => 商.電影院編號theater)
                .FirstOrDefaultAsync(m => m.商品編號productId == id);
            if (商品資料product == null)
            {
                return NotFound();
            }

            return View(商品資料product);
        }

        // GET: product/Create
        public IActionResult Create()
        {
            ViewData["電影院編號theaterId"] = new SelectList(_context.電影院theaters, "電影院編號theaterId", "地址address");
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("商品編號productId,商品名稱productName,商品價格productPrice,電影院編號theaterId,商品圖片image,商品圖片路徑imagePath,商品介紹introduce,類別category")] 商品資料product 商品資料product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(商品資料product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["電影院編號theaterId"] = new SelectList(_context.電影院theaters, "電影院編號theaterId", "地址address", 商品資料product.電影院編號theaterId);
            return View(商品資料product);
        }

        // GET: product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 商品資料product = await _context.商品資料products.FindAsync(id);
            if (商品資料product == null)
            {
                return NotFound();
            }
            ViewData["電影院編號theaterId"] = new SelectList(_context.電影院theaters, "電影院編號theaterId", "地址address", 商品資料product.電影院編號theaterId);
            return View(商品資料product);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("商品編號productId,商品名稱productName,商品價格productPrice,電影院編號theaterId,商品圖片image,商品圖片路徑imagePath,商品介紹introduce,類別category")] 商品資料product 商品資料product)
        {
            if (id != 商品資料product.商品編號productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(商品資料product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!商品資料productExists(商品資料product.商品編號productId))
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
            ViewData["電影院編號theaterId"] = new SelectList(_context.電影院theaters, "電影院編號theaterId", "地址address", 商品資料product.電影院編號theaterId);
            return View(商品資料product);
        }

        // GET: product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var 商品資料product = await _context.商品資料products
                .Include(商 => 商.電影院編號theater)
                .FirstOrDefaultAsync(m => m.商品編號productId == id);
            if (商品資料product == null)
            {
                return NotFound();
            }

            return View(商品資料product);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var 商品資料product = await _context.商品資料products.FindAsync(id);
            _context.商品資料products.Remove(商品資料product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool 商品資料productExists(int id)
        {
            return _context.商品資料products.Any(e => e.商品編號productId == id);
        }
    }
}
