using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ReservationService
{   
    [ServiceContract]
    public interface IOReservationService 
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ReserveRoom",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        ReservationDetailsContract ReserveRoom(ReservationDetailsContract order);
        /*
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetReservations",
            ResponseFormat = WebMessageFormat.Json, Method = "GET")]
        bool GetReservations();
        */
    }
}
