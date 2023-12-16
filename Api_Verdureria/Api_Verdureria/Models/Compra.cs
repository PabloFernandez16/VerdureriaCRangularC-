using System;
using System.Collections.Generic;

namespace Api_Verdureria.Modelos
{
    public partial class Compra
    {
        public Compra()
        {
            Productos = new HashSet<Producto>();
        }

        public int CompraId { get; set; }
        public int? ClienteId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
