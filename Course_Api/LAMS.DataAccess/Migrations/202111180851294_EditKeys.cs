namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseProgram", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.Homework", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.Material", "IdCourse", "dbo.Course");
            AddForeignKey("dbo.CourseProgram", "IdCourse", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "IdCourse", "dbo.Course", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Material", "IdCourse", "dbo.Course", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Material", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.Homework", "IdCourse", "dbo.Course");
            DropForeignKey("dbo.CourseProgram", "IdCourse", "dbo.Course");
            AddForeignKey("dbo.Material", "IdCourse", "dbo.Course", "Id");
            AddForeignKey("dbo.Homework", "IdCourse", "dbo.Course", "Id");
            AddForeignKey("dbo.CourseProgram", "IdCourse", "dbo.Course", "Id");
        }
    }
}
