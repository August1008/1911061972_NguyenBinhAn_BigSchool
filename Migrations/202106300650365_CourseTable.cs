namespace _1911061972_NguyenBinhAn_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        place = c.String(nullable: false, maxLength: 255),
                        datetime = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Lecturer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecturer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.Lecturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
