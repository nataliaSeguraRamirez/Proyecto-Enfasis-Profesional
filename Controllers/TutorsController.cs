using Tutorias.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorias.Models;
using System.Linq;
using System.Threading.Tasks;


namespace Tutorias.Controllers
{

    public class TutorsController : Controller
    {
        private readonly TutorshipContext _context;

        public TutorsController(TutorshipContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _context.Tutors.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors.FirstOrDefaultAsync(m => m.ID == id);

            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Route("Tutors/Create")]
        public async Task<IActionResult> Create([Bind("Name", "Email", "ShortDescription", "Description")] Tutor tutor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(tutor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View();
        }
    }
}