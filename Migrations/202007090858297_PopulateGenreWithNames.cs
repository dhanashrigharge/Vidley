namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreWithNames : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
