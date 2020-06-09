using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Factura
    {
        public long Codigo { get; set; }
        public DateTime FechaFactura { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Subtotal
        {
            get 
            {
               return detallesFactura.Sum(d => d.Subtotal);
            }
        }
        public decimal IVA
        {
            get
            {
                return detallesFactura.Sum(d => d.ValorIVA);
            }
        }
        public decimal Descuento
        {
            get
            {
                return detallesFactura.Sum(d => d.ValorDescuento);
            }
        }
        public decimal Total
        {
            get
            {
                return Subtotal-Descuento+IVA;
            }
        }

        private List<DetalleFactura> detallesFactura;

        public Factura()
        {
            detallesFactura = new List<DetalleFactura>();
        }

        public DetalleFactura AgregarDetallesFactura(Producto producto,int cantidad)
        {
            if (cantidad<=0)
            {
                return null;
            }
            DetalleFactura detalleFactura = new DetalleFactura(producto,cantidad);
            detalleFactura.Codigo = GenerarId().ToString();
            detalleFactura.Factura = this;
            detallesFactura.Add(detalleFactura);
            return detalleFactura;

        }

        public List<DetalleFactura> GetDetallesFactura()
        {
           return detallesFactura;

        }

        public int GenerarId() {
           
                return detallesFactura.Count>0? Int32.Parse(detallesFactura.Max(d => d.Codigo))+1 : 1;
        }


        public override string ToString()
        {
            return $"Cliente:{Cliente.Nombre} Cliente:{Cliente.Identificacion} Factura:{Codigo} Fecha:{FechaFactura} Subtotal:{Subtotal}  Descuentos:{Descuento} IVA:{IVA} total:{Total}";
                
        }


    }
}
