using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        //private readonly DataContext _context;
        
        public IEnumerable<Evento> _evento = new Evento[]
            {
                new Evento(){
                    EventoId = 1,
                    Local = "Belo Horizonte",
                    Lote = "1° lote",
                    Tema = "Angular e Suas Novidades",
                    QtdPessoas = 250,                   
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImageURL = "foto.png"
            },
             new Evento(){
                    EventoId = 2,
                    Local = "Salvador",
                    Lote = "1° lote",
                    Tema = "Angular e Suas Novidades",
                    QtdPessoas = 250,                   
                    DataEvento = DateTime.Now.AddDays(2).ToString(),
                    ImageURL = "foto.png"
            }
                                
            };

        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            
            return _evento.FirstOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public String Post()
        {
            return "Exemplo de Post";
        } 

        [HttpPut("{id}")]
        public String Put(int id)
        {
            return $"Exemplo de put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de delete com id = {id}";
        }
    }
}

