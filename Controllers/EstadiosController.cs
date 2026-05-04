using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Data;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// batatinha cremosa gostosa 

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EstadiosController : ControllerBase
    {
        private readonly DataContext _context;

        public EstadiosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
           try
           {
                List<Estadio> lista= await _context.TB_ESTADIO.ToListAsync();

                return Ok(lista);
           }
           catch (System.Exception ex)
           {
                return BadRequest(ex.Message + " - " + ex.InnerException);
           } 
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estadio novoEstadio)
        {
            try
            {
                await _context.TB_ESTADIO.AddAsync(novoEstadio);
                await _context.SaveChangesAsync();

                List<Estadio> lista= await _context.TB_ESTADIO.ToListAsync();
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
                List<Estadio> lista=await _context.TB_ESTADIO.ToListAsync();
                lista.RemoveAll(e=>e.Id==id);
                return Ok(lista);

           }
           catch (System.Exception ex)
           {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            
           } 
        }
    }
}