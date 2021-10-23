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
    public class CurriculosController : ControllerBase
    {
        private readonly Context _context;

        public CurriculosController(Context context)
        {
            _context = context;
        }

        // GET: api/Curriculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculo>>> GetCurriculo()
        {
            return await _context.Curriculo.ToListAsync();
        }

        // GET: api/Curriculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculo>> GetCurriculo(int id)
        {
            var curriculo = await _context.Curriculo.FindAsync(id);

            if (curriculo == null)
            {
                return NotFound();
            }

            return curriculo;
        }

        // PUT: api/Curriculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculo(int id, Curriculo curriculo)
        {
            if (id != curriculo.id_curriculo)
            {
                return BadRequest();
            }

            _context.Entry(curriculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculoExists(id))
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

        // POST: api/Curriculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curriculo>> PostCurriculo(Curriculo curriculo)
        {
            _context.Curriculo.Add(curriculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurriculo", new { id = curriculo.id_curriculo }, curriculo);
        }

        // DELETE: api/Curriculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculo(int id)
        {
            var curriculo = await _context.Curriculo.FindAsync(id);
            if (curriculo == null)
            {
                return NotFound();
            }

            _context.Curriculo.Remove(curriculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurriculoExists(int id)
        {
            return _context.Curriculo.Any(e => e.id_curriculo == id);
        }
    }
}
