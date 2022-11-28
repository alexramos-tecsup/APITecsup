using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductoService
    {

        public List<Producto> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Producto.Where(x => x.IsEnable == true).ToList();
            }
        }
        public Producto GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Producto.Find(id);
            }
        }

        public void Insert(Producto producto)
        {
            using (var context = new ExampleContext())
            {

                producto.IsEnable = true;
                producto.FechaCreacion = DateTime.Today;
                producto.IGV = producto.PrecioVenta * 0.18;
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public void Update(Producto producto, int id)
        {
            using (var context = new ExampleContext())
            {
                var productoNew = context.Producto.Find(id);

                productoNew.Nombre = producto.Nombre;
                productoNew.Descripcion = producto.Descripcion;
                productoNew.PrecioVenta = producto.PrecioVenta;
                productoNew.FechaCreacion = producto.FechaCreacion;
                productoNew.FechaVencimiento = producto.FechaVencimiento;
                productoNew.IGV = producto.PrecioVenta * 0.18;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var context = new ExampleContext())
            {
                var producto = context.Producto.Find(id);
                //Eliminacion permanente context.Productos.Remove(producto);

                //Eliminación lógica
                context.Entry(producto).State = EntityState.Modified;
                producto.IsEnable = false;
                context.Producto.Where(x => x.IsEnable == false).ToList();
                context.SaveChanges();
            }
        }
    }
}
