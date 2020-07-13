namespace WebStoreWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageBinaryTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductBlobs", "ImageBinray");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductBlobs", "ImageBinray", c => c.Binary());//
        }
    }
}
