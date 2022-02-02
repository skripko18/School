namespace LAMS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FIO", c => c.String());
            AddColumn("dbo.Users", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Users", "FIO");
        }
    }
}
