using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1.Entidades
{
    public class Factura
    {
         
        [Key]
       public int FacturaID { get; set; }

       public DateTime Fecha { get; set; }

        public string Estudiante { get; set; }
        
        public decimal Total { get; set; }
        public virtual List<ServicioDetalles> Detalles { get; set; }
        public Factura()
        {
            this.FacturaID = 0;
            this.Fecha = DateTime.Now;
            this.Estudiante = string.Empty;
            
            this.Total = 0;
            Detalles = new List<ServicioDetalles>();
        }

        
    }
}

    

