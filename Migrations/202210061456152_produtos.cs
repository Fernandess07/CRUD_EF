namespace CRUDEFFINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class produtos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(maxLength: 255),
                        Marca = c.String(maxLength: 255),
                        PRECO = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtos");
        }
    }
}
