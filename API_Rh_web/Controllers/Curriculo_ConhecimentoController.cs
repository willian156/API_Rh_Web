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
    public class Curriculo_ConhecimentoController : ControllerBase
    {
        private readonly Context _context;

        public Curriculo_ConhecimentoController(Context context)
        {
            _context = context;
        }

        // GET: api/Curriculo_Conhecimento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculo_Conhecimento>>> GetCurriculo_Conhecimento()
        {
            return await _context.Curriculo_Conhecimento.ToListAsync();
        }

        // GET: api/Curriculo_Conhecimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculo_Conhecimento>> GetCurriculo_Conhecimento(int id)
        {
            var curriculo_Conhecimento = await _context.Curriculo_Conhecimento.FindAsync(id);

            if (curriculo_Conhecimento == null)
            {
                return NotFound();
            }

            return curriculo_Conhecimento;
        }

        // PUT: api/Curriculo_Conhecimento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculo_Conhecimento(int id, Curriculo_Conhecimento curriculo_Conhecimento)
        {
            if (id != curriculo_Conhecimento.id_Curriculo)
            {
                return BadRequest();
            }

            _context.Entry(curriculo_Conhecimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Curriculo_ConhecimentoExists(id))
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

        // POST: api/Curriculo_Conhecimento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curriculo_Conhecimento>> PostCurriculo_Conhecimento(Curriculo_Conhecimento curriculo_Conhecimento)
        {
            _context.Curriculo_Conhecimento.Add(curriculo_Conhecimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurriculo_Conhecimento", new { id = curriculo_Conhecimento.id_Curriculo }, curriculo_Conhecimento);
        }

        // DELETE: api/Curriculo_Conhecimento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculo_Conhecimento(int id)
        {
            var curriculo_Conhecimento = await _context.Curriculo_Conhecimento.FindAsync(id);
            if (curriculo_Conhecimento == null)
            {
                return NotFound();
            }

            _context.Curriculo_Conhecimento.Remove(curriculo_Conhecimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Curriculo_ConhecimentoExists(int id)
        {
            return _context.Curriculo_Conhecimento.Any(e => e.id_Curriculo == id);
        }
    }
}
