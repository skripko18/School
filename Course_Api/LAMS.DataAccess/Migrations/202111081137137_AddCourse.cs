namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdTeacherDirection = c.Int(nullable: false),
                        IdDirection = c.Int(nullable: false),
                        Skills = c.String(),
                        DateStart = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direction", t => t.IdDirection)
                .ForeignKey("dbo.TeacherDirection", t => t.IdTeacherDirection)
                .Index(t => t.IdTeacherDirection)
                .Index(t => t.IdDirection);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "IdTeacherDirection", "dbo.TeacherDirection");
            DropForeignKey("dbo.Course", "IdDirection", "dbo.Direction");
            DropIndex("dbo.Course", new[] { "IdDirection" });
            DropIndex("dbo.Course", new[] { "IdTeacherDirection" });
            DropTable("dbo.Course");
        }
    }
}
