namespace big_project_practiceToFinal_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableGoingOutShoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoingOutShoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Gender = c.String(),
                        HeelOn = c.Boolean(nullable: false),
                        IfExist = c.Boolean(nullable: false),
                        Size = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GoingOutShoes");
        }
    }
}
