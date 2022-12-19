namespace Railway_Reservation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sign1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainDetails", "Fare", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainDetails", "Fare", c => c.Double(nullable: false));
        }
    }
}
