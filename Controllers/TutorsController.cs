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
        public async Task<ActionResult> Index(string sortOrder)
        {
            ViewData["ScoreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "AverageScore" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "Name" : "";
            var tutors = from t in _context.Tutors select t;
            switch (sortOrder)
            {
                case "AverageScore":
                    tutors = tutors.OrderByDescending(t => t.AverageScore);
                    break;
                case "Name":
                    tutors = tutors.OrderBy(t => t.Name);
                    break;
                default:
                    tutors = tutors.OrderByDescending(t => t.AverageScore);
                    break;
            }
            return View(await tutors.AsNoTracking().ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Name", "Email", "Description")] Tutor tutor)
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }
            return View(tutor);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorToUpdate = await _context.Tutors.FirstOrDefaultAsync(t => t.ID == id);
            if (await TryUpdateModelAsync<Tutor>(tutorToUpdate, "", s => s.Name, s => s.Email, s => s.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(tutorToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (tutor == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(tutor);
        }

        // POST: tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Tutors.Remove(tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}