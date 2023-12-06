using GrandAppV2.Models;
using GrandAppV2.Models.Data;
using GrandAppV2.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace GrandAppV2.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly AppCtx _context;

        public ReservationsController(AppCtx context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var appCtx = _context.Reservations
               .OrderBy(f => f.ArrivaldateTime);

            return View(await appCtx.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var Reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Reservations == null)
            {
                return NotFound();
            }

            return View(Reservations);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "ID", "Number");
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname");
            return View();
        }

        public class ApplicationContext : DbContext
        {
            public DbSet<Reservation> Reservations { get; set; }
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationsViewModel model)
        {
            if (_context.Reservations
                .Where(f => f.IdRoom == model.IdRoom)
                .FirstOrDefault() != null)
            {
                /*string connectionString = "Server=(localdb)\\mssqllocaldb;Database=bdgrand;Trusted_Connection=True;MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var idroom = model.IdRoom;
                    string sqlExpression = "SELECT ArrivaldateTime,DeparturedateTime FROM Reservations WHERE IdRoom = {idroom}";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSD
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛGSDGSDGSDGSDGSDGSDGSDЛЖЫВОЛЬАЭ
                     ОСТАНОВИЛСЯ ТУТ
                    https://metanit.com/sharp/adonetcore/2.5.php
                    ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОЛЖЫВОЛЬАЭ
                    ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                ЫВАЫВОАЩЫВОАЩЗЫАОЫУВАОЫВЩАОЫВОАЫВЛДАОДЫВЛОАЩЫЛВАОВАОЫЩВАОЫВАОЩЖДЫВЛОАДЩЭЛЖЫВАОSDGSDGSDGSEDGSDGSDGSDGSЫЩВАОЫВАОЩЖДЫВЛ
                }*/
                ModelState.AddModelError("", "Номер занят");
            }

            if (ModelState.IsValid)
            {
                Reservation reservation = new()
                {
                    ArrivaldateTime = model.ArrivaldateTime,
                    DeparturedateTime = model.DeparturedateTime,
                    NumberGuests = model.NumberGuests,
                    IdRoom = model.IdRoom,
                    IdUser = model.IdUser
                };

                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "ID", "Number", model.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Nickname", model.IdUser);
            return View(model);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "ID", "Description", reservation.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", reservation.IdUser);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArrivaldateTime,DeparturedateTime,NumberGuests,IdRoom,IdUser")] Reservation reservation)
        {
            if (id != reservation.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ID))
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
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "ID", "Description", reservation.IdRoom);
            ViewData["IdUser"] = new SelectList(_context.Users, "Id", "Id", reservation.IdUser);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .Include(r => r.Room)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'AppCtx.Reservations'  is null.");
            }
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
