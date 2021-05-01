namespace ShopBridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Categories (Name) values ('Dairy Product')");
            Sql("Insert into Categories (Name) values ('Confectionary')");
            Sql("Insert into Categories (Name) values ('Books')");
            Sql("Insert into Categories (Name) values ('Self-care')");
            Sql("Insert into Categories (Name) values ('Stationary')");
        }
        
        public override void Down()
        {
        }
    }
}
