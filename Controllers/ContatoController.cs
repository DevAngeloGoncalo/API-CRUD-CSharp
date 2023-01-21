using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;    
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();

            return Ok(contato);     
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID(int id)
        {
            //vai pegar o contato com o ID recebido pela API.
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(contato);
            }
        }  
    }
}