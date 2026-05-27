using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Personagens aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult QualquerCoisa(string nome)
        {
            Personagem pBusca = personagens.FirstOrDefault(pe => pe.Nome == nome);

            if(pBusca == null)
                return NotFound("Personagem não encontrado");

            return Ok(pBusca);
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            personagens.RemoveAll(x => x.Classe == ClasseEnum.Cavaleiro);
            return Ok(personagens.OrderByDescending(x => x.PontosVida));
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int qtd = personagens.Count;
            int somaInteligencia = personagens.Sum(laranja => laranja.Inteligencia);

            return Ok("Quantidade" + qtd + " Soma das inteligencias: " + somaInteligencia);            
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem p)
        {
            if(p.Defesa < 10 || p.Inteligencia > 30)
                return BadRequest("Defesa não pode ser menor que 10 ou inteligência não pode ser maior que 30.");

            personagens.Add(p);
            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem p)
        {
            if(p.Classe == ClasseEnum.Mago && p.Inteligencia < 35)
                return BadRequest("Magos não pode ter inteligÊncia menor que 35");

            personagens.Add(p);
            return Ok(personagens);
        }

        [HttpGet("GetByClasse/{enumId}")]
        public IActionResult GetByClasse(int enumId)
        {
            ClasseEnum enumDigitado = (ClasseEnum)enumId;

            List<Personagem> busca = 
                personagens.FindAll(x => x.Classe == enumDigitado);

            return Ok(busca);
        }
        





    }
}