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
    public class Vaga_curriculoController : ControllerBase
    {
        private readonly Context _context;

        public Vaga_curriculoController(Context context)
        {
            _context = context;
        }

        // GET: api/Vaga_curriculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaga_curriculo>>> GetVaga_curriculo()
        {
            return await _context.Vaga_curriculo.ToListAsync();
        }

        // GET: api/Vaga_curriculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaga_curriculo>> GetVaga_curriculo(int id)
        {
            var vaga_curriculo = await _context.Vaga_curriculo.FindAsync(id);

            if (vaga_curriculo == null)
            {
                return NotFound();
            }

            return vaga_curriculo;
        }

        // PUT: api/Vaga_curriculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaga_curriculo(int id, Vaga_curriculo vaga_curriculo)
        {
            if (id != vaga_curriculo.id_vaga)
            {
                return BadRequest();
            }

            _context.Entry(vaga_curriculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Vaga_curriculoExists(id))
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

        // POST: api/Vaga_curriculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaga_curriculo>> PostVaga_curriculo(Vaga_curriculo vaga_curriculo)
        {
            _context.Vaga_curriculo.Add(vaga_curriculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Vaga_curriculoExists(vaga_curriculo.id_vaga))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVaga_curriculo", new { id = vaga_curriculo.id_vaga }, vaga_curriculo);
        }

        // DELETE: api/Vaga_curriculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaga_curriculo(int id)
        {
            var vaga_curriculo = await _context.Vaga_curriculo.FindAsync(id);
            if (vaga_curriculo == null)
            {
                return NotFound();
            }

            _context.Vaga_curriculo.Remove(vaga_curriculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Vaga_curriculoExists(int id)
        {
            return _context.Vaga_curriculo.Any(e => e.id_vaga == id);
        }
    }
}
