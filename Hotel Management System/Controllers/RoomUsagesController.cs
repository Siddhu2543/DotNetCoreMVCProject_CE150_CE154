using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Data;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hotel_Management_System.Controllers
{
    public class RoomUsagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomUsagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomUsages
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RoomUsage.Include(r => r.Room).Include(r => r.User);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize(Roles ="guest")]
        public async Task<IActionResult> ForUser()
        {
            var applicationDbContext = _context.RoomUsage.Include(r => r.Room).Include(r => r.User);
            return View(await applicationDbContext.Where(r => r.User.UserName == User.Identity.Name).ToListAsync());
        }

        // GET: RoomUsages/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomUsage = await _context.RoomUsage
                .Include(r => r.Room).Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomUsage == null)
            {
                return NotFound();
            }
            return View(roomUsage);
        }

        // GET: RoomUsages/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create(string roomType)
        {
            ViewData["RoomId"] = new SelectList(_context.Room.Where(r => r.RoomType.Type == roomType && r.status == "free"), "Id", "RoomNo");
            ViewData["UserId"] = new SelectList(_context.Users.Where((u) => true), "Id", "UserName");
            return View();
        }

        // POST: RoomUsages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(string roomType, [Bind("Id,DateIn,DateOut,RoomId,UserId,status")] RoomUsage roomUsage)
        {
            if (ModelState.IsValid)
            {
                var room = _context.Room.Find(roomUsage.RoomId);
                _context.Room.Attach(room);
                room.status = "occupied";
                _context.Update(room);
                _context.Add(roomUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Room.Where(r => r.RoomType.Type == roomType), "Id", "RoomNo", roomUsage.RoomId);
            ViewData["UserId"] = new SelectList(
                _context.Users, "Id", "UserName", roomUsage.RoomId);
            return View(roomUsage);
        }

        // GET: RoomUsages/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomUsage = await _context.RoomUsage.FindAsync(id);
            if (roomUsage == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomNo", roomUsage.RoomId);
            ViewData["UserId"] = new SelectList(
                _context.Users, "Id", "UserName", roomUsage.RoomId);
            return View(roomUsage);
        }

        // POST: RoomUsages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateIn,DateOut,RoomId,UserId,status")] RoomUsage roomUsage)
        {
            if (id != roomUsage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomUsage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomUsageExists(roomUsage.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "RoomNo", roomUsage.RoomId);
            ViewData["UserId"] = new SelectList(
                _context.Users, "Id", "UserName", roomUsage.RoomId);
            return View(roomUsage);
        }

        // GET: RoomUsages/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomUsage = await _context.RoomUsage
                .Include(r => r.Room).Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomUsage == null)
            {
                return NotFound();
            }

            return View(roomUsage);
        }

        // POST: RoomUsages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomUsage = await _context.RoomUsage.FindAsync(id);
            _context.RoomUsage.Remove(roomUsage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomUsageExists(int id)
        {
            return _context.RoomUsage.Any(e => e.Id == id);
        }
    }
}
