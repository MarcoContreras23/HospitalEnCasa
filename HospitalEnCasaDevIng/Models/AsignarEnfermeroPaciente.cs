using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HospitalEnCasaDevIng.Models
{
    public class AsignarEnfermeroPaciente
    {
        // El contexto se ha configurado para usar una cadena de conexión 'AsignarEnfermeroPaciente' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'HospitalEnCasaDevIng.Models.AsignarEnfermeroPaciente' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'AsignarEnfermeroPaciente'  en el archivo de configuración de la aplicación.
        public AsignarEnfermeroPaciente()
        {
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        
        [Key]
        public int IdentificacionAsignacion { get; set; }

        public  int IdentificacionEnfemeroFK { get; set; }
        [ForeignKey("IdentificacionEnfemeroFK")]
        public virtual Enfermero IdentificacionEnfermero { get; set; }


        public int IdentificacionPacienteFK { get; set; }
        [ForeignKey("IdentificacionPacienteFK")]
        public virtual Paciente IdentificacionPaciente { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}