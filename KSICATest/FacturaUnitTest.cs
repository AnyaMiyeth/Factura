using NUnit.Framework;
using Entity;
using System.Collections.Generic;
using System;

namespace KSICATest
{
    public class FacturaUnitTest
    {
        Factura factura;
        Cliente cliente;

        [SetUp]
        
        public void Setup()
        {
      
            cliente = new Cliente()
            {
                Identificacion = "001",
                Nombre = "Juliana",
                Direccion = "Calle 5",
                Telefono = "3102568987",
                Correo = "aa@hh.com"

            };

            factura = new Factura()
            {
                Codigo = 1,
                FechaFactura = DateTime.Now,
                Cliente = cliente,

            };


        }

        
        [Test]
        public void ValidarSubtotal()
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
                Descuento = 10,
                PorcentajeIVA = 19,
                Estado = "AC"
            };
    
            factura.AgregarDetallesFactura(producto1, 10);
            factura.AgregarDetallesFactura(producto2, 10);
            Assert.AreEqual(400000, factura.Subtotal);
            Assert.IsNotNull(factura);
        }
        [Test]
        public void ValidarCantidad() 
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
                Descuento = 10,
                PorcentajeIVA = 19,
                Estado = "AC"
            };

            DetalleFactura detalle1= factura.AgregarDetallesFactura(producto1, 0);
            DetalleFactura detalle2= factura.AgregarDetallesFactura(producto2, -1);
            Assert.AreEqual(null, detalle1);
            Assert.AreEqual(null, detalle2);
        }
    }
}