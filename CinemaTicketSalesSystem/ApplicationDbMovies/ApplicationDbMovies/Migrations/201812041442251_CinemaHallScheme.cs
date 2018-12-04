namespace ApplicationDbMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CinemaHallScheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CinemaAddresses",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        AddressName = c.String(nullable: false, maxLength: 255),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinemaId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.CinemaAddresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CinemaId = c.Int(nullable: false),
                        Cinema_AddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_AddressId)
                .Index(t => t.Cinema_AddressId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CinemaSeatTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatTypeId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false),
                        Number = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SeatTypeId = c.Int(nullable: false),
                        CinemaSeatTypeId = c.Int(nullable: false),
                        RowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rows", t => t.RowId, cascadeDelete: true)
                .Index(t => t.RowId);
            
            CreateTable(
                "dbo.SeatTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        Time = c.String(nullable: false, maxLength: 255),
                        Coefficient = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        RowId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "RowId", "dbo.Rows");
            DropForeignKey("dbo.CinemaAddresses", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cinemas", "AddressId", "dbo.CinemaAddresses");
            DropForeignKey("dbo.Halls", "Cinema_AddressId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "RowId" });
            DropIndex("dbo.Halls", new[] { "Cinema_AddressId" });
            DropIndex("dbo.Cinemas", new[] { "AddressId" });
            DropIndex("dbo.CinemaAddresses", new[] { "CityId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Sessions");
            DropTable("dbo.SeatTypes");
            DropTable("dbo.Seats");
            DropTable("dbo.Rows");
            DropTable("dbo.CinemaSeatTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.Halls");
            DropTable("dbo.Cinemas");
            DropTable("dbo.CinemaAddresses");
        }
    }
}
