namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmailStatusColumnInMailSubscribesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MailSubscribes", "EmailStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MailSubscribes", "EmailStatus");
        }
    }
}
