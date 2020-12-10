using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Online_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.AspNetCore.Identity;

namespace Clothes_Shop.Controllers
{
    public class CartsController : Controller
    {
        UserManager<IdentityUser> userManager;

        private readonly CartContext _dbContext;
        private readonly ItemsContext _ItemContext;
        private readonly ApplicationDbContext _context;

        public CartsController(CartContext dbContext, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _dbContext = dbContext;
            this.userManager = userManager;

        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

          

            List<Item> cartProducts = new List<Item>();

            var cart = _context.Cart.Where(c => c.User.Id == user.Id).ToListAsync();
          
            foreach (var i in cart.Result)
            {
                var cart7 = _context.Item.Where(c => c.Id == i.Item.Id).ToListAsync();
               
                cartProducts.Add(i.Item);
            }

            return View(cartProducts);
            //return View(await _context.Cart.ToListAsync());
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //----------------------------------------------------------------------------------------------//
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }
        */
        //------------------------------------------------------------------------------------------//



        public async Task<IActionResult> Create(string ItemId)
        {
            
            Item item = _context.Item.Find(ItemId);


            Console.WriteLine(item);
            Cart cart = new Cart();
            var varUser = _context.Users.Where(u => u.Email.Equals(User.Identity.Name));
            var user = await userManager.GetUserAsync(User);
            
            if (ModelState.IsValid)
            {
                cart.Id = user.Id + "CART";
                cart.Item = item;
                cart.User = user;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", cart);
        }



        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(string id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}
