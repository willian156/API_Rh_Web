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
    public class ConhecimentosController : ControllerBase
    {
        private readonly Context _context;

        public ConhecimentosController(Context context)
        {
            _context = context;
        }

        // GET: api/Conhecimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conhecimento>>> GetConhecimento()
        {
            return await _context.Conhecimento.ToListAsync();
        }

        // GET: api/Conhecimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conhecimento>> GetConhecimento(int id)
        {
            var conhecimento = await _context.Conhecimento.FindAsync(id);

            if (conhecimento == null)
            {
                return NotFound();
            }

            return conhecimento;
        }

        // PUT: api/Conhecimentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConhecimento(int id, Conhecimento conhecimento)
        {
            if (id != conhecimento.id_Conhecimentos)
            {
                return BadRequest();
            }

            _context.Entry(conhecimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConhecimentoExists(id))
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

        // POST: api/Conhecimentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conhecimento>> PostConhecimento(Conhecimento conhecimento)
        {
            _context.Conhecimento.Add(conhecimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConhecimento", new { id = conhecimento.id_Conhecimentos }, conhecimento);
        }

        // DELETE: api/Conhecimentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConhecimento(int id)
        {
            var conhecimento = await _context.Conhecimento.FindAsync(id);
            if (conhecimento == null)
            {
                return NotFound();
            }

            _context.Conhecimento.Remove(conhecimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConhecimentoExists(int id)
        {
            return _context.Conhecimento.Any(e => e.id_Conhecimentos == id);
        }
    }
}
