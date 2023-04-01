using Almacen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.DAO
{
    public class CrudProductos
    {
        public void AgregarProductos(Producto ParametroProducto)
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                Producto producto = new Producto();
                producto.Nombre = ParametroProducto.Nombre;
                producto.Descripcion = ParametroProducto.Descripcion;
                producto.Precio = ParametroProducto.Precio;
                producto.Stock = ParametroProducto.Stock;
                db.Add(producto);
                db.SaveChanges();
            }
        }
        public Producto UsuarioIndividual(int id)
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);

                return buscar;
            }
        }
        public void ActualizarUsuario(Producto ParamentrosUsuario, int Lector)
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {

                var buscar = UsuarioIndividual(ParamentrosUsuario.Id);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Precio = ParamentrosUsuario.Precio;
                        buscar.Nombre = ParamentrosUsuario.Nombre;
                    }
                    else
                    {
                        buscar.Descripcion = ParamentrosUsuario.Descripcion;
                        buscar.Stock = ParamentrosUsuario.Stock;
                    }

                    buscar.Descripcion = ParamentrosUsuario.Descripcion;
                    db.Update(buscar);
                    db.SaveChanges();

                }

            }
        }
        public string EliminarUsuario(int id)
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                var buscar = UsuarioIndividual(id);
                if (buscar == null)
                {
                    return "El usuario no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El usuario se elimino";
                }
            }
        }

        public List<Producto> ListarProducto()
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                return db.Productos.ToList();
            }

        }

    }
}
