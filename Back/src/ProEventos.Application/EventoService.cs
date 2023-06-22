using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        public IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
            
        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                 _geralPersist.Add<Evento>(model);

                 if(await _geralPersist.SaveChangesAsync())
                 {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id);
                 }
                 else
                 {
                    return null;
                 }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                 var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                 if(evento == null)
                 {
                     return null;   
                 }
                 else
                 {
                    model.Id = evento.Id;
                    _geralPersist.Update(model);
                    if(await _geralPersist.SaveChangesAsync())
                    {
                        return await _eventoPersist.GetEventoByIdAsync(model.Id);
                    }
                    else
                    {
                        return null;
                    }
                 }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                 var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                 if(evento == null)
                 {
                     throw new Exception("Evento para delete não encontrado");
                 }
                 else
                 {
                    _geralPersist.Delete<Evento>(evento);
                    
                    return await _geralPersist.SaveChangesAsync();
                    
                 }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventoAsync(includePalestrantes);
                if(eventos == null)
                {
                    return null;    
                }
                else
                {
                    return eventos;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null)
                {
                    return null;    
                }
                else
                {
                    return eventos;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if(eventos == null)
                {
                    return null;    
                }
                else
                {
                    return eventos;
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }       
    }
}