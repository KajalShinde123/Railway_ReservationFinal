namespace Railway_Reservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sign3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Res_Address", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "QuotaType", c => c.String(nullable: false));
            AlterColumn("dbo.TrainDetails", "TrainName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.TrainDetails", "TrainName", c => c.String());
            AlterColumn("dbo.Reservations", "QuotaType", c => c.String());
            AlterColumn("dbo.Reservations", "Res_Address", c => c.String());
        }
    }
}
