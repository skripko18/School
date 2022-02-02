namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDirections : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DirectionDbs", newName: "Direction");
            RenameTable(name: "dbo.TeacherDirectionDbs", newName: "TeacherDirection");
            DropIndex("dbo.TeacherDirection", new[] { "User_Id" });
            DropColumn("dbo.TeacherDirection", "IdUser");
            RenameColumn(table: "dbo.TeacherDirection", name: "User_Id", newName: "IdUser");
            AlterColumn("dbo.TeacherDirection", "IdUser", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TeacherDirection", "IdUser", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TeacherDirection", "IdUser");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TeacherDirection", new[] { "IdUser" });
            AlterColumn("dbo.TeacherDirection", "IdUser", c => c.String(maxLength: 128));
            AlterColumn("dbo.TeacherDirection", "IdUser", c => c.String());
            RenameColumn(table: "dbo.TeacherDirection", name: "IdUser", newName: "User_Id");
            AddColumn("dbo.TeacherDirection", "IdUser", c => c.String());
            CreateIndex("dbo.TeacherDirection", "User_Id");
            RenameTable(name: "dbo.TeacherDirection", newName: "TeacherDirectionDbs");
            RenameTable(name: "dbo.Direction", newName: "DirectionDbs");
        }
    }
}
