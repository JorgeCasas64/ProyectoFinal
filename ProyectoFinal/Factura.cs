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
     public virtual int IdAsistente { get; set; }
     public virtual int IdServicio { get; set; }
     
    }
}
