using System.ComponentModel.DataAnnotations;

namespace Registro.Model
{
     public class Prestamos
     {
          [Key]

          public int PrestamoId { get; set; }

          public DateTime Fecha { get; set; } = DateTime.Now;

          //[Required(ErrorMessage = "El numero de telefono es requerido")]
          public DateTime Vence { get; set; }

        //  [Required(ErrorMessage = "El numero de telefono es requerido")]
          public double Monto { get; set; }

          public string? Concepto { get; set; }

          public double Balance { get; set; }
  

          //[Range(1,int.MaxValue,ErrorMessage ="El selecionar una ocupacion")]

           public int PersonaID { get; set; }

     }
}