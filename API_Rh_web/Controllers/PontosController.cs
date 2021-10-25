﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Rh_web.Models;

namespace API_Rh_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontosController : ControllerBase
    {
        private readonly Context _context;

        public PontosController(Context context)
        {
            _context = context;
        }

        // GET: api/Pontoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponto>>> GetPonto()
        {
            return await _context.Ponto.ToListAsync();
        }

        // GET: api/Pontoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ponto>> GetPonto(int id)
        {
            var ponto = await _context.Ponto.FindAsync(id);

            if (ponto == null)
            {
                return NotFound();
            }

            return ponto;
        }

        // PUT: api/Pontoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonto(int id, Ponto ponto)
        {
            List<Vaga> lsVga = ponto.VagaPonto.ToList();

            lsVga.ForEach(src => src.id_vaga = id);

            if (lsVga == null)
            {
                return BadRequest();
            }

            _context.Entry(ponto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pontoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ponto>> PostPonto(Ponto ponto)
        {
            List<Vaga> lsVga = ponto.VagaPonto.ToList();
            
            _context.Ponto.Add(ponto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!PontoExists(lsVga.Max(x => x.id_vaga)))
                {
                    throw;
                }
                else
                {
                    return Conflict();
                }
            }

            return CreatedAtAction("GetPonto", new NewRecord(lsVga.Max(x => x.id_vaga)), ponto);
        }

        // DELETE: api/Pontoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonto(int id)
        {
            var ponto = await _context.Ponto.FindAsync(id);
            if (ponto == null)
            {
                return NotFound();
            }

            _context.Ponto.Remove(ponto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PontoExists(int id)
        {
            
            return _context.Ponto.Any(e => e.VagaPonto.Equals(id));
        }
    }

    internal record NewRecord(int Id);
}
