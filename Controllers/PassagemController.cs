using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home.Data;
using Home.Models;

namespace Home.Controllers
{
    public class PassagemController : Controller
    {
        private readonly PassagemContext _context;

        public PassagemController(PassagemContext context)
        {
            _context = context;
        }

        // GET: Passagem
        public async Task<IActionResult> Index()
        {
            var passagemContext = _context.Passagens.Include(p => p.Cadastro).Include(p => p.Destino);
            return View(await passagemContext.ToListAsync());
        }

        // GET: Passagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Cadastro)
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagem/Create
        public IActionResult Create()
        {
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "Id", "Nome");
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Local");
            return View();
        }

        // POST: Passagem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Preco,CadastroId,DestinoId")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "Id", "Nome", passagem.CadastroId);
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Local", passagem.DestinoId);
            return View(passagem);
        }

        // GET: Passagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "Id", "Nome", passagem.CadastroId);
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Local", passagem.DestinoId);
            return View(passagem);
        }

        // POST: Passagem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Preco,CadastroId,DestinoId")] Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id))
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
            ViewData["CadastroId"] = new SelectList(_context.Cadastros, "Id", "Nome", passagem.CadastroId);
            ViewData["DestinoId"] = new SelectList(_context.Destinos, "Id", "Local", passagem.DestinoId);
            return View(passagem);
        }

        // GET: Passagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagens
                .Include(p => p.Cadastro)
                .Include(p => p.Destino)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.Passagens.FindAsync(id);
            _context.Passagens.Remove(passagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagens.Any(e => e.Id == id);
        }
    }
}
