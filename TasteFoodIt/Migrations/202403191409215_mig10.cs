namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MailSubscribes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MailSubscribes",
                c => new
                    {
                        MailSubscribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        EmailStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailSubscribeId);
            
        }
    }
}
