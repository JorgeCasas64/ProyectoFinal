using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal
{
   public class Asistente
    {
       [Key]
       public int IdAsistente { get; set; }
       public String Nombre { get; set; }
       public String Apellido { get; set; }
       public String Telefono { get; set; }
    }
}
