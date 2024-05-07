namespace Bookify.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var authors = _context.Authors.Select(c => new AuthorViewModel
            {
                Id = c.Id,
                Name = c.Name,
                CreatedOn = c.CreatedOn,
                LastUpdateOn = c.LastUpdateOn,
            }).AsNoTracking().ToList();

            return View(authors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(UnifiedFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            var Author = new Author { Name = model.Name };
            _context.Authors.Add(Author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Author = _context.Authors.Find(id);

            if (Author is null)
                return NotFound();

            var viewmodel = new UnifiedFormViewModel
            {
                Id = id,
                Name = Author.Name!
            };
            return View("Form", viewmodel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(UnifiedFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Form", model);

            var author = _context.Authors.Find(model.Id);

            if (author is null)
                return NotFound();

            author.Name = model.Name;
            author.LastUpdateOn = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Author = _context.Authors.Find(id);

            if (Author is null)
                return NotFound();

            _context.Remove(Author);
            _context.SaveChanges();
            return Ok();
        }
        public IActionResult Allowitem(UnifiedFormViewModel model)
        {
            var isExists = _context.Authors.Any(c => c.Name == model.Name);
            return Json(!isExists);
        }
    }
}
