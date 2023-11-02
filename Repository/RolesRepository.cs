using API_Campeones.ContextBD;
using API_Campeones.Repository.Interface;
using API_Campeones.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static API_Campeones.Response.RolesResponse;

namespace API_Campeones.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly CampeonesContext _context;

        public RolesRepository(CampeonesContext context)
        {
            this._context = context;
        }
        async public Task<ListaRolesResponse> GetListaRoles()
        {
            var response = new ListaRolesResponse();

            try
            {
                var listRoles = await _context.Tbrol.ToListAsync();

                response.NumeroEstado = 0;
                response.Estado = "OK";
                response.Mensaje = "Se realizo las acciones correctamente.";
                response.ListaRoles = listRoles;
            }
            catch (Exception ex)
            {
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }

            return response;
        }

        async public Task<RolResponse> GetRol(int idRol)
        {
            var response = new RolResponse();

            try
            {
                var rol = await _context.Tbrol.FirstOrDefaultAsync(e => e.IdRol == idRol);

                if (rol == null)
                {
                    response.NumeroEstado = 0;
                    response.Estado = "OK";
                    response.Mensaje = "El id del rol no se encontro en la base de datos";
                }
                else
                {
                    response.Estado = "OK";
                    response.Mensaje = "Se realizo las acciones correctamente.";
                    response.Rol = rol;
                }
            }
            catch (Exception ex)
            {
                response.NumeroEstado = -1;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;

            }
            
            return response;
        }

        async public Task<RolResponse> DeleteRol(int idRol)
        {
            var response = new RolResponse();
            
            var rol = await GetRol(idRol);

            if (rol.NumeroEstado ==  -1 || rol.NumeroEstado == 1)
            {
                response.NumeroEstado = rol.NumeroEstado;
                response.Estado = rol.Estado;
                response.Mensaje = rol.Mensaje;
            }
            else
            {
                try
                {
                    _context.Tbrol.Remove(rol.Rol);
                    await _context.SaveChangesAsync();

                    response.NumeroEstado = 0;
                    response.Estado = "OK";
                    response.Mensaje = "Se realizo las acciones correctamente.";
                    response.Rol = rol.Rol;
                }
                catch(Exception ex)
                {
                    response.NumeroEstado = -1;
                    response.Estado = "NOK";
                    response.Mensaje = "Ocurrio un problema: " + ex;

                }
                
            }

            return response;
        }

        async public Task<RolResponse> PostRol(Tbrol rolNuevo)
        {
            var response = new RolResponse();

            var rol = new Tbrol()
            {
                Nombre = rolNuevo.Nombre,
            };

            try
            {
                await _context.Tbrol.AddAsync(rol);
                await _context.SaveChangesAsync();

                response.NumeroEstado = 0;
                response.Estado = "OK";
                response.Mensaje = "El rol fue agregado correctamente";
                response.Rol = rol;

            }
            catch(Exception ex)
            {
                response.NumeroEstado = -1;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }
            

            return response;
        }

        async public Task<RolResponse> PutRol(Tbrol rolModificado)
        {
            var response = new RolResponse();
            

            try
            {
                var rol = GetRol(rolModificado.IdRol).Result;

                rol.Rol.Nombre = rolModificado.Nombre;
                _context.Entry(rol.Rol).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                response.NumeroEstado = 0;
                response.Estado = "OK";
                response.Mensaje = "El rol fue modificado correctamente";
                response.Rol = rol.Rol;

            }
            catch (Exception ex)
            {
                response.NumeroEstado = -1;
                response.Estado = "NOK";
                response.Mensaje = "Ocurrio un problema: " + ex;
            }

            return response;
        }
    }
}
