// See https://aka.ms/new-console-template for more information
using Almacen.DAO;
using Almacen.Models;

//Console.WriteLine("Hello, World!");

#region Anterior
//using AlmacenContext db = new AlmacenContext();

//Producto producto = new Producto();

//Console.WriteLine("Ingrese nombre del producto");
//producto.Nombre = (Console.ReadLine());

//Console.WriteLine("Ingrese descripciòn");
//producto.Descripcion = (Console.ReadLine());

//Console.WriteLine("Ingrese el precio");
//producto.Precio = Convert.ToDecimal(Console.ReadLine());

//Console.WriteLine("Ingrese el stock");
//producto.Stock = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine($"Los datos que ingreso son: Nombre {producto.Nombre}, Descripcion {producto.Descripcion}, Precio {producto.Precio} y Stock {producto.Stock} ");

//db.Productos.Add(producto);
//db.SaveChanges();
#endregion
CrudProductos CrudProductos = new CrudProductos();
Producto producto = new Producto();

Console.Write("Menu\n");
Console.Write("Presione 1 para ingresar\n");
Console.Write("Presione 2 para actualizar\n");
Console.Write("Presione 3 para elimar\n");
Console.Write("Presione 4 para listar\n");

var Menu = Convert.ToInt32(Console.ReadLine());

switch (Menu)
{
    case 1:
        int bucle = 1;
        while (bucle == 1);
        {
            Console.Write("Ingrese el nombre del producto");
            producto.Nombre = Console.ReadLine();
            Console.Write("\nIngrese una breve descripcion del producto");
            producto.Descripcion = Console.ReadLine();
            Console.Write("\nIngrese el precio del producto");
            producto.Precio = Convert.ToDecimal(Console.ReadLine());
            Console.Write("\nIngrese la cantidad de productos existentes");
            producto.Stock = Convert.ToInt32(Console.ReadLine());

            CrudProductos.AgregarProductos(producto);

            Console.Write("Se ingreso correctamente\n");
            Console.Write("Presione 1 para ingresar\n");
            Console.Write("Presione 2 para actualizar\n");
            Console.Write("Presione 3 para elimar\n");
            Console.Write("Presione 4 para listar\n");
            Console.Write("Presione 0 para salir\n");

            bucle = Convert.ToInt32(Console.ReadLine());
        }
        break;

    case 2:
        Console.WriteLine("Actualizar datos");
        Console.WriteLine("Ingresa el ID del usuario a actualizar");
        var UsuarioIndividualU = CrudProductos.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
        if (UsuarioIndividualU == null)
        {
            Console.WriteLine("El Usuario no existe");
        }
        else
        {
            Console.WriteLine($"Precio {UsuarioIndividualU.Precio}, Stock{UsuarioIndividualU.Stock}, Nombre {UsuarioIndividualU.Nombre}, Descripcion {UsuarioIndividualU.Descripcion}");

            Console.WriteLine("");

            Console.WriteLine("Para Actualizar Nombre y Precio preciona 1");

            Console.WriteLine("");

            Console.WriteLine("Para Actualizar Descripcion y Stock preciona 2");

            var Lector = Convert.ToInt32(Console.ReadLine());
            if (Lector == 1)
            {
                Console.WriteLine("Ingrese el nuevo Nombre");
                UsuarioIndividualU.Nombre = (Console.ReadLine());

                Console.WriteLine("");

                Console.WriteLine("Ingrese el nuevo Precio");
                UsuarioIndividualU.Precio = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Ingrese la nueva Descripcion");
                UsuarioIndividualU.Descripcion = (Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo Stock");
                UsuarioIndividualU.Stock = Convert.ToInt32(Console.ReadLine());
            }
            CrudProductos.ActualizarUsuario(UsuarioIndividualU, Lector);
            Console.WriteLine("Actualizacion Correcta");
        }
        break;
    case 3:
        Console.WriteLine("Ingresa el Id a Eliminar");
        var UsuarioIndividualD = CrudProductos.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
        if (UsuarioIndividualD == null)
        {
            Console.WriteLine("Este Usuario no Existe");
        }
        else
        {
            Console.WriteLine("Eliminar usuario");
            Console.WriteLine($"Nombre: {UsuarioIndividualD.Nombre}, Descripcion: {UsuarioIndividualD.Descripcion}, Precio: {UsuarioIndividualD.Precio}, Stock: {UsuarioIndividualD.Stock},");
            Console.WriteLine("El usuario encontrado es el correcto? presione 1 si es asi");
            var Lector = Convert.ToInt32(Console.ReadLine());
            if (Lector == 1)
            {
                var Id = Convert.ToInt32(UsuarioIndividualD.Id);
                Console.WriteLine(CrudProductos.EliminarUsuario(Id));
            }
            else
            {
                Console.WriteLine("Inicia Nuevamente");
            }
        }
        break;
    case 4:
        Console.WriteLine("Lista de Productos");
        var ListarProducto = CrudProductos.ListarProducto();
        foreach (var iteracionProducto in ListarProducto)
        {
            Console.WriteLine($"{iteracionProducto.Id}, {iteracionProducto.Nombre},  {iteracionProducto.Descripcion}, {iteracionProducto.Precio}, {iteracionProducto.Stock}");

        }
        break;
}