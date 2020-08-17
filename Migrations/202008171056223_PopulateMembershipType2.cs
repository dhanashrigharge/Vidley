namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (1, 'Pay As You Go')");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (2, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (3, 'Quarterly')");
            Sql("INSERT INTO MembershipTypes (Id, Name) VALUES (4, 'Annual')");
        }
        
        public override void Down()
        {
        }
    }
}
