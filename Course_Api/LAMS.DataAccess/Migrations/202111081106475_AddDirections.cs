namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectionDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direction = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherDirectionDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        IdUser = c.String(),
                        Experience = c.String(),
                        Workplace = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            DropForeignKey("dbo.TeacherDirectionDbs", "User_Id", "dbo.Users");
            DropIndex("dbo.TeacherDirectionDbs", new[] { "User_Id" });
            DropTable("dbo.TeacherDirectionDbs");
            DropTable("dbo.DirectionDbs");
        }
    }
}
