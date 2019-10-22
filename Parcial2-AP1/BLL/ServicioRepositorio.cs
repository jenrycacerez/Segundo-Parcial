using Parcial2_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_AP1.BLL
{
    public class ServicioRepositorio : RepositorioBase<Factura>
    {
        public override Factura Buscar(int id)
        {
            try
            {
                Factura estudiante = new Factura();

                estudiante = _contexto.Factura.Find(id);
                estudiante.Detalles.Count();

                
            }
            catch { }
            return base.Buscar(id);
        }

        public override bool Modificar(Factura entity)
        {
            var Anterior = _contexto.Factura.Find(entity.FacturaID);
      
            bool paso = false;
            try
            {
                foreach (var item in entity.Detalles)
                {
                    if (!Anterior.Detalles.Exists(d => d.DetalleId == item.DetalleId))
                   {
                        _contexto.ServicioDetalles.Remove(item);
                        _contexto.SaveChanges();
                        paso = true;
                    }
                  
                }
            }
            catch { }
            Anterior = _contexto.Factura.Find(entity.FacturaID);
            Anterior.Estudiante = entity.Estudiante;
            Anterior.Total = entity.Total;
          
         
            return base.Modificar(Anterior);
        }
    }
}
