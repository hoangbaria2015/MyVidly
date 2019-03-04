namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoppulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Black Panther','1/29/2018','3/30/2018',3,1)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Iron Man 3','4/26/2013','3/30/2018',5,2)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Captain America: Civil War','3/27/2018','3/30/2018',9,3)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Black Panther','12/14/2018','3/30/2018',12,4)");
        }
        
        public override void Down()
        {
        }
    }
}
