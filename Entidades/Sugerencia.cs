using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sugerencia
    {
        [Key]
            public int SugerenciasId { get; set; }
            public DateTime Fecha { get; set; }
            public string Descripcion { get; set; }

            public Sugerencia(int sugerenciasId, DateTime fecha, string descripcion)
            {
                SugerenciasId = sugerenciasId;
                Fecha = fecha;
                Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            }
            public Sugerencia()
            {
                SugerenciasId = 0;
                Fecha = DateTime.Now;
                Descripcion = string.Empty;
            }
        }
    
}
