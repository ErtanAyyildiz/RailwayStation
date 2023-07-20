using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayStation.Entity.Modals
{
    public class TrainJourney
    {
        public int JourneyID { get; set; }
        public int DepartureStationID { get; set; } // kalkış istasyonu id
        public int ArrivalStationID { get; set; } // varış istasyonu id
        public DateTime DepartureDateTime { get; set; } // kalkış saati
        public DateTime ArrivalDateTime { get; set; } // varış saati

        [ForeignKey("DepartureStationID")]
        public TrainStation DepartureStation { get; set; }

        [ForeignKey("ArrivalStationID")]
        public TrainStation ArrivalStation { get; set; }
    }
}
