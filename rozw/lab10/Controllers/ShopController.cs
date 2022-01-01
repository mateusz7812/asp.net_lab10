using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab10.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lab10.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;

        public ShopController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public async Task<IActionResult> Index(int? CategoryId)
        {
            var myDbContext = _context.Article.AsQueryable();
            if(CategoryId is not null){
                myDbContext = myDbContext.Where(a => a.CategoryId == CategoryId);
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryID", "Name", CategoryId);
            return View(await myDbContext.Include(a => a.Category).ToListAsync());
        }
    }
}