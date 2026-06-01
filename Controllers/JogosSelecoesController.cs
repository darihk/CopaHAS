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
    public class JogosSelecoesController : ControllerBase
    {
        private readonly DataContext _context;

        public JogosSelecoesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{jogoId}/{selecaoId}")]
        public async Task<IActionResult> GetSingle(int jogoId, int selecaoId)
        {
            try
            {
                JogoSelecao jogoSelecao = await _context.TB_JOGO_SELECOES
                    .FirstOrDefaultAsync(eBusca => eBusca.JogoId == jogoId && eBusca.SelecaoId == selecaoId);

                return Ok(jogoSelecao);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(JogoSelecao novoJogoSelecao)
        {
            try
            {
                await _context.TB_JOGO_SELECOES.AddAsync(novoJogoSelecao);
                await _context.SaveChangesAsync();

                List<JogoSelecao> lista = await _context.TB_JOGO_SELECOES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{jogoId}/{selecaoId}")]

        public async Task<IActionResult> Delete(int jogoId, int selecaoId)
        {
           try
           {
                List<JogoSelecao> lista = await _context.TB_JOGO_SELECOES.ToListAsync();
                lista.RemoveAll(e => e.JogoId==jogoId && e.SelecaoId==selecaoId);
                return Ok(lista);

           }
           catch (System.Exception ex)
           {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            
           } 
        }
    }
}