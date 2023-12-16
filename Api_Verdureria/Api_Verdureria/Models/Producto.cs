using System;
using System.Collections.Generic;

namespace Api_Verdureria.Modelos
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int? CompraId { get; set; }

        public virtual Compra? Compra { get; set; }
    }
}
