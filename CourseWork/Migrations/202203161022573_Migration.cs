namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        HelperEmployeeId = c.Int(),
                        ClientId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Diagnosis = c.String(),
                        Assignment = c.String(),
                        TotalCost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: false)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.HelperEmployeeId)
                .Index(t => t.AnimalId)
                .Index(t => t.EmployeeId)
                .Index(t => t.HelperEmployeeId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.VisitProcedures",
                c => new
                    {
                        Visit_Id = c.Int(nullable: false),
                        Procedure_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Visit_Id, t.Procedure_Id })
                .ForeignKey("dbo.Visits", t => t.Visit_Id, cascadeDelete: false)
                .ForeignKey("dbo.Procedures", t => t.Procedure_Id, cascadeDelete: false)
                .Index(t => t.Visit_Id)
                .Index(t => t.Procedure_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitProcedures", "Procedure_Id", "dbo.Procedures");
            DropForeignKey("dbo.VisitProcedures", "Visit_Id", "dbo.Visits");
            DropForeignKey("dbo.Visits", "HelperEmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Visits", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Visits", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Visits", "AnimalId", "dbo.Animals");
            DropIndex("dbo.VisitProcedures", new[] { "Procedure_Id" });
            DropIndex("dbo.VisitProcedures", new[] { "Visit_Id" });
            DropIndex("dbo.Visits", new[] { "ClientId" });
            DropIndex("dbo.Visits", new[] { "HelperEmployeeId" });
            DropIndex("dbo.Visits", new[] { "EmployeeId" });
            DropIndex("dbo.Visits", new[] { "AnimalId" });
            DropTable("dbo.VisitProcedures");
            DropTable("dbo.Visits");
            DropTable("dbo.Procedures");
        }
    }
}
