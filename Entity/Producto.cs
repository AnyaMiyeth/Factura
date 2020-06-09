using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Existencias { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal PrecioCosto{ get; set; }

        public decimal Descuento{ get; set; }
        public string Estado { get; set; }
        public void DescontarExitencias(int cantidad) 
        {

            Existencias -= cantidad;
        }

        public override string ToString()
        {
            return  $" Nombre {Descripcion} Codigo{Codigo} Existencias{Existencias}";
        }

    }
}
