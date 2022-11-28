using APITecsup.Models.Request;
using APITecsup.Models.Response;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace APITecsup.Controllers
{
    public class PeopleController : ApiController
    {
        // GET: People

        public List<PersonResponse> Get()
        {

            var service = new PersonService();            
            var people = service.Get();

            //Convert Domaint to Response
            var response = people.Select(x => new PersonResponse {
                FullName= string.Concat( x.FirstName, " ", x.LastName )
            }).ToList();

            return response;            
        }
        [HttpPost]
        public bool Insert(PersonRequest request)
        {
            var response = true;
            try
            {
                var service = new PersonService();
                service.Insert(new Domain.Person
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName
                });
            }
            catch (Exception )
            {
                //log ex
                response = false;
            }
            return response;
        }

        // PUT
        [HttpPut]
        public bool Actualizar(int id, ProductoResponse request)
        {

            var response = true;
            try
            {
                var service = new ProductoService();
                service.Update(new Domain.Producto
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    FechaCreacion = request.FechaCreacion,
                    FechaVencimiento = request.FechaVencimiento,
                    PrecioVenta = request.PrecioVenta
                }, id);

            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }

        // DELETE: 
        public IHttpActionResult DeleteProduct(int id)
        {
            var response = true;
            try
            {
                var service = new ProductoService();
                service.Delete(id);

            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return Ok(response);
        }
    }
}