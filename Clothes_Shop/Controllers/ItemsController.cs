using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Clothes_Shop.Data;
using Clothes_Shop.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Clothes_Shop.Controllers
{
    public class ItemsController : Controller
    {
        //private readonly ApplicationDbContext _context2;
        private readonly ItemsContext _context;
        private readonly ItemsService _contextSearch;
        private readonly ICategoriesRepository _categoryContext;
        private readonly IGendersRepository _gendersContext;
        private readonly IFeaturesRepository _featuresContext;
        private readonly ICommentsRepository _commentsContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly CommentsContext _comContext;
        UserManager<IdentityUser> userManager;

        public ItemsController(ItemsContext context, ItemsService contextSearch, ICategoriesRepository categoryContext, IWebHostEnvironment hostEnvironment, IGendersRepository gendersContext, IFeaturesRepository featuresContext, 
            ICommentsRepository commentsContext, CommentsContext comContext, UserManager<IdentityUser> userManager)
        {
            _categoryContext = categoryContext;
            _context = context;
            //_context2 = context2;
            _commentsContext = commentsContext;
            _gendersContext = gendersContext;
            _featuresContext = featuresContext;
             webHostEnvironment = hostEnvironment;
            _comContext = comContext;
            _contextSearch = contextSearch;
            this.userManager = userManager;

        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            ViewBag.Category = _categoryContext.AllCategories.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });

            ViewBag.Gender = _gendersContext.AllGenders.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });



            return View(await _context.Item.ToListAsync());
        }



        // GET: Items/Details/5
        public async Task<IActionResult> Details(string id)
        {
            //List <Comments> comments = _commentsContext.AllComments.ToList();
            List<Comments> comments = _comContext.Comments.Where(c => c.ItemId == id).ToList();
            ViewBag.Comments = comments;
            
            TempData["itemId"] = id;

            /*var allCom = _commentsContext.AllComments.Select(li => new SelectListItem
            { Text = li.Author, Value = li.Id.ToString() });*/

            var user = await userManager.GetUserAsync(User);

            var Allusers = await userManager.Users.ToListAsync();
            ViewBag.Allusers = Allusers;

            var item7 = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            
            var Desc = _featuresContext.AllFeatures.FirstOrDefault(m=>m.Id == item7.FeaturesId);


            var Category = _categoryContext.AllCategories.FirstOrDefault(m => m.Id == item7.CategoryId);
            
            var Gender = _gendersContext.AllGenders.FirstOrDefault(m => m.Id == item7.GenderId);

            ViewBag.Desc = Desc.Description;
            
            ViewBag.Category = Category;
            
            ViewBag.Size = Desc.Size;
            ViewBag.Color = Desc.Color;
            ViewBag.Material = Desc.Material;
            ViewBag.Country = Desc.Country;
            ViewBag.Gender = Gender.Name;


            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            //return RedirectToAction("Details", item);
            return View(item);
        }




        // GET: Items/Create
        public IActionResult Create()
        {

            /*
            var categList = (from cat in _categoryContext.AllCategories select new SelectListItem(){
                                    Text = cat.Name,
                                    Value = cat.Id.ToString(),
                                }).ToList();

            categList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            ViewBag.Categories = categList;*/
            //ViewData["Category"] = new SelectList(_categoryContext.AllCategories, "Category", "Name")

            ViewBag.Comments = _commentsContext.AllComments.Select(li => new SelectListItem
            { Text = li.Content, Value = li.Id.ToString() });

            ViewBag.Category = _categoryContext.AllCategories.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });

            ViewBag.Gender = _gendersContext.AllGenders.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });

            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId,GenderId,Features,Image")] Item item)
        {
            var catId = Request.Form["CategoryId"];
            var CatObj = _categoryContext.AllCategories.FirstOrDefault(x => x.Id == catId);

            var genId = Request.Form["GenderId"];
            var genObj = _gendersContext.AllGenders.FirstOrDefault(x => x.Id == genId);


            var fDesc = Request.Form["Features.Description"];
            var fCountry = Request.Form["Features.Country"];
            var fMater = Request.Form["Features.Material"];
            var fSize = Request.Form["Features.Size"];
            var fColor = Request.Form["Features.Color"];

            if (ModelState.IsValid)
            {
                item.Features.Id = item.Id + "fe";
                item.CategoryId = catId;
                item.GenderId = genId;

                /*
                item.Features.Country = fCountry;
                item.Features.Description = fDesc;
                item.Features.Material = fMater;
                item.Features.Id = item.Id+"fe";
                item.Features.Color = fColor;*/

                /*
                item.Category.Id = CatObj.Id.ToString();
                item.Gender.Id = genObj.Id.ToString();

                item.Category.Name = CatObj.Name.ToString();
                item.Gender.Name = genObj.Name.ToString();*/

                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Image")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.Item.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Search(string text)
        {
            var searchedItems = await _contextSearch.Search(text);
            return View("Index", searchedItems);
        }


        public async Task<IActionResult> Filter(string CategoryId, string GenderId, string SizeId)
        {
            ViewBag.Category = _categoryContext.AllCategories.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });

            ViewBag.Gender = _gendersContext.AllGenders.Select(li => new SelectListItem
            { Text = li.Name, Value = li.Id.ToString() });


            var searchedItems = await _contextSearch.Filter(CategoryId, GenderId, SizeId);
            return View("Index", searchedItems);
        }

    }
}
