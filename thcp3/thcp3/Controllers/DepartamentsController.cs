using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thcp3.Data;
using thcp3.Models;

namespace thcp3.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartamentsController(ApplicationDbContext db)
        {
            this.db = db;

        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.Departaments.FirstOrDefaultAsync(d => d.DepartamentId == id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);

        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Departaments.ToListAsync());

        }

        //crear por medio de vista

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Add(departament);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(departament);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depart = await db.Departaments.FindAsync(id);
            if (depart == null)
            {
                return NotFound();
            }

            return View(depart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, Departament depart) 
        {
            if (id != depart.DepartamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(depart);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException )
                {
                    return NotFound();
                    
                }

                return RedirectToAction(nameof(Index));
            }

            return View(depart);
        }
    }

    
    }

