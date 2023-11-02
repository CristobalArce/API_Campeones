using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static API_Campeones.Response.DificultadesResponse;

namespace API_Campeones.Repository
{
    public class DificultadesRepository : IDificultadesRepository
    {
        private readonly CampeonesContext _context;

        public DificultadesRepository(CampeonesContext context)
        {
            this._context = context;
        }

        async public Task<ListaDificultadesResponse> GetListaDificultades()
        {
            var response = new ListaDificultadesResponse();

            try
            {
                var listDificultades = await _context.Tbdificultad.ToListAsync();

                response.Estado = "OK";
                response.Mensaje = "Se obtuvo el campeon correctamente";
                response.NumeroEstado = 0;
                response.ListaDificultades = listDificultades;
            }
            catch (Exception ex)
            {
                response.NumeroEstado = 2;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            
            return response;
        }
        
        async public Task<DificultadResponse> GetDificultad(int idCampeon)
        {
            var response = new DificultadResponse();

            try
            {
                var dificultad = await _context.Tbdificultad.FirstOrDefaultAsync(e => e.IdDificultad == idCampeon);
                if (dificultad == null)
                {
                    response.NumeroEstado = 1;
                    response.Estado = "NOK";
                    response.Mensaje = "No se encontro la dificultad solicitada";
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "La dificultad ingresada fue encontrata exitosamente";
                    response.NumeroEstado = 0;
                    response.Dificultad = dificultad;
                }
            }
            catch (Exception ex)
            {
                response.NumeroEstado = 2;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            
            return response;
        }

        async public Task<DificultadResponse> DeleteDificultad(int idCampeon)
        {
            var response = new DificultadResponse();
            try
            {
                var dificultad = await GetDificultad(idCampeon);

                if (dificultad == null)
                {
                    response.Estado = "NOK";
                    response.Mensaje = "La dificultad solicitada no se encontro";
                    response.NumeroEstado = 1;
                }
                else
                {
                    _context.Tbdificultad.Remove(dificultad.Dificultad);
                    await _context.SaveChangesAsync();

                    response.Dificultad = dificultad.Dificultad;
                    response.Estado = "OK";
                    response.Mensaje = "La dificultad se elimino correctamente";
                    response.NumeroEstado = 0;
                }
 
            }
            catch (Exception ex)
            {
                response.NumeroEstado = 2;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            

            return response;
        }

        async public Task<DificultadResponse> PostDificultad(Tbdificultad dificultadNueva)
        {
            var response = new DificultadResponse();

            try
            {
                var dificultad = new Tbdificultad()
                {
                    Nombre = dificultadNueva.Nombre,
                };

                await _context.Tbdificultad.AddAsync(dificultad);
                await _context.SaveChangesAsync();

                response.Estado = "OK";
                response.Mensaje = "La dificultad fue ingresada correctamante";
                response.NumeroEstado = 0;
                response.Dificultad = dificultad;
            }
            catch (Exception ex)
            {
                response.NumeroEstado = 2;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            
            return response;
        }

        async public Task<DificultadResponse> PutDificultad(Tbdificultad dificultadModificada)
        {
            var response = new DificultadResponse();

            try
            {
                var dificultad = GetDificultad(dificultadModificada.IdDificultad).Result;

                dificultad.Dificultad.Nombre = dificultadModificada.Nombre;
                _context.Entry(dificultad.Dificultad).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                response.Estado = "OK";
                response.Mensaje = "La dificultad fue modificada correctamente";
                response.NumeroEstado = 0;
                response.Dificultad = dificultad.Dificultad;

            }
            catch (Exception ex)
            {
                response.NumeroEstado = 2;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            
            return response;
        }
    }
}
