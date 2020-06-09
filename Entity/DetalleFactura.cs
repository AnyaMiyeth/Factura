using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class DetalleFactura
    {
        public Factura Factura { get; set; }
        public string Descripcion 
        { 
            get 
            { 
                return Producto.Descripcion; 
            } 
        }
        public string Codigo { get; set; }
        public Producto Producto { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal PorcentajeDescuento { get; set; }

        public DetalleFactura(Producto producto, int cantidad)
        {
            Producto = producto;
            ValorUnitario = producto.PrecioVenta;
            PorcentajeDescuento = producto.Descuento;
            PorcentajeIva = producto.PorcentajeIVA;
            Cantidad = cantidad;
          
        }

        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }

        public decimal Subtotal
        {
            get
            {
                return ValorUnitario * Cantidad;
            }
        }
        public decimal ValorDescuento
        {
            get
            {
                return Subtotal * (PorcentajeDescuento / 100);
            }
        }

        public decimal ValorDespuesDescuento
        {
            get
            {
                return Subtotal -ValorDescuento;
            }
        }
        public decimal ValorIVA
        {
            get
            {
                return ValorDespuesDescuento * (PorcentajeIva/100);
            }
        }
       
        public decimal Total
        { 
            get 
            {
                return Subtotal-ValorDescuento+ValorIVA;
            } 
        }

        public override string ToString()
        {
            return ($" Factura {Factura.Codigo} Codigo:{Codigo} ValorUnitario: {ValorUnitario} Cantidad: {Cantidad} subtotal: {Subtotal} descuento: {ValorDescuento} Iva: {ValorIVA} total: {Total}");
        }
    }
}
