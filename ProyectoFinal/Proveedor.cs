using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace ProyectoFinal
{
   public  class Proveedor
    {
       [Key]
        public int IdProveedor { get; set; }
        public String NombreProveedor { get; set; }
        public String Direccion { get; set; }
        public String Giro { get; set; }
        public virtual ICollection<Servicio> Servicios {get;set;}
        public virtual ICollection<Factura> Factura { get; set; }
    }
     
}
