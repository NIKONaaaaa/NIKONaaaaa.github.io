namespace PetrofMusicStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetrofMusicStore.Data;
    using PetrofMusicStore.Models;

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (obj.ProductType.ToLower() == obj.ProductBrand.ToLower())
            {
                ModelState.AddModelError("ProductType","The type of instrument can't match the brand.");
            }
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
    }
}