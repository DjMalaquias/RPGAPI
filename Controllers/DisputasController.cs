using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem? atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                if (atacante == null || oponente == null)
                    return BadRequest("Atacante ou Oponente não encontrado.");

                if (atacante.Arma == null)
                    return BadRequest("O atacante não possui uma arma equipada.");

                int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));
                dano = dano - (new Random().Next(oponente.Defesa));

                if (dano > 0)
                {
                    oponente.PontosVida = oponente.PontosVida - (int)dano;
                }

                if (oponente.PontosVida <= 0)
                {
                    d.Narracao = $"{oponente.Nome} foi derrotado! ";
                }

                _context.TB_PERSONAGENS.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat("Atacante: {0}. ", atacante.Nome);
                dados.AppendFormat("Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat("Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                dados.AppendFormat("Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                dados.AppendFormat("Arma Utilizada: {0}. ", atacante.Arma.Nome);
                dados.AppendFormat("Dano: {0}. ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;

                _context.TB_DISPUTAS.Add(d);
                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                Personagem? atacante = await _context.TB_PERSONAGENS
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                    .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem? oponente = await _context.TB_PERSONAGENS
                    .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                if (atacante == null || oponente == null)
                    return BadRequest("Atacante ou Oponente não encontrado.");

                PersonagemHabilidade? ph = await _context.TB_PERSONAGENS_HABILIDADES
                    .Include(p => p.Habilidade)
                    .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId 
                                                 && phBusca.PersonagemId == d.AtacanteId);

                if (ph == null)
                {
                    d.Narracao = $"{atacante.Nome} não possui esta habilidade.";
                    return BadRequest(d.Narracao);
                }

                int dano = ph.Habilidade.Dano + (new Random().Next(atacante.Inteligencia));
                dano = dano - (new Random().Next(oponente.Defesa));

                if (dano > 0)
                {
                    oponente.PontosVida = oponente.PontosVida - (int)dano;
                }

                if (oponente.PontosVida <= 0)
                {
                    d.Narracao += $"{oponente.Nome} foi derrotado! ";
                }

                _context.TB_PERSONAGENS.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante: {0}. ", atacante.Nome);
                dados.AppendFormat(" Oponente: {0}. ", oponente.Nome);
                dados.AppendFormat(" Pontos de vida do atacante: {0}. ", atacante.PontosVida);
                dados.AppendFormat(" Pontos de vida do oponente: {0}. ", oponente.PontosVida);
                dados.AppendFormat(" Habilidade Utilizada: {0}. ", ph.Habilidade.Nome);
                dados.AppendFormat(" Dano: {0}. ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;

                _context.TB_DISPUTAS.Add(d);
                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DisputaEmGrupo")]
        public async Task<IActionResult> DisputaEmGrupoAsync(Disputa d)
        {
            try
            {
                d.Resultados = new List<string>();

                List<Personagem> personagens = await _context.TB_PERSONAGENS
                    .Include(p => p.Arma)
                    .Include(p => p.PersonagemHabilidades).ThenInclude(ph => ph.Habilidade)
                    .Where(p => d.ListaIdPersonagens.Contains(p.Id)).ToListAsync();

                int qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;

                while (qtdPersonagensVivos > 1)
                {
                    List<Personagem> atacantes = personagens.FindAll(p => p.PontosVida > 0);
                    Personagem atacante = atacantes[new Random().Next(atacantes.Count)];

                    List<Personagem> oponentes = personagens.FindAll(p => p.Id != atacante.Id && p.PontosVida > 0);
                    Personagem oponente = oponentes[new Random().Next(oponentes.Count)];

                    int dano = 0;
                    string msgAtacante = string.Empty;
                    int sorteio = new Random().Next(2);

                    if (sorteio == 0)
                    {
                        dano = atacante.Arma.Dano + new Random().Next(atacante.Forca);
                        dano = dano - new Random().Next(oponente.Defesa);

                        if (dano > 0)
                            oponente.PontosVida -= dano;

                        msgAtacante = $"{atacante.Nome} atacou {oponente.Nome} usando {atacante.Arma.Nome} com o dano {dano}. ";
                    }
                    else
                    {
                        List<PersonagemHabilidade> phLista = atacante.PersonagemHabilidades.ToList();

                        if (phLista.Count > 0)
                        {
                            int phSorteio = new Random().Next(phLista.Count);
                            Habilidade habEscolhida = phLista[phSorteio].Habilidade;

                            dano = habEscolhida.Dano + new Random().Next(atacante.Inteligencia);
                            dano = dano - new Random().Next(oponente.Defesa);

                            if (dano > 0)
                                oponente.PontosVida -= dano;

                            msgAtacante = $"{atacante.Nome} atacou {oponente.Nome} usando {habEscolhida.Nome} com o dano {dano}. ";
                        }
                        else
                        {
                            msgAtacante = $"{atacante.Nome} não possui habilidades para atacar. ";
                        }
                    }

                    d.Resultados.Add(msgAtacante);

                    if (oponente.PontosVida <= 0)
                    {
                        oponente.Derrotas++;
                        string msgDerrota = $"{oponente.Nome} morreu! ";
                        d.Resultados.Add(msgDerrota);
                    }

                    qtdPersonagensVivos = personagens.FindAll(p => p.PontosVida > 0).Count;
                }

                Personagem campeao = personagens.Find(p => p.PontosVida > 0);
                campeao.Vitorias++;

                d.AtacanteId = campeao.Id;
                d.OponenteId = campeao.Id; 
                d.DataDisputa = DateTime.Now;

                string msgCampeao = $"{campeao.Nome.ToUpper()} é o CAMPEÃO com {campeao.PontosVida} pontos de vida restantes!";
                d.Narracao = string.Join(" ", d.Resultados) + " " + msgCampeao;

                foreach (Personagem p in personagens)
                {
                    p.Disputas++;
                    p.PontosVida = 100; 
                    _context.TB_PERSONAGENS.Update(p);
                }

                _context.TB_DISPUTAS.Add(d);
                await _context.SaveChangesAsync();

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("ApagarDisputas")]
        public async Task<IActionResult> DeleteAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();
                _context.TB_DISPUTAS.RemoveRange(disputas);
                await _context.SaveChangesAsync();
                return Ok("Disputas apagadas");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarAsync()
        {
            try
            {
                List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();
                return Ok(disputas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}