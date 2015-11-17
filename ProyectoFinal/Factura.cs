using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
 public   class Factura
    {
     public int IdFactura { get; set; }
     public virtual int IdProvedor { get; set; }
     public virtual int IdAsistente { get; set; }
     public virtual int IdServicio { get; set; }
     public float Precion { get; set; }
    }
}
