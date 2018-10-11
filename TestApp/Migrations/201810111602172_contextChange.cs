namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_QuestionId" });
            RenameColumn(table: "dbo.Answers", name: "Question_QuestionId", newName: "QuestionId");
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        TestHeader = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Questions", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "QuestionId");
            CreateIndex("dbo.Questions", "TestId");
            AddForeignKey("dbo.Questions", "TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
            Sql(@"SET IDENTITY_INSERT [dbo].[Subjects] ON
INSERT INTO [dbo].[Subjects] ([SubjectId], [SubjectName]) VALUES (1, N'Математика')
INSERT INTO [dbo].[Subjects] ([SubjectId], [SubjectName]) VALUES (2, N'Грамматика')
INSERT INTO [dbo].[Subjects] ([SubjectId], [SubjectName]) VALUES (3, N'География')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Tests", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropIndex("dbo.Tests", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            AlterColumn("dbo.Answers", "QuestionId", c => c.Int());
            DropColumn("dbo.Questions", "TestId");
            DropTable("dbo.Tests");
            DropTable("dbo.Subjects");
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_QuestionId");
            CreateIndex("dbo.Answers", "Question_QuestionId");
            AddForeignKey("dbo.Answers", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}
