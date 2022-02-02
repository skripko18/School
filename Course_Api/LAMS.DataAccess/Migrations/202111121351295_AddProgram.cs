namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgram : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseProgram",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Theme = c.String(),
                        IdCourse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.IdCourse)
                .Index(t => t.IdCourse);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Description = c.String(),
                        IdCourse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.IdCourse)
                .Index(t => t.IdCourse);
            
            CreateTable(
                "dbo.LearnerCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        IdCourse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.IdCourse)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdCourse);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        Description = c.String(),
                        IdCourse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.IdCourse)
                .Index(t => t.IdCourse);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseProgram", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.Material", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.LearnerCourse", "IdUser", "dbo.Users");
            DropForeignKey("dbo.LearnerCourse", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.Homework", "IdCourse", "dbo.Course");
            DropIndex("dbo.Material", new[] { "IdCourse" });
            DropIndex("dbo.LearnerCourse", new[] { "IdCourse" });
            DropIndex("dbo.LearnerCourse", new[] { "IdUser" });
            DropIndex("dbo.Homework", new[] { "IdCourse" });
            DropIndex("dbo.CourseProgram", new[] { "IdCourse" });
            DropTable("dbo.Material");
            DropTable("dbo.LearnerCourse");
            DropTable("dbo.Homework");
            DropTable("dbo.CourseProgram");
        }
    }
}
