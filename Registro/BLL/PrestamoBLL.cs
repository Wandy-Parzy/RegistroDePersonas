using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using  Registro.Model;

namespace Registro.BLL
{
     public class PrestamoBLL
     {
          private Contexto __contexto;

          public PrestamoBLL(Contexto contexto)
          {
               __contexto = contexto;
          }

          public bool Existe2(int PrestamosId)
          {
               return __contexto.Prestamos.Any(o => o.PrestamoId == PrestamosId);
          }

          private bool Insertar2(Prestamos prestamos)
          {
               __contexto.Prestamos.Add(prestamos);
               return __contexto.SaveChanges() > 0;
          }

          private bool Modificar2(Prestamos prestamos)
          {
               __contexto.Entry(prestamos).State = EntityState.Modified;
               return __contexto.SaveChanges() > 0;
          }

          public bool Guardar2(Prestamos prestamos)
          {
               if (!Existe2(prestamos.PrestamoId))
                    return this.Insertar2(prestamos);
               else
                    return this.Modificar2(prestamos);
          }

          public bool Eliminar2(Prestamos prestamos)
          {
               __contexto.Entry(prestamos).State = EntityState.Deleted;
               return __contexto.SaveChanges() > 0;
          }

          public Prestamos? Buscar2(int prestamoId)
          {
               return __contexto.Prestamos
                       .Where(o => o.PrestamoId == prestamoId)
                       .AsNoTracking()
                       .SingleOrDefault();

          }

          public bool Editar(Prestamos prestamos)
          {
               if (!Existe2(prestamos.PrestamoId))
                    return this.Insertar2(prestamos);
               else
                    return this.Modificar2(prestamos);
          }
          public List<Prestamos> GetList(Expression<Func<Prestamos, bool>> Criterio)
          {
               return __contexto.Prestamos
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
          
         public List<Persona> GetPersonas(Expression<Func<Persona, bool>> Criterio){
            return __contexto.Persona
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

          public List<Ocupaciones> GetOcupaciones(Expression<Func<Ocupaciones, bool>> Criterio){
            return __contexto.Ocupaciones
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

     }
}