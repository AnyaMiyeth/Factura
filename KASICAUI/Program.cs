using System;
using System.Collections.Generic;
using Entity;
namespace KASICAUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Producto producto1 = new Producto()
            {
                Codigo = "001",
                Descripcion = "Zapatos PEPE",
                PrecioCosto = 20000,
                PrecioVenta = 20000,
                Existencias = 20,
                Descuento = 10,
                PorcentajeIVA = 19,
                Estado = "AC"
            };

            Producto producto2 = new Producto()
            {
                Codigo = "002",
                Descripcion = "Zapatos JUANCHO",
                PrecioCosto = 20000,
                PrecioVenta = 20000,
                Existencias = 20,
                Descuento =10,
                PorcentajeIVA=19,
                Estado = "AC"
            };

            List<Producto>productos = new List<Producto>();

            productos.Add(producto1);
            productos.Add(producto2);
            Cliente cliente = new Cliente()
            {
                Identificacion = "001",
                Nombre="Juliana",
                Direccion="Calle 5",
                Telefono="3102568987",
                Correo="aa@hh.com"
                
            };

            Factura factura = new Factura()
            {
                Codigo = 1,
                FechaFactura = DateTime.Now,
                Cliente = cliente,
                
            };
           
        
           
            factura.AgregarDetallesFactura(producto1, 10);
            factura.AgregarDetallesFactura(producto2, 10);



            foreach (var item in factura.GetDetallesFactura())
            {
                Console.WriteLine(item.ToString());
            }


            foreach (var item in factura.GetDetallesFactura())
            {
                Console.WriteLine(item.Producto.ToString());
                item.Producto.DescontarExitencias(item.Cantidad);
                Console.WriteLine(item.Producto.ToString());
            }


            Console.WriteLine(factura.ToString());
            Console.ReadKey();
           

        }
    }
}
