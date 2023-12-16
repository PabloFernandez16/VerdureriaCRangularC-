using System;
using System.Collections.Generic;

namespace Api_Verdureria.Modelos
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
