using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1.Entidades
{
    public class ServicioDetalles
    {
        [Key]
        public int DetalleId { get; set; }
        public int EstudianteId { get; set; }
        public string NombreCategoria { get; set; }
 
        public int FacturaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Importe { get; set; }


        public ServicioDetalles()
        {
            DetalleId = 0;
            EstudianteId = 0;
            NombreCategoria = string.Empty;
            FacturaId = 0;
            Cantidad = 0;
            Precio = 0;
           Importe = 0;

        }

        public ServicioDetalles(int DetalleId, int EstudianteId, string NombreCategoria,int FacturaId, int Cantidad, decimal Precio, decimal Importe)
        {
            this.DetalleId = DetalleId;
            this.EstudianteId = EstudianteId;
            this.NombreCategoria = NombreCategoria;
            this.FacturaId = FacturaId;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Importe = Importe;
        }
    }
}