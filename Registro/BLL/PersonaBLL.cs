using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using  Registro.Model;

namespace Registro.BLL
{
     public class PersonaBLL
     {
          private Contexto contextos;

          public PersonaBLL(Contexto contexto)
          {
               contextos = contexto;
          }

          public bool Existe(int PersonaId)
          {
               return contextos.Persona.Any(o => o.PersonaId == PersonaId);
          }

          private bool Insertar(Persona persona)
          {
               contextos.Persona.Add(persona);
               return contextos.SaveChanges() > 0;
          }

          private bool Modificar(Persona persona)
          {
               contextos.Entry(persona).State = EntityState.Modified;
               return contextos.SaveChanges() > 0;
          }

          public bool Guardar(Persona persona)
          {
               if (!Existe(persona.PersonaId))
                    return this.Insertar(persona);
               else
                    return this.Modificar(persona);
          }

          public bool Eliminar(Persona persona)
          {
               contextos.Entry(persona).State = EntityState.Deleted;
               return contextos.SaveChanges() > 0;
          }

          public Persona? Buscar(int personaId)
          {
               return contextos.Persona
                       .Where(o => o.PersonaId == personaId)
                       .AsNoTracking()
                       .SingleOrDefault();
          }

     }
}