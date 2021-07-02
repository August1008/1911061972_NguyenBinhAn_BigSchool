namespace _1911061972_NguyenBinhAn_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToAspNetUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "name");
        }
    }
}
