namespace LojaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb0001_Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nomeUSUARIO = c.String(nullable: false),
                        senhaUSUARIO = c.Int(nullable: false),
                        sobrenomeUSUARIO = c.String(),
                    })
                .PrimaryKey(t => t.idUsuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb0001_Usuarios");
        }
    }
}
