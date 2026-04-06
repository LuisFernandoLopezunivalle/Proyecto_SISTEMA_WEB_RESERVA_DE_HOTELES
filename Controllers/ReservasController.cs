using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RESERVAS_DE_HOTEL.Data;
using RESERVAS_DE_HOTEL.Models;

namespace RESERVAS_DE_HOTEL.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = _context.Reservas
                .Include(r => r.Hotel);

            return View(await reservas.ToListAsync());
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hoteles, "Id", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reserva reserva)
        {
            // 🔥 VALIDACIÓN IMPORTANTE
            if (reserva.FechaFin <= reserva.FechaInicio)
            {
                ModelState.AddModelError("", "La fecha fin debe ser mayor que la fecha inicio");
            }

            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["HotelId"] = new SelectList(_context.Hoteles, "Id", "Nombre", reserva.HotelId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reservas
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva != null)
                _context.Reservas.Remove(reserva);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}