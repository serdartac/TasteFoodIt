namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailSubscribes",
                c => new
                    {
                        MailSubscribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MailSubscribeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailSubscribes");
        }
    }
}
