using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvaliacaoApi.DataBase;
using AvaliacaoApplication.Models;

namespace AvaliacaoApplication.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly AvaliacaoContext _context;

        public EquipamentosController(AvaliacaoContext context)
        {
            _context = context;
        }

        // GET: api/Equipamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetProduto()
        {
            return await _context.Produto.ToListAsync();
        }

        // GET: api/Equipamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var equipamento = await _context.Produto.FindAsync(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return equipamento;
        }

        // PUT: api/Equipamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(id))
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

        // POST: api/Equipamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            _context.Produto.Add(equipamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipamento", new { id = equipamento.Id }, equipamento);
        }

        // DELETE: api/Equipamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var equipamento = await _context.Produto.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(equipamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
