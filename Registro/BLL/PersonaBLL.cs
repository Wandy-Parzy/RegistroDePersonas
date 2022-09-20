using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using  Registro.Model;

namespace Registro.BLL
{
     public class PersonaBLL
     {
          private Contexto _contextos;

          public PersonaBLL(Contexto contexto)
          {
               _contextos = contexto;
          }

          public bool Existe(int PersonaId)
          {
               return _contextos.Persona.Any(o => o.PersonaId == PersonaId);
          }

          private bool Insertar(Persona persona)
          {
               _contextos.Persona.Add(persona);
               return _contextos.SaveChanges() > 0;
          }

          private bool Modificar(Persona persona)
          {
               _contextos.Entry(persona).State = EntityState.Modified;
               return _contextos.SaveChanges() > 0;
          }

          public bool Guardar(Persona persona)
          {
               if (!Existe(persona.PersonaId))
                    return this.Insertar(persona);
               else
                    return this.Modificar(persona);
          }

          public bool Eliminar1(Persona persona)
          {
               _contextos.Entry(persona).State = EntityState.Deleted;
               return _contextos.SaveChanges() > 0;
          }

          public Persona? Buscar1(int personaId)
          {
               return _contextos.Persona
                       .Where(o => o.PersonaId == personaId)
                       .AsNoTracking()
                       .SingleOrDefault();

          }

          public bool Editar(Persona persona)
          {
               if (!Existe(persona.PersonaId))
                    return this.Insertar(persona);
               else
                    return this.Modificar(persona);
          }
          public List<Persona> GetList(Expression<Func<Persona, bool>> Criterio)
          {
               return _contextos.Persona
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
         public List<Ocupaciones> GetOcupaciones(Expression<Func<Ocupaciones, bool>> Criterio){
            return _contextos.Ocupaciones
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

     }
}