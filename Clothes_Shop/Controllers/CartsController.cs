using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Clothes_Shop.Data;
using Microsoft.AspNetCore.Identity;
using Clothes_Shop.Services;

namespace Clothes_Shop.Controllers
{
    
    public class CartsController : Controller
    {
        private readonly CartContext _context;
        private readonly ItemsContext _itemcontext;
        private readonly ApplicationDbContext _context7;

        private readonly ICategoriesRepository _categoryContext;
        private readonly IGendersRepository _gendersContext;
        private readonly IFeaturesRepository _featuresContext;
        private readonly ItemsContext _contextIt;

        UserManager<IdentityUser> userManager;

        public CartsController(CartContext context, ItemsContext Goodcontext, UserManager<IdentityUser> userManager, 
            ApplicationDbContext context7, ICategoriesRepository categoryContext, 
            IGendersRepository gendersContext, IFeaturesRepository featuresContext, ItemsContext contextIt)
        {
            _itemcontext = Goodcontext;
            _context = context;
            _context7 = context7;
            this.userManager = userManager;
            _categoryContext = categoryContext;
            _gendersContext = gendersContext;
            _featuresContext = featuresContext;
            _contextIt = contextIt;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

        
            List<Item> cartProducts = new List<Item>();

            var cart = _context.Cart.Where(c => c.UserId == user.Id).ToListAsync();
            var ite = _itemcontext.Item.ToList();

            List<Item> items = new List<Item>(); 


            foreach (var i in cart.Result)
            {
                foreach (var j in ite)
                {
                    var item7 = _itemcontext.Item.Where(c => c.Id == i.ItemId);
                    //items = _Goodcontext.Item.Where(c => c.Id == i.ItemId).ToList();


                    if (!items.Contains(j) && i.UserId == user.Id && j.Id == i.ItemId)
                    {
                        items.Add(j);
                    }
                    
                }
                    //cartProducts.AddRange(items);
            }

            /*
            var item8 = await _contextIt.Item.FirstOrDefaultAsync(m => m.Id == id);


            var Desc = _featuresContext.AllFeatures.FirstOrDefault(m => m.Id == item8.FeaturesId);


            var Category = _categoryContext.AllCategories.FirstOrDefault(m => m.Id == item8.CategoryId);

            var Gender = _gendersContext.AllGenders.FirstOrDefault(m => m.Id == item8.GenderId);

            ViewBag.Desc = Desc.Description;

            ViewBag.Category = Category;

            ViewBag.Size = Desc.Size;
            ViewBag.Color = Desc.Color;
            ViewBag.Material = Desc.Material;
            ViewBag.Country = Desc.Country;
            ViewBag.Gender = Gender.Name;*/

            cartProducts.AddRange(items);


            //cartProducts.AddRange(items);

            return View(cartProducts);
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

        
        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        public async Task<IActionResult> Create(string GoodId)
        {
            var user = await userManager.GetUserAsync(User);
            // var gd = _Goodcontext.Goods.Where(u => u.Good.Id.Equals(GoodId));
            Item good = _itemcontext.Item.Find(GoodId);

            List <Cart> allcarts = _context.Cart.ToList();
            
            foreach (var t in allcarts) {
                if (t.ItemId == GoodId && t.UserId == user.Id) {
                    return NotFound("An item is already in your cart !!!");
                }
            
            }


            Console.WriteLine(good);
            Cart cart = new Cart();
            //var user =  userManager.GetUserAsync(User).Result;
            var varUser = _context7.Users.Where(u => u.Email.Equals(User.Identity.Name));
            //var user = varUser.FirstOrDefault();
           
            //var user = User.Identity.;
            // var good = _goodsRepository.AllGoods.FirstOrDefault(p => p.Id == id);
            if (ModelState.IsValid)
            {
                //    cart.Good = good;
                cart.Id = good.Id + "CART" + user.Id;
                cart.ItemId = good.Id;
                cart.UserId = user.Id;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", cart);
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
                return NotFound("Id null");
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(m => m.ItemId == id);


            if (cart == null)
            {
                return NotFound("Cart null");
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await userManager.GetUserAsync(User);
            //var cart = await _context.Cart.FindAsync(id);
            
            var cart = _context.Cart.Where(m => m.UserId == user.Id).ToList();
            List<Cart> cart2 = cart;

            var cart3 = cart2.FirstOrDefault(m => m.ItemId == id);
                 
            _context.Cart.Remove(cart3);


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(string id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}

