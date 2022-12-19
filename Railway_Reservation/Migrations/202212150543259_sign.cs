namespace Railway_Reservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Res_Id = c.Int(nullable: false, identity: true),
                        Res_Name = c.String(),
                        Res_Gender = c.String(),
                        Res_Address = c.String(),
                        User_Id = c.Int(nullable: false),
                        QuotaType = c.String(),
                        Res_Date = c.String(),
                        Train_Id = c.Int(nullable: false),
                        PNR_NO = c.Long(nullable: false),
                        Seat_No = c.Int(nullable: false),
                        Transaction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Res_Id)
                .ForeignKey("dbo.TrainDetails", t => t.Train_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Train_Id);
            
            CreateTable(
                "dbo.TrainDetails",
                c => new
                    {
                        Train_Id = c.Int(nullable: false, identity: true),
                        TrainName = c.String(),
                        SourceStation = c.String(),
                        DestinationStation = c.String(),
                        Fare = c.Double(nullable: false),
                        ArrivalTime = c.String(),
                        DepartureTime = c.String(),
                        TotalSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Train_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.User_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Ticket_Id = c.Int(nullable: false, identity: true),
                        Res_Id = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        DateOfJourney = c.String(),
                    })
                .PrimaryKey(t => t.Ticket_Id)
                .ForeignKey("dbo.Reservations", t => t.Res_Id, cascadeDelete: true)
                .Index(t => t.Res_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Res_Id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reservations", "Train_Id", "dbo.TrainDetails");
            DropIndex("dbo.Tickets", new[] { "Res_Id" });
            DropIndex("dbo.Reservations", new[] { "Train_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.TrainDetails");
            DropTable("dbo.Reservations");
        }
    }
}
