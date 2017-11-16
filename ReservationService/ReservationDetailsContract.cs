using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ReservationService
{
    [DataContract]
    public class ReservationDetailsContract
    {
        [DataMember]
        public string StartDate { get; set; }

        [DataMember]
        public string StopDate { get; set; }

        [DataMember]
        public string NumberOfPeoples { get; set; }
    }
}