﻿namespace ShopBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryIdAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Items", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Items", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "CategoryId");
            AddForeignKey("dbo.Items", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            AlterColumn("dbo.Items", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Items", "Category_Id");
            AddForeignKey("dbo.Items", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
