namespace HospitalEnCasaDevIng.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asignaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignarEnfermeroPacientes",
                c => new
                    {
                        IdentificacionAsignacion = c.Int(nullable: false, identity: true),
                        IdentificacionEnfemeroFK = c.Int(nullable: false),
                        IdentificacionPacienteFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificacionAsignacion)
                .ForeignKey("dbo.Enfermeroes", t => t.IdentificacionEnfemeroFK, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.IdentificacionPacienteFK, cascadeDelete: true)
                .Index(t => t.IdentificacionEnfemeroFK)
                .Index(t => t.IdentificacionPacienteFK);
            
            CreateTable(
                "dbo.AsignarMedicoPacientes",
                c => new
                    {
                        IdentificacionAsignacion = c.Int(nullable: false, identity: true),
                        IdentificacionMedico = c.Int(nullable: false),
                        IdentificacionPaciente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdentificacionAsignacion)
                .ForeignKey("dbo.Medicos", t => t.IdentificacionMedico, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.IdentificacionPaciente, cascadeDelete: true)
                .Index(t => t.IdentificacionMedico)
                .Index(t => t.IdentificacionPaciente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignarMedicoPacientes", "IdentificacionPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.AsignarMedicoPacientes", "IdentificacionMedico", "dbo.Medicos");
            DropForeignKey("dbo.AsignarEnfermeroPacientes", "IdentificacionPacienteFK", "dbo.Pacientes");
            DropForeignKey("dbo.AsignarEnfermeroPacientes", "IdentificacionEnfemeroFK", "dbo.Enfermeroes");
            DropIndex("dbo.AsignarMedicoPacientes", new[] { "IdentificacionPaciente" });
            DropIndex("dbo.AsignarMedicoPacientes", new[] { "IdentificacionMedico" });
            DropIndex("dbo.AsignarEnfermeroPacientes", new[] { "IdentificacionPacienteFK" });
            DropIndex("dbo.AsignarEnfermeroPacientes", new[] { "IdentificacionEnfemeroFK" });
            DropTable("dbo.AsignarMedicoPacientes");
            DropTable("dbo.AsignarEnfermeroPacientes");
        }
    }
}
