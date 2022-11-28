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
    public class ProductoController : ApiController
    {
        // GET: Producto
        public List<ProductoResponse> Get()
        {

            var service = new ProductoService();
            var producto = service.Get();

            //Convert Domaint to Response
            var response = producto.Select(x => new ProductoResponse
            {
                ProductoID = x.ProductoID,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                PrecioVenta = x.PrecioVenta,
                FechaCreacion  = x.FechaCreacion,
                FechaVencimiento = x.FechaVencimiento,
                IGV = x.IGV
            }).ToList();

            return response;
        }

        [HttpPost]
        public bool Insert(ProductoRequest request)
        {
            var response = true;
            try
            {
                var service = new ProductoService();
                service.Insert(new Domain.Producto
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    PrecioVenta = Convert.ToDouble(request.PrecioVenta),
                    FechaVencimiento = request.FechaVencimiento
                });
            }
            catch (Exception)
            {
                //log ex
                response = false;
            }
            return response;
        }

        // GET: By ID
        [HttpGet]
        public IHttpActionResult GetProdById(int id)
        {
            var service = new ProductoService();
            var prod = service.GetById(id);

            return Ok(prod);
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