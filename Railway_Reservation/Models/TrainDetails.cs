using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Reservation.Models
{
    public class TrainDetails
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Train_Id { get; set; }
        [Required(ErrorMessage ="Train name is required..")]
        public string TrainName { get;set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public int Fare { get; set; }
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; }
        [DataType(DataType.Time)]
        public string DepartureTime { get; set;}
        [Required]
        public int TotalSeats { get; set;}
    }
}