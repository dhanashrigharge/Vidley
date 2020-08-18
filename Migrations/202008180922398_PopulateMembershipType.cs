namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET SignUpFee=100, DurationInMonths=2, DiscountRate=10 WHERE Id=1");
            Sql("UPDATE MembershipTypes SET SignUpFee=200, DurationInMonths=4, DiscountRate=20 WHERE Id=2");
            Sql("UPDATE MembershipTypes SET SignUpFee=300, DurationInMonths=6, DiscountRate=30 WHERE Id=3");
            Sql("UPDATE MembershipTypes SET SignUpFee=400, DurationInMonths=8, DiscountRate=40 WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
