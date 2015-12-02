using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal
{
 public   class Factura
    {
     [Key]
     public int IdFactura { get; set; }
     public virtual Asistente AsistenteId { get; set; }
     public virtual int IdServicio { get; set; }
     public virtual Proveedor ProveedorId { get; set; }
     public DateTime Fecha { get; set; }
     public int ServicioIdServicio { get; set; }
    }
}
