using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Data;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TecnicosController : ControllerBase
    {
        private readonly DataContext _context;

        public TecnicosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Tecnico tecnico = await _context.TB_TECNICOS
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(tecnico);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tecnico novoTecnico)
        {
            try
            {
                await _context.TB_TECNICOS.AddAsync(novoTecnico);
                await _context.SaveChangesAsync();

                List<Tecnico> lista = await _context.TB_TECNICOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           try
           {
                List<Tecnico> lista = await _context.TB_TECNICOS.ToListAsync();
                lista.RemoveAll(e => e.Id==id);
                return Ok(lista);

           }
           catch (System.Exception ex)
           {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            
           } 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Tecnico> lista = await _context.TB_TECNICOS.Include(s => s.SelecaoIdNavegacao)
                    .ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
    }
}