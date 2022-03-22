namespace CourseWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Procedures", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Animals", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Age", c => c.Double(nullable: false));
            AlterColumn("dbo.Procedures", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Clients", "FullName", c => c.String());
            AlterColumn("dbo.Animals", "Type", c => c.String());
            AlterColumn("dbo.Animals", "Gender", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String());
            DropColumn("dbo.Animals", "BirthDate");
        }
    }
}
