using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace HospitalEnCasaDevIng.Models
{
    public class Paciente
    {
        // El contexto se ha configurado para usar una cadena de conexión 'Paciente' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'HospitalEnCasaDevIng.Models.Paciente' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'Paciente'  en el archivo de configuración de la aplicación.
        public Paciente()
        {

        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        [Key] 
        public int Identificacion { get; set; }

        public string TipoDocumento { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Ocupacion { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string DireccionGeo { get; set; }

        public string GrupoSanguineo { get; set; }

        public string Eps { get; set; }
    }

    
}