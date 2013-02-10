namespace Bishop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidIds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "Form_Id", c => c.Guid());
            AlterColumn("dbo.Forms", "Id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "Form_Id", c => c.Long());
            AlterColumn("dbo.Forms", "Id", c => c.Long(nullable: false, identity: true));
        }
    }
}
