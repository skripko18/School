namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "Status");
        }
    }
}
