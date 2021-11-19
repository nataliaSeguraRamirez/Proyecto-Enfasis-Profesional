using Tutorias.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}