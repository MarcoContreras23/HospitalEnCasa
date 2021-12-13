using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HospitalEnCasaDevIng.Models
{
    public class AsignarMedicoPaciente
    {
        // El contexto se ha configurado para usar una cadena de conexión 'AsignarMedicoPaciente' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'HospitalEnCasaDevIng.Models.AsignarMedicoPaciente' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'AsignarMedicoPaciente'  en el archivo de configuración de la aplicación.
        public AsignarMedicoPaciente()
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        [Key]
        public int IdentificacionAsignacion { get; set; }

        public  int IdentificacionMedico { get; set; }
        [ForeignKey("IdentificacionMedico")]
        public virtual Medico IdentificacionMedicoFK { get; set; }

        public int IdentificacionPaciente { get; set; }
        [ForeignKey("IdentificacionPaciente")]
        public virtual Paciente IdentificacionPacienteFK { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}