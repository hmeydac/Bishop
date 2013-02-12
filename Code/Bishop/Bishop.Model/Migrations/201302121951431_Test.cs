namespace Bishop.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Form_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.Form_Id)
                .Index(t => t.Form_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionType = c.Int(nullable: false),
                        Topic_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        IsCorrectAnswer = c.Boolean(nullable: false),
                        Weight = c.Double(nullable: false),
                        Question_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.FillingSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            this.DropIndex("dbo.Answers", new[] { "Question_Id" });
            this.DropIndex("dbo.Questions", new[] { "Topic_Id" });
            this.DropIndex("dbo.Topics", new[] { "Form_Id" });
            this.DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            this.DropForeignKey("dbo.Questions", "Topic_Id", "dbo.Topics");
            this.DropForeignKey("dbo.Topics", "Form_Id", "dbo.Forms");
            this.DropTable("dbo.FillingSessions");
            this.DropTable("dbo.Answers");
            this.DropTable("dbo.Questions");
            this.DropTable("dbo.Topics");
            this.DropTable("dbo.Forms");
        }
    }
}
