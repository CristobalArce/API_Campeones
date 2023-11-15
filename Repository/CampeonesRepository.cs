using API_Campeones.ContextBD;
using API_Campeones.Dto;
using API_Campeones.Repository.Interface;
using API_Campeones.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API_Campeones.Response.CampeonesResponse;

namespace API_Campeones.Repository
{
    public class CampeonesRepository : ICampeonesRepository
    {
        private readonly CampeonesContext _context;
        private readonly IMapper _mapper;

        public CampeonesRepository(CampeonesContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        async public Task<CampeonResponse> GetCampeon(int idCampeon)
        {
            var response = new CampeonResponse();

            try
            {
                var campeon = await _context.Tbcampeon.FirstOrDefaultAsync(e => e.IdCampeon == idCampeon);
                if (campeon == null)
                {
                    response.Estado = "OK";
                    response.Mensaje = "No se encontro el campeon";
                    response.NumeroEstado = 0;
                    response.Campeon = campeon;
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "Se obtuvo el campeon correctamente";
                    response.NumeroEstado = 0;
                    response.Campeon = campeon;
                }
            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 0;
            }

            return response;
        }

        async public Task<ListaCampeonesResponse> GetListaCampeones()
        {
            var response = new ListaCampeonesResponse();

            try
            {
                var listCampeones = await _context.Tbcampeon.ToListAsync();
                response.Estado = "OK";
                response.Mensaje = "Se obtuvo el campeon correctamente";
                response.NumeroEstado = 0;
                response.ListaCampeones = listCampeones;
            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 0;
            }
            
            return response;
        }

        async public Task<CampeonResponse> DeleteCampeon(int idCampeon)
        {
            var response = new CampeonResponse();
            try
            {
                var campeon = await GetCampeon(idCampeon);
                if (campeon.Campeon != null)
                {
                    _context.Tbcampeon.Remove(campeon.Campeon);
                    await _context.SaveChangesAsync();

                    response.Campeon = campeon.Campeon;
                    response.Estado = "OK";
                    response.Mensaje = "Se elimino el campeon correctamente";
                    response.NumeroEstado = 0;
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "No se encontro el campeon";
                    response.NumeroEstado = 0;
                    response.Campeon = null;
                }
                

            }
            catch(Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 0;
            }
            

            return response;
        }

        async public Task<CampeonResponse> PostCampeon(Tbcampeon campeonNuevo)
        {
            var response = new CampeonResponse();

            try
            {
                var campeon = new Tbcampeon()
                {
                    Nombre = campeonNuevo.Nombre,
                    Descripcion = campeonNuevo.Descripcion,
                    IdDificultad = campeonNuevo.IdDificultad,
                    IdRol = campeonNuevo.IdRol,
                };

                await _context.Tbcampeon.AddAsync(campeon);
                await _context.SaveChangesAsync();

                response.Campeon = campeon;
                response.Estado = "OK";
                response.Mensaje = "Se agrego el campeon correctamente";
                response.NumeroEstado = 0;
            }
            catch(Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 3;
            }
            
            return response;
        }

        async public Task<CampeonResponse> PutCampeon(Tbcampeon campeonModificado)
        {
            var response = new CampeonResponse();
            try
            {
                var campeon = GetCampeon(campeonModificado.IdCampeon).Result;

                campeon.Campeon.Descripcion = campeonModificado.Descripcion;
                campeon.Campeon.IdDificultad = campeonModificado.IdDificultad;
                campeon.Campeon.IdRol = campeonModificado.IdRol;
                campeon.Campeon.Nombre = campeonModificado.Nombre;

                _context.Entry(campeon.Campeon).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                response.Estado = "OK";
                response.Mensaje = "Se modifico el objeto correctamente";
                response.NumeroEstado = 0;
                response.Campeon = campeon.Campeon;

            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 3;
            }
            
            return response;
        }

        async public Task<CampeonDetalladoDTOResponse> GetCampeonDetallado(int idCampeon)
        {
            var response = new CampeonDetalladoDTOResponse();

            try
            {
                var query = await (from camp in _context.Tbcampeon.AsQueryable()
                                   join r in _context.Tbrol.AsQueryable()
                                       on camp.IdRol equals r.IdRol
                                   join dif in _context.Tbdificultad.AsQueryable()
                                       on camp.IdDificultad equals dif.IdDificultad
                                   where camp.IdCampeon == idCampeon
                                   select new Tbcampeon
                                   {
                                       IdCampeon = camp.IdCampeon,
                                       Nombre = camp.Nombre,
                                       Descripcion = camp.Descripcion,
                                       IdRolNavigation = r,
                                       IdDificultadNavigation = dif
                                   }).FirstOrDefaultAsync();

                var campeonDTO = _mapper.Map<Tbcampeon, CampeonDto>(query);

                if ( query == null)
                {
                    response.Estado = "OK";
                    response.Mensaje = "No se encontro ningun campeon";
                    response.NumeroEstado = 0;
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "Se obtuvieron los campeones detallado";
                    response.NumeroEstado = 0;
                    response.CampeonDetallado = campeonDTO;
                }

                response.CampeonDetallado = campeonDTO;
                response.NumeroEstado = 0;
                response.Mensaje = "Se obtuvo la informacion del campeon correctamente";
                response.Estado = "OK";
            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 3;
            }

            return response;
        }

        async public Task<ListaCampeonesDetalladosDTOResponse> GetCampeonesDetallados()
        {
            var response = new ListaCampeonesDetalladosDTOResponse();

            try
            {
                var query = await (from camp in _context.Tbcampeon.AsQueryable()
                                   join r in _context.Tbrol.AsQueryable()
                                       on camp.IdRol equals r.IdRol
                                   join dif in _context.Tbdificultad.AsQueryable()
                                       on camp.IdDificultad equals dif.IdDificultad
                                   select new Tbcampeon
                                   {
                                       IdCampeon = camp.IdCampeon,
                                       Nombre = camp.Nombre,
                                       Descripcion = camp.Descripcion,
                                       IdRolNavigation= r,
                                       IdDificultadNavigation = dif
                                   }).ToListAsync();

                var campeonDTO = _mapper.Map<List<Tbcampeon>, List<CampeonDto>>(query);

                if (query == null)
                {
                    response.Estado = "OK";
                    response.Mensaje = "No se encontro ningun campeon";
                    response.NumeroEstado = 0;
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "Se obtuvieron los campeones detallado";
                    response.NumeroEstado = 0;
                    response.ListaCampeones = campeonDTO;
                }
                
            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un error: " + ex;
                response.NumeroEstado = 3;
            }            

            return response;
        }
    }
}
