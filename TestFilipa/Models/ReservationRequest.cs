using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestFilipa.Models
{
    public class ReservationRequest
    {
        public string StartReservation { get; set; }
        public string StopReservation { get; set; }
        public int NumberOfPersons { get; set; }
    }
}