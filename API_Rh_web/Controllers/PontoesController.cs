using System;
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
    public class PontoesController : ControllerBase
    {
        private readonly Context _context;

        public PontoesController(Context context)
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
            if (id != ponto.id_vaga)
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
            _context.Ponto.Add(ponto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPonto", new { id = ponto.id_vaga }, ponto);
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
            return _context.Ponto.Any(e => e.id_vaga == id);
        }
    }
}
